using GeneticAlgorythm.Interfaces;

namespace GeneticAlgorythm.Crossing.Real
{
    public class FlatCrossing : ICrossing
    {
        public List<Chromosome> Cross(Chromosome parent1, Chromosome parent2)
        {
            Chromosome child = new(parent1.Size);

            Random r = new();

            for (int i = 0; i < parent1.Size; i++)
            {
                double bigger = parent1.Gens[i] > parent2.Gens[i] ? parent1.Gens[i] : parent2.Gens[i];
                double smaller = parent1.Gens[i] <= parent2.Gens[i] ? parent1.Gens[i] : parent2.Gens[i];

                double childGen = r.NextDouble() * (bigger - smaller) + smaller;

                child.Gens[i] = childGen;
            }

            List<Chromosome> population = new();

            population.Add(child);

            return population;
        }
    }
}
