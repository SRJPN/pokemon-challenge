import React from "react";
import { render, screen } from "@testing-library/react";
import PokemonList from "./PokemonList";
import { PokemonService } from "../Services/PokemonService";


beforeEach(() => {
  jest.mock('../Services/PokemonService.ts');
});

test("renders empty for empty pokemon", () => {
  render(<PokemonList pokemonName="" />);
  const divElement = screen.queryByRole("div");
  expect(divElement).not.toBeInTheDocument();
});

test("renders not found error on error in service api", async () => {
  PokemonService.getPokemon = jest.fn().mockRejectedValue("");
  render(<PokemonList pokemonName="pokemon" />);

  const notFoundElement = await screen.findByText("Pokemon not found");
  expect(notFoundElement).toBeInTheDocument();
  expect(PokemonService.getPokemon).toBeCalled();
});

test("renders pokemon once service api returns pokemon", async () => {
  const fakeResponse = { name: "pokemon-name" };
  PokemonService.getPokemon = jest.fn().mockResolvedValue(fakeResponse);
  render(<PokemonList pokemonName="pokemon" />);

  const pokemonNameElement = await screen.findByText("pokemon-name");
  expect(pokemonNameElement).toBeInTheDocument();
  expect(PokemonService.getPokemon).toBeCalled();
});
