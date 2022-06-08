import React from "react";
import { render, screen } from "@testing-library/react";
import PokemonList from "./PokemonList";
import axios from "axios";

beforeEach(() => {
  jest.mock('axios');
});

test("renders empty for empty pokemon", () => {
  render(<PokemonList pokemonName="" />);
  const divElement = screen.queryByRole("div");
  expect(divElement).not.toBeInTheDocument();
});

test("renders not found error on error in service api", async () => {
  const mockFetch = {
    status: 404,
  }
  axios.get = jest.fn().mockRejectedValue(mockFetch);
  render(<PokemonList pokemonName="pokemon" />);

  const notFoundElement = await screen.findByText("Pokemon not found");
  expect(notFoundElement).toBeInTheDocument();
  expect(axios.get).toBeCalled();
});

test("renders pokemon once service api returns pokemon", async () => {
  const fakeResponse = { name: "pokemon-name" };
  const mockFetch = {
    data: fakeResponse,
    status: 200,
  };
  axios.get = jest.fn().mockResolvedValue(mockFetch);
  render(<PokemonList pokemonName="pokemon" />);

  const pokemonNameElement = await screen.findByText("pokemon-name");
  expect(pokemonNameElement).toBeInTheDocument();
  expect(axios.get).toBeCalled();
});
