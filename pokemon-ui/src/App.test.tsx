import React from 'react';
import { render, screen } from '@testing-library/react';
import App from './App';

test('renders pokemon challenge header', () => {
  render(<App />);
  const linkElement = screen.getByText(/Pokemon Challenge/i);
  expect(linkElement).toBeInTheDocument();
});
