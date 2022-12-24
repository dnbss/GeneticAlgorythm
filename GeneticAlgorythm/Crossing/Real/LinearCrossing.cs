using GeneticAlgorythm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythm.Crossing.Real
{
    public class LinearCrossing : ICrossing
    {
        public List<Chromosome> Cross(Chromosome parent1, Chromosome parent2)
        {
            var child1 = new Chromosome(parent1.Size);
            var child2 = new Chromosome(parent1.Size);
            var child3 = new Chromosome(parent1.Size);

            for (int i = 0; i < parent1.Size; i++)
            {
                child1.Gens[i] = (parent1.Gens[i] + parent2.Gens[i]) / 2;
                child2.Gens[i] = (3 * parent1.Gens[i] - parent2.Gens[i]) / 2;
                child3.Gens[i] = (-parent1.Gens[i] + 3 * parent2.Gens[i]) / 2;
            }

            var children = new List<Chromosome>();

            children.Add(child1);
            children.Add(child2);
            children.Add(child3);

            return children;
        }
    }
}
