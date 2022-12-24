using GeneticAlgorythm.Interfaces;
using MathParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythm.Selection
{
    public class PanmixiaSelection : ISelection
    {
        public List<Chromosome> Select(List<Chromosome> population, Parser parser, int numberSurvived)
        {
            Random random = new Random();

            List<Chromosome> result = new List<Chromosome>();

            for (int i = 0; i < numberSurvived; i++)
            {
                int index = random.Next(population.Count);

                result.Add(population[index]);
            }

            return result;
        }
    }
}
