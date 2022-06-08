import React from "react";
import { act, render, screen } from "@testing-library/react";
import PokemonList from "./PokemonList";

test("renders empty for empty pokemon", () => {
  render(<PokemonList pokemonName="" />);
  const divElement = screen.queryByRole("div");
  expect(divElement).not.toBeInTheDocument();
});

test("renders not found error on error in service api", async () => {
  const fakeResponse = { name: "pokemon-name" };
  const mockFetch = Promise.resolve({
    json: () => Promise.resolve(fakeResponse),
    ok: false,
  });
  jest.spyOn(window, "fetch").mockImplementationOnce(() => mockFetch as any);
  render(<PokemonList pokemonName="pokemon" />);

  const notFoundElement = await screen.findByText("Pokemon not found");
  expect(notFoundElement).toBeInTheDocument();
  expect(window.fetch).toBeCalled();

  await act(async () => {
    await mockFetch;
  });
});

test("renders pokemon once service api returns pokemon", async () => {
  const fakeResponse = { name: "pokemon-name" };
  const mockFetch = Promise.resolve({
    json: () => Promise.resolve(fakeResponse),
    ok: true,
  });
  jest.spyOn(window, "fetch").mockImplementationOnce(() => mockFetch as any);
  render(<PokemonList pokemonName="pokemon" />);

  const pokemonNameElement = await screen.findByText("pokemon-name");
  expect(pokemonNameElement).toBeInTheDocument();
  expect(window.fetch).toBeCalled();

  await act(async () => {
    await mockFetch;
  });
});
