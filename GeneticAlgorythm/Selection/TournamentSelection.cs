using GeneticAlgorythm.Interfaces;
using MathParser;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythm.Selection
{
    public class TournamentSelection : ISelection
    {
        private int _countInTournament;
        public TournamentSelection(int countInTournament = 2)
        {
            _countInTournament = countInTournament;
        }

        public List<Chromosome> Select(List<Chromosome> population, Parser parser, int numberSurvived)
        {
            List<Chromosome> result = new List<Chromosome>();

            Random random = new Random();

            for (int i = 0; i < numberSurvived; i++)
            {
                List<Chromosome> tournamentList = new List<Chromosome>();

                for (int j = 0; j < _countInTournament; j++)
                {
                    tournamentList.Add(population[random.Next(population.Count)]);
                }

                var best = tournamentList.OrderBy(chromosome => parser.Calculate(chromosome.Gens)).Take(1);

                result.AddRange(best);
            }


            return result;
        }
    }
}
