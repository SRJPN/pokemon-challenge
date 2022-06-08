import React from "react";
import { render, screen } from "@testing-library/react";
import SearchBar from "./SearchBar";

test("renders search box", () => {
  render(<SearchBar keyword="search-keyword" />);
  const inputElement = screen.getByRole("textbox");
  expect(inputElement).toBeInTheDocument();
  expect(inputElement).toHaveValue("search-keyword");
  expect(inputElement).toHaveAttribute("name", "pokemon");
});