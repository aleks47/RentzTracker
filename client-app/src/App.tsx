import { useEffect, useState } from "react";
import "./App.css";
import axios from "axios";
import { Header, List } from "semantic-ui-react";

function App() {
  const [games, setGames] = useState([]);

  useEffect(() => {
    axios.get("http://localhost:5000/api/games").then((response) => {
      setGames(response.data);
    });
  }, []);
  return (
    <div>
      <Header as="h2" icon="users" content="Games" />
      <List>
        {games.map((game: any) => (
          <List.Item key={game.id}>{game.description}</List.Item>
        ))}
      </List>
    </div>
  );
}

export default App;
