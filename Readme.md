Pokemon Challenge
=================

# Challenge

There are successful brands who have managed to stay relevant for more than a decade without innovating too much.

Some of our colleagues have young children and we’d like to offer them a fresh perspective on the world of Pokemon: what if the description of each Pokemon were to be written using Shakespeare’s style?

We would like you to develop a simple search engine that, given a Pokemon name, returns its Shakespearean description.

## Backend Requirements

* Retrieve Shakespearean description and pokemon sprite

```
GET endpoint: /pokemon/<pokemon name> 
```

Usage example (using httpie):
```
GET http://localhost:5000/pokemon/charizard
```

Output format:
``` json
{
"name": "charizard",
"description": "Charizard flies 'round the sky in search of powerful opponents. 't breathes fire of
such most wondrous heat yond 't melts aught. However, 't nev'r turns its fiery breath on any opponent weaker than itself.",
"sprite": "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/6.png" }
```

## Frontend Requirements
* Search field where you can type the Pokemon name (think something simple like the google’s homepage)
* Show the Shakespearean description of the Pokemon and sprite (image) from the backend that you just created previously.
* Basic (responsive) styling
* Accessibility
 
## Guidelines
* Feel free to use any programming language for the backend.
* For the front end, please use ReactJS.
* Your solution should be concise, readable, and correct.
* Include automated tests that confirm your solution is working.

## Useful APIs:
* [Shakespeare translator](https://funtranslations.com/api/shakespeare)
* [PokéAPI](https://pokeapi.co/docs/v2)



# Notes

* Pokemon description can he retrived using https://pokeapi.co/docs/v2/pokemon-species/{pokemon-name}
* Pokemon sprite can be retrived using https://pokeapi.co/docs/v2/pokemon/{pokemon-name}
* Sharespere Translation -> POST https://api.funtranslations.com/translate/shakespeare.json {"text": "text to be translated"}   
* TranslateService => GetTranslation(string paragraph)
* PokemonService => GetPokemon(string pokemonName)

