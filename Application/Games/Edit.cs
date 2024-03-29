using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Games
{
    public class Edit
    {
        public class Command : IRequest
        {
            public Game Game { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task Handle(Command request, CancellationToken cancellationToken)
            {
                var game = await _context.Games.FindAsync(request.Game.Id);
                _mapper.Map(request.Game, game);
                await _context.SaveChangesAsync();
            }
        }
    }
}