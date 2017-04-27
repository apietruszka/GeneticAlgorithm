using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace genAlgNew
{
    class Generation
    {
        Element[] elements;
        int generationNumber = 0;

        public Generation(Random rand, double randomizationRange, int numberOfElements)
        {
            //this solution is ok for now, but converting to array is probably expensive. Better to make void constr for Element and setRand void for Elemenet seperately
            List<Element> elementList = new List<Element>();
            for(int i=0; i<numberOfElements;i++)
                elementList.Add(new Element(rand, randomizationRange));
            elements = elementList.ToArray();
        }

        public void makeNextGeneration(Random rand, Vector2[] points, double howManyPercentToMutate, double mutationRandomizationRange, bool doLog)
        {
            generationNumber++;
            //rate
            foreach (Element e in elements)
                e.rate(points);

            //sort
            elements = elements.OrderBy(n => n.rating).ToArray();

            if(doLog)
                makeALog();

            //replace the worse half with new
            int j = 0;
            for(int i=elements.Length/2; i<elements.Length; i++)
            {
                elements[i] = new Element(rand, elements[j], elements[rand.Next(elements.Length / 2)]);
                j++;
            }

            //mutate some elements
            for(int i=0; i<elements.Length*howManyPercentToMutate; i++)
            {
                elements[rand.Next(elements.Length)].mutate(rand, mutationRandomizationRange);
            }
        }
        
        public void makeALog()
        {
            Console.WriteLine("Generation: " + generationNumber + "\n");
            Console.WriteLine("Best element(rating: " + elements[0].rating+")");
            elements[0].makeALog();
            Console.WriteLine("\n");
        }

        public void logAllElements()
        {
            for (int i = 0; i < elements.Length; i++)
            {
                Console.WriteLine("Element " + i + "(rating: " + elements[i].rating + ") ");
                elements[i].makeALog();
            }
        }
    }
}
