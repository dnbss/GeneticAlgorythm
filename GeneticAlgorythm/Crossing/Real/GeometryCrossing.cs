using GeneticAlgorythm.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythm.Crossing.Real
{
    public class GeometryCrossing : ICrossing
    {
        
        public List<Chromosome> Cross(Chromosome parent1, Chromosome parent2)
        {
            Random random = new Random();

            double n = random.NextDouble();

            List<Chromosome> parents = new();

            parents.Add(parent1);
            parents.Add(parent2);

            List<Chromosome> children = new();

            for (int i = 0; i < parents.Count; i++)
            {
                children.Add(new Chromosome(parent1.Size));

                for (int j = 0; j < children[i].Size; j++)
                {
                    children[i].Gens[j] = Math.Pow(Math.Abs(parents[i].Gens[j]), n) 
                        * Math.Pow(Math.Abs(parents[1 - i].Gens[j]), (1 - n));
                }
            }

            return children;
        }
    }
}
