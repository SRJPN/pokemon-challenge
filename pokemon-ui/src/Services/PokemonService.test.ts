import { PokemonService } from "./PokemonService";

describe("PokemonService", () => {
  describe("getPokemon", () => {
    it("should throw error on api error", async () => {
        const fakeResponse = { name: "pokemon-name" };
        const mockFetch = Promise.resolve({
          json: () => Promise.resolve(fakeResponse),
          ok: false,
        });
        jest.spyOn(window, "fetch").mockImplementationOnce(() => mockFetch as any);
        const service = new PokemonService();

        await expect(service.getPokemon('some-pokemon')).rejects.toThrow("Pokemon not found");
        expect(window.fetch).toBeCalledWith(`pokemon/some-pokemon`, {"headers": {"Content-Type": "application/json"}})
    });

    it("should return response as json", async () => {
        const fakeResponse = { name: "pokemon-name" };
        const jsonMethod = jest.fn().mockResolvedValue(fakeResponse);
        const mockFetch = Promise.resolve({
          json: jsonMethod,
          ok: true,
        });
        jest.spyOn(window, "fetch").mockImplementationOnce(() => mockFetch as any);
        const service = new PokemonService();

        await expect(service.getPokemon('some-pokemon')).resolves.toBe(fakeResponse);
        expect(jsonMethod).toBeCalled();
        expect(window.fetch).toBeCalledWith(`pokemon/some-pokemon`, {"headers": {"Content-Type": "application/json"}})
    });
  });
});
