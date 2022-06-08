import React from "react";
import { render, screen } from "@testing-library/react";
import PokemonTile from "./PokemonTile";
import { Pokemon } from "../Models/Pokemon";

test("renders pokemon name", async () => {
  render(<PokemonTile pokemon={{name: 'pokemon-name'} as Pokemon} />);
  const divElement = await screen.findByText("pokemon-name");
  expect(divElement).toBeInTheDocument();
  expect(divElement.classList).toContain('card-title');
});

test("renders pokemon description", async () => {
  render(<PokemonTile pokemon={{description: 'pokemon-description'} as Pokemon} />);
  const divElement = await screen.findByText("pokemon-description");
  expect(divElement).toBeInTheDocument();
  expect(divElement.classList).toContain('card-description');
});

test("renders pokemon sprite as image", async () => {
  render(<PokemonTile pokemon={{sprite: 'pokemon-sprite'} as Pokemon} />);
  const imageElement = await screen.findByRole('img');
  expect(imageElement).toBeInTheDocument();
  expect(imageElement.classList).toContain('card-img');
});