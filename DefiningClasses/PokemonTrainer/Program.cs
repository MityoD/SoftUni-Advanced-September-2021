using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            List<Trainer> trainers = new List<Trainer>();
            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);
                Pokemon newPokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);
                if (trainers.Any(n => n.Name == trainerName))
                {
                    trainers.Where(n => n.Name == trainerName).FirstOrDefault().Pokemons.Add(newPokemon);
                    continue;
                }
                Trainer newTrainer = new Trainer(trainerName);
                newTrainer.Pokemons.Add(newPokemon);
                trainers.Add(newTrainer);
            }
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers)
                {
                    if (trainer.Pokemons.Any(p => p.Element == command))
                    {
                        trainer.Badges++;
                        //for one or all?
                    }
                    else
                    {
                        foreach (var pokemon in trainer.Pokemons)
                        {
                            pokemon.Health -= 10;
                        }
                        for (int i = 0; i < trainer.Pokemons.Count; i++)
                        {
                            if (trainer.Pokemons[i].Health <= 0)
                            {
                                trainer.Pokemons.Remove(trainer.Pokemons[i]);

                            }
                        }
                    }
                }
            }
            foreach (var trainer in trainers.OrderByDescending(x => x.Badges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
            }
        }
    }
}
