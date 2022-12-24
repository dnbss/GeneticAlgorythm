namespace GeneticAlgorythm.Interfaces
{
    public interface ICrossing
    {
        List<Chromosome> Cross(Chromosome parent1, Chromosome parent2);
    }
}
