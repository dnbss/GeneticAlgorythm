using GeneticAlgorythm;
using GeneticAlgorythm.Crossing;
using GeneticAlgorythm.Crossing.Binary;
using GeneticAlgorythm.Crossing.Real;
using GeneticAlgorythm.Interfaces;
using GeneticAlgorythm.Mutation;
using GeneticAlgorythm.Mutation.Binary;
using GeneticAlgorythm.Mutation.Real;
using GeneticAlgorythm.Selection;
using MathParser;
using System.Text;

string expression = "f(x1,x2) = (x1-2)^4 + (x1-2*x2)^2";

Parser parser = new Parser();

parser.ConvertFunc(expression);

GeneticAlgorythm.GeneticAlgorythm algorythm = new GeneticAlgorythm.GeneticAlgorythm
    (
        new RandomMutation(0.2),
        new PointCrossing(4),
        new SimpleSelection()
    );

int countStartedPopulation = 200;

int countGeneration = 20000;

var arguments = algorythm.GetResultArguments(expression, countStartedPopulation, countGeneration);

for (int i = 0; i < arguments.Length; i++)
{
    Console.WriteLine($"{parser.ArgumentName(i)} = {arguments[i]}");
}


