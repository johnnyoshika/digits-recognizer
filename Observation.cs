using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitsRecognizer
{
    public class Observation
    {
        public Observation(string label, int[] pixels)
        {
            Label = label;
            Pixels = pixels;
        }

        public string Label { get; }
        public int[] Pixels { get; }
    }
}
