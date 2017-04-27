using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genAlgNew
{
    public struct Vector2
    {
        public double x, y;
    }
    class Element
    {
        const int numberOfArgs = 10;
        public double[] arguments;
        public double rating;

        public Element(Random rand, double randomizationRange)
        {
            //default constructor: creates a new, totally randomized element
            arguments = new double[numberOfArgs];
            for (int i = 0; i < numberOfArgs; i++)
                arguments[i] = (rand.NextDouble() - 0.5f) * 2f * randomizationRange;
        }

        public Element(Random rand, Element parent1, Element parent2)
        {
            //make new element based on the two parent elements. Toss a coin, copy from first if tails..
            arguments = new double[numberOfArgs];
            for (int i = 0; i < numberOfArgs; i++)
                arguments[i] = (rand.Next(2) == 0) ? parent1.arguments[i] : parent2.arguments[i];
        }

        public void mutate(Random rand, double randomizationRange)
        {
            arguments[rand.Next(10)] = (rand.NextDouble() - 0.5f) * 2f * randomizationRange;
        }

        public void rate(Vector2[] points)
        {
            rating = 0;
            foreach (Vector2 point in points)
            {
                double buff = point.y - valueIn(point.x);
                rating += buff * buff;
            }
        }

        public double valueIn(double x)
        {
            double toReturn = 0;
            for (int i = 0; i < 9; i += 3)
                toReturn += arguments[i] * Math.Sin(x * arguments[i + 1] + arguments[i + 2]);
            return toReturn + arguments[9];
        }

        public void makeALog()
        {
            for (int i = 0; i < numberOfArgs; i++)
                Console.WriteLine("Arg " + i + ": " + arguments[i] + "  ");
        }
    }
}
