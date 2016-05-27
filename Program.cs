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
            var distance = new ManhattanDistance();
            var classifier = new BasicClassifier(distance);

            var trainingSet = DataReader.ReadObservations(@"C:\Users\Johnny\Documents\Visual Studio 2015\Projects\DigitsRecognizer\Data\train.csv");
            classifier.Train(trainingSet);

            var validation = DataReader.ReadObservations(@"C:\Users\Johnny\Documents\Visual Studio 2015\Projects\DigitsRecognizer\Data\validation.csv");

            var correct = Evaluator.Correct(validation, classifier);
            Console.WriteLine("Correctly classified: {0:P2}", correct);
            Console.ReadLine();
        }
    }
}
