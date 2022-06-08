import React from "react";
import { render, screen } from "@testing-library/react";
import PokemonNotFound from "./PokemonNotFound";

test("renders not found text", async () => {
  render(<PokemonNotFound />);
  const divElement = await screen.findByText("Pokemon not found");
  expect(divElement).toBeInTheDocument();
  expect(divElement.classList).toContain('card-title');
});