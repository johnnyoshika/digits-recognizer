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

        IEnumerable<Observation> _data;
        readonly Func<int[], int[], double> _distance;

        public BasicClassifier(Func<int[], int[], double> distance)
        {
            _distance = distance;
        }

        public void Train(IEnumerable<Observation> trainingSet)
        {
            _data = trainingSet;
        }

        public string Predict(int[] pixels)
        {
            Observation currentBest = null;
            var shortest = double.MaxValue;

            foreach (var obs in _data)
            {
                var dist = _distance(obs.Pixels, pixels);
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
