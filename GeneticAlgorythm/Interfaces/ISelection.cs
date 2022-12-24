using MathParser;

namespace GeneticAlgorythm.Interfaces
{
    public interface ISelection
    {
        List<Chromosome> Select(List<Chromosome> population, Parser parser, int numberSurvived);
    }
}
