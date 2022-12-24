using GeneticAlgorythm;
using GeneticAlgorythm.Crossing;
using GeneticAlgorythm.Mutation;
using GeneticAlgorythm.Selection;
using MathParser;

namespace GeneticAlgorytmTest
{
    [TestClass]
    public class GeneticAlgorythmTests
    {
        [TestMethod]
        public void GetResult_Test()
        {
            string expression = "8*(x1)^2+4*x1*x2+5*(x2)^2";

            Parser parser = new Parser();

            parser.ConvertFunc(expression);

            GeneticAlgorythm.GeneticAlgorythm algorythm = new GeneticAlgorythm.GeneticAlgorythm
                (
                    new RandomMutation(),
                    new FlatCrossing(),
                    new SimpleSelection()
                );

            int countStartedPopulation = 5;

            int countGeneration = 10;

            double actual = algorythm.GetResult(expression, countStartedPopulation, countGeneration);
            double expected = 0;

            Assert.AreEqual(expected, actual);
        }
    }
}