import axios from "./axios";
import { Pokemon } from "../Models/Pokemon";

export class PokemonService {
  static async getPokemon(pokemonName: string) {
    return axios.get(`pokemon/${pokemonName}`, {
      headers: {
        "Content-Type": "application/json",
      },
    }).then((x) => {
      if (x.status === 200) {
        return x.data as Pokemon
      }
      throw new Error("Pokemon not found");
    });
  }
}
