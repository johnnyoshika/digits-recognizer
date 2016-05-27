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

            string path = Environment.CurrentDirectory.Split(new[] { "\\bin" }, StringSplitOptions.None)[0];

            // data from: https://www.kaggle.com/c/digit-recognizer
            var trainingSet = DataReader.ReadObservations($@"{path}\Data\train.csv");
            var validation = DataReader.ReadObservations($@"{path}\Data\validation.csv");

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
