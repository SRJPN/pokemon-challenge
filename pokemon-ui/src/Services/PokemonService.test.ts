import axios from "axios";
import { PokemonService } from "./PokemonService";

describe.only("PokemonService", () => {
  
  describe("getPokemon", () => {
    beforeEach(() => {
      jest.mock('axios');
    });
    
    it("should throw error on api error", async () => {
        const mockFetch = {
          status: 404,
        }
        axios.get = jest.fn().mockResolvedValue(mockFetch);
        const service = new PokemonService();

        await expect(service.getPokemon('some-pokemon')).rejects.toThrow("Pokemon not found");
        expect(axios.get).toBeCalledWith(`pokemon/some-pokemon`, {"headers": {"Content-Type": "application/json"}})
    });

    it("should return response as json", async () => {
        const fakeResponse = { name: "pokemon-name" };
        const mockFetch = {
          data: fakeResponse,
          status: 200,
        };
        axios.get = jest.fn().mockResolvedValue(mockFetch);
        const service = new PokemonService();

        await expect(service.getPokemon('some-pokemon')).resolves.toBe(fakeResponse);
        expect(axios.get).toBeCalledWith(`pokemon/some-pokemon`, {"headers": {"Content-Type": "application/json"}})
    });
  });
});
