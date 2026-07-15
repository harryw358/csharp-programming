using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalNumberOfFencePanels
{
    class Program
    {
        static void Main(string[] args)
        {
            double panelsForWidth, fractionalPanelsForWidth, panelsForLength, fractionalPanelsForLength, fenceWidth, gardenLength, gardenWidth, totalNumberOfWholeFencePanels;
            int wholePanelsForWidth, wholePanelsForLength;

            Console.WriteLine("What's the fence width? ");
            fenceWidth = double.Parse(Console.ReadLine());
            Console.WriteLine("What's the garden width? ");
            gardenWidth = double.Parse(Console.ReadLine());
            Console.WriteLine("What's the garden length? ");
            gardenLength = double.Parse(Console.ReadLine());

            panelsForWidth = gardenWidth / fenceWidth;
            wholePanelsForWidth = (int)panelsForWidth;
            fractionalPanelsForWidth = panelsForWidth - wholePanelsForWidth;

            panelsForLength = gardenLength / fenceWidth;
            wholePanelsForLength = (int)panelsForLength;
            fractionalPanelsForLength = panelsForLength - wholePanelsForLength;

            totalNumberOfWholeFencePanels = wholePanelsForWidth + wholePanelsForLength;

            Console.WriteLine("You will need " + wholePanelsForWidth + " whole panels for the width of the garden, " + wholePanelsForLength + " whole panels for the length of the garden, and " + totalNumberOfWholeFencePanels + " whole fence panels in total");
            Console.WriteLine("However, you will still need " + fractionalPanelsForWidth + " of a panel to complete the width, and " + fractionalPanelsForLength + " of a panel to complete the length");

            Console.ReadKey();
            
        }
    }
}
