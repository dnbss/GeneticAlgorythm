using GeneticAlgorythm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythm.Mutation.Real
{
    public class RandomMutation : IMutation
    {
        private double _probability;

        public double ProrabilityMutation
        {
            get { return _probability; }

            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentException("Incorrect probability");
                }

                _probability = value;
            }
        }
        public RandomMutation(double probability)
        {
            ProrabilityMutation = probability;
        }
        public void Mutate(List<Chromosome> population)
        {
            int size = population[0].Size;

            Random r = new();

            foreach (var chromosome in population)
            {
                for (int i = 0; i < size; i++)
                {
                    if (ProrabilityMutation > r.NextDouble())
                    {
                        chromosome.Gens[i] += r.NextDouble() - 0.5;
                    }
                }
            }
        }
    }
}
