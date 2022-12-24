using GeneticAlgorythm.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythm.Crossing.Binary
{
    public class PointCrossing : ICrossing
    {
        public readonly int CountPoints;
        public PointCrossing(int countPoints = 1)
        {
            CountPoints = countPoints;
        }

        public List<Chromosome> Cross(Chromosome parent1, Chromosome parent2)
        {
            Random random = new Random();

            int lengthInBits = parent1.Size * 8 * 8;

            var children = new List<Chromosome>();

            var points = new List<int>();

            do
            {
                points.Clear();

                for (int i = 0; i < CountPoints; i++)
                {
                    points.Add(random.Next(lengthInBits));
                }

                if (CountPoints % 2 == 1)
                {
                    points.Add(0);
                }

                points.Sort();

                var parent1Bits = parent1.ToBits();

                var parent2Bits = parent2.ToBits();

                for (int i = 0; i < points.Count - 1; i += 2)
                {
                    for (int j = points[i]; j < points[i + 1]; j++)
                    {
                        var temp = parent1Bits[j];

                        parent1Bits[j] = parent2Bits[j];

                        parent2Bits[j] = temp;
                    }
                }

                children.Clear();

                children.Add(new Chromosome(parent1Bits));

                children.Add(new Chromosome(parent2Bits));

            } while (!IsNormalGens(children));

            return children;
        }

        private bool IsNormalGens(List<Chromosome> population)
            => population.All(chromosome => chromosome.Gens.All(gen => Double.IsNormal(gen)));
    }
}
