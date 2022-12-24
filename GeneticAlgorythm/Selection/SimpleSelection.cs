using GeneticAlgorythm.Interfaces;
using MathParser;
using System;
using System.Collections;

namespace GeneticAlgorythm.Selection
{
    public class SimpleSelection : ISelection
    {
        public List<Chromosome> Select(List<Chromosome> population, Parser parser, int numberSurvived) => population
                .OrderBy(chromosome => parser.Calculate(chromosome.Gens))
                .Take(numberSurvived)
                .ToList();
    }
}
