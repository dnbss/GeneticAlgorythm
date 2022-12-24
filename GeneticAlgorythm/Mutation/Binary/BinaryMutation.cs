using GeneticAlgorythm.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythm.Mutation.Binary
{
    public class BinaryMutation : IMutation
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
        public BinaryMutation(double probabilityMutation)
        {
            ProrabilityMutation = probabilityMutation;
        }

        public void Mutate(List<Chromosome> population)
        {
            Random random = new Random();

            for (int i = 0; i < population.Count; i++)
            {
                var bits = population[i].ToBits();

                for (int j = 0; j < population[i].Size; j++)
                {
                    if (ProrabilityMutation <= random.NextDouble())
                    {
                        continue;
                    }

                    for (int k = 0; k < 64; k++)
                    {
                        if (ProrabilityMutation > random.NextDouble())
                        {
                            bits[i] = !bits[i];
                        }
                    }
                }

                var newChromosome = new Chromosome(bits);

                if (!newChromosome.Gens.Any(gen => Double.IsNaN(gen)))
                {
                    population[i] = newChromosome;
                }
            }
        }

    }
}
