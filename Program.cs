using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitsRecognizer
{
    class Program
    {
        static void Main(string[] args)
        {
            var trainingSet = DataReader.ReadObservations(@"C:\Users\Johnny\Documents\Visual Studio 2015\Projects\DigitsRecognizer\Data\train.csv");
            var validation = DataReader.ReadObservations(@"C:\Users\Johnny\Documents\Visual Studio 2015\Projects\DigitsRecognizer\Data\validation.csv");

            var manhattanClassifier = new BasicClassifier(Distance.Manhattan);
            manhattanClassifier.Train(trainingSet);
            var manhattenCorrect = Evaluator.Correct(validation, manhattanClassifier);
            Console.WriteLine("Manhattan correctly classified: {0:P2}", manhattenCorrect);

            var euclideanClassifier = new BasicClassifier(Distance.Euclidean);
            euclideanClassifier.Train(trainingSet);
            var euclideanCorrect = Evaluator.Correct(validation, euclideanClassifier);
            Console.WriteLine("Euclidean correctly classified: {0:P2}", euclideanCorrect);

            Console.ReadLine();
        }
    }
}
