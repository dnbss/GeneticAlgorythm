using GeneticAlgorythm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythm.Crossing.Real
{
    public class SimplestCrossing : ICrossing
    {
        public List<Chromosome> Cross(Chromosome parent1, Chromosome parent2)
        {
            List<Chromosome> parents = new();

            parents.Add(parent1);
            parents.Add(parent2);

            Random random = new Random();

            int changingIndex = random.Next(parent1.Size);

            List<Chromosome> children = new List<Chromosome>();

            for (int i = 0; i < 2; i++)
            {
                children.Add(new Chromosome(parent1.Size));

                for (int j = 0; j < changingIndex; j++)
                {
                    children[i].Gens[j] = parents[i].Gens[j];
                }

                for (int j = changingIndex; j < parent1.Size; j++)
                {
                    children[i].Gens[j] = parents[1 - i].Gens[j];
                }
            }

            return children;
        }
    }
}
