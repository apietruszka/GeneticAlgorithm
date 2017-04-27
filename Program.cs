using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace genAlgNew
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector2[] points = new Vector2[6];
            points[0].x = 1f; points[0].y = 7f;
            points[1].x = 5f; points[1].y = -3f;
            points[2].x = 10f; points[2].y = 1f;
            points[3].x = 15f; points[3].y = 10f;
            points[4].x = 20f; points[4].y = -1f;
            points[5].x = 50f; points[5].y = 15f;

            Random rand = new Random();
            double randomizationRange = 10f;
            int numberOfElements = 200;
            double mutationPercentage = 0.05f;
            double secondsToLogAfter = 1;

            Generation generation = new Generation(rand, randomizationRange, numberOfElements);
            

            Stopwatch watch = Stopwatch.StartNew();
            /*while(true)
            {
                bool makeALog = false;
                if (watch.Elapsed.Seconds > secondsToLogAfter)
                {
                    makeALog = true;
                    watch.Restart();
                }
                generation.makeNextGeneration(rand, points, mutationPercentage, randomizationRange, makeALog);
            }*/
            while(true)
            {
                generation.makeNextGeneration(rand, points, mutationPercentage, randomizationRange, true);
                Thread.Sleep(1000);
            }
        }
    }
}
