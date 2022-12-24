using GeneticAlgorythm.Interfaces;
using MathParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythm.Selection
{
    public class RankSelection : ISelection
    {
        public List<Chromosome> Select(List<Chromosome> population, Parser parser, int numberSurvived)
        {
            double averageFunctionValue = population.Average(chromosome => parser.Calculate(chromosome.Gens));

            var result = population.Where(chromosome => parser.Calculate(chromosome.Gens) >= averageFunctionValue).ToList();

            return result;
        }
    }
}
