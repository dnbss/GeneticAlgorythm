using GeneticAlgorythm.Crossing.Binary;
using GeneticAlgorythm.Crossing.Real;
using GeneticAlgorythm.Interfaces;
using GeneticAlgorythm.Mutation.Binary;
using GeneticAlgorythm.Mutation.Real;
using GeneticAlgorythm.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorythmWinForm
{
    public class Presenter
    {
        private GeneticAlgorythm.GeneticAlgorythm _geneticAlgorythm;

        private ICrossing _crossover;

        private IMutation _mutator;

        private ISelection _selector;

        public Presenter(
            SelectionType selectionType,
            CrossingType crossingType, 
            MutationType mutationType,
            int numberSurvived,
            int pointCrossing,
            double probabilityMutation)
        {
            switch (crossingType)
            {
                case CrossingType.Point:
                    _crossover = new PointCrossing(pointCrossing);
                    break;
                case CrossingType.Flat:
                    _crossover = new FlatCrossing();
                    break;
                case CrossingType.Simplest:
                    _crossover = new SimplestCrossing();
                    break;
                case CrossingType.Arithmetic:
                    _crossover = new ArithmeticCrossing();
                    break;
                case CrossingType.Geometry:
                    _crossover = new GeometryCrossing();
                    break;
                case CrossingType.Linear:
                    _crossover = new LinearCrossing();
                    break;
                default:
                    break;
            }

            switch (mutationType)
            {
                case MutationType.BinaryRandom:
                    _mutator = new BinaryMutation(probabilityMutation);
                    break;
                case MutationType.RealRandom:
                    _mutator = new RandomMutation(probabilityMutation);
                    break;
                default:
                    break;
            }

            switch (selectionType)
            {
                case SelectionType.SimpleSelection:
                    _selector = new SimpleSelection();
                    break;
                case SelectionType.PanmixiaSelection:
                    _selector = new PanmixiaSelection();
                    break;
                case SelectionType.RankSelection:
                    _selector = new RankSelection();
                    break;
                case SelectionType.ToutnamentSelection:
                    _selector = new TournamentSelection(numberSurvived);
                    break;
                case SelectionType.Inbreeding:
                    _selector = new BreedingSelection(BreedingType.Inbreeding);
                    break;
                case SelectionType.Outbreeding:
                    _selector = new BreedingSelection(BreedingType.Outbreeding);
                    break;
            }

            _geneticAlgorythm = new GeneticAlgorythm.GeneticAlgorythm(
                _mutator, 
                _crossover, 
                _selector);
        }

        public double[] GetResultArguments(string expression, int countStartedPopulation, int countGenerations, int numberSurvived) 
            => _geneticAlgorythm.GetResultArguments(expression, countStartedPopulation, countGenerations, numberSurvived);

        public string[] GetNamesArguments()
            => _geneticAlgorythm.GetNamesArguments();

        public double GetResult(double[] arguments) => _geneticAlgorythm.GetResult(arguments);
    }
}
