import React, { useEffect, useState } from "react";
import { Pokemon } from "../Models/Pokemon";
import { PokemonService } from "../Services/PokemonService";
import PokemonNotFound from "./PokemonNotFound";
import PokemonTile from "./PokemonTile";

const PokemonList = ({ pokemonName }: { pokemonName: string }) => {
  const [pokemon, setPokemon] = useState({} as Pokemon);
  const [isError, setIsError] = useState(false);

  useEffect(() => {
    if (pokemonName)
      PokemonService
        .getPokemon(pokemonName)
        .then((retrivedPokemon) => {
          setIsError(false);
          setPokemon(retrivedPokemon);
        })
        .catch((err) => {
          setIsError(true);
        });
  }, [pokemonName]);

  if (isError) {
    return <PokemonNotFound />;
  }
  if (!pokemonName) {
    return <></>;
  }
  return <PokemonTile pokemon={pokemon} />;
};

export default PokemonList;
