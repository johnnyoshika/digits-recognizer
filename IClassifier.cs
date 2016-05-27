using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitsRecognizer
{
    public interface IClassifier
    {
        void Train(IEnumerable<Observation> trainingSet);
        string Predict(int[] pixels);
    }

    public class BasicClassifier : IClassifier
    {

        public BasicClassifier(IDistance distance)
        {
            Distance = distance;
        }

        IEnumerable<Observation> Data { get; set; }
        IDistance Distance { get; }

        public void Train(IEnumerable<Observation> trainingSet)
        {
            Data = trainingSet;
        }

        public string Predict(int[] pixels)
        {
            Observation currentBest = null;
            var shortest = double.MaxValue;

            foreach (var obs in Data)
            {
                var dist = Distance.Between(obs.Pixels, pixels);
                if (dist < shortest)
                {
                    shortest = dist;
                    currentBest = obs;
                }
            }

            return currentBest.Label;
        }

    }
}
