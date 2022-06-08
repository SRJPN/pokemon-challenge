import "./PokemonTile.css";
import { Pokemon } from "../Models/Pokemon";

const PokemonTile = ({ pokemon }: { pokemon: Pokemon }) => {
  return (
    <div className="card">
      <img className="card-img" alt={pokemon.name} src={pokemon.sprite} />
      <div className="card-body">
        <div className="card-title">{pokemon.name}</div>
        <div className="card-description">
          {pokemon.description}
        </div>
      </div>
    </div>
  );
};

export default PokemonTile;
