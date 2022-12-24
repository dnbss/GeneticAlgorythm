using GeneticAlgorythm.Interfaces;
using MathParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythm
{
    public class GeneticAlgorythm
    {
        private IMutation _mutator;

        private ICrossing _crossover;

        private ISelection _selector;

        private Parser _parser;

        public GeneticAlgorythm
            (
                IMutation mutator, 
                ICrossing crossover, 
                ISelection selector
            )
        {
            _mutator = mutator;

            _crossover = crossover;

            _selector = selector;

            _parser = new Parser();
        }

        public double GetResult(double[] arguments) => _parser.Calculate(arguments);

        public double[] GetResultArguments(string expression
            , int countStartedPopulation
            , int countGenerations
            , int numberSurvived)
        {
            _parser.ConvertFunc(expression);

            List<Chromosome> population = new();

            for (int i = 0; i < countStartedPopulation; i++)
            {
                population.Add(new Chromosome(_parser.ArgumentsNumber));
            }

            for (int i = 0; i < countGenerations; i++)
            {
                if (population.Count >= numberSurvived)
                {
                    population = _selector.Select(population, _parser, numberSurvived);

                    if (population.Count >= 2)
                    {
                        var children = _crossover.Cross(population[0], population[1]);

                        _mutator.Mutate(children);

                        population.AddRange(children);
                    }
                }
            }

            var resultArguments = population.OrderBy(chromosome => _parser.Calculate(chromosome.Gens))
                .First().Gens;

            return resultArguments;
        }

        public string[] GetNamesArguments()
        {
            string[] names = new string[_parser.ArgumentsNumber];

            for (int i = 0; i < names.Length; i++)
            {
                names[i] = _parser.ArgumentName(i);
            }

            return names;
        }
    }
}
