import React from 'react';
import { it, expect } from 'vitest';
import { render, screen } from '@testing-library/react';
import App from './App';

it.skip('renders learn react link', () => {
  render(<App />);
  const linkElement = screen.getByText(/learn react/i);
  //expect(linkElement).toBeInTheDocument();
});
