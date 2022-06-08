export class PokemonService {
  public async getPokemon(pokemonName: string) {
    return fetch(`pokemon/${pokemonName}`, {
      headers: {
        "Content-Type": "application/json",
      },
    }).then((x) => {
      if (x.ok) {
        return x.json();
      }
      throw new Error("Pokemon not found");
    });
  }
}
