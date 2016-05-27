using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitsRecognizer
{
    public static class Distance
    {
        public static double Manhattan(int[] pixels1, int[] pixels2)
        {
            if (pixels1.Length != pixels2.Length)
                throw new ArgumentException("Inconsistent image sizes.");

            var distance = 0;
            for (int i = 0; i < pixels1.Length; i++)
                distance += Math.Abs(pixels1[i] - pixels2[i]);

            return distance;
        }

        public static double Euclidean(int[] pixels1, int[] pixels2)
        {
            if (pixels1.Length != pixels2.Length)
                throw new ArgumentException("Inconsistent image sizes.");

            var distance = 0.0;
            for (int i = 0; i < pixels1.Length; i++)
                distance += Math.Pow(pixels1[i] - pixels2[i], 2);

            // to speed things up, we can do without this square root, as it won't change rank.
            return Math.Sqrt(distance);
        }
    }


}
