import "./App.css";
import PokemonList from "./Components/PokemonList";
import SearchBar from "./Components/SearchBar";

function App() {
  const { search } = window.location;
  const query = new URLSearchParams(search).get("pokemon") || "";
  return (
    <div className="App">
      <header className="App-header">
        <h1>Pokemon Challenge</h1>
      </header>
      <SearchBar keyword={query} />
      <PokemonList pokemonName={query}></PokemonList>
    </div>
  );
}

export default App;
