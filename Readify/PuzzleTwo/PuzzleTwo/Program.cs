using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleTwo
{
    class Program
    {
        static void Main(string[] args)
        {

            
            Console.WriteLine(CheckTriangleType(5, 5, 5));
            Console.WriteLine(CheckTriangleType(5, 5, 4));
            Console.WriteLine(CheckTriangleType(5, 6, 7));
            Console.WriteLine(CheckTriangleType(0, 5, 2));
            Console.WriteLine(CheckTriangleType(6, 5, 200));
            Console.ReadLine();
        }
        public static string CheckTriangleType(int iSide1, int iSide2, int iSide3)
        {
            if (iSide1 < 1 || iSide2 < 1 || iSide3 < 1)
                return "Error";

            else if (iSide1 + iSide2 < iSide3 || iSide1 + iSide3 < iSide2 || iSide2 + iSide3 < iSide1)
                return "Error";

            else if (iSide1 == iSide2 && iSide2 == iSide3)
                return "Equilateral";

            else if (iSide1 == iSide2 || iSide1 == iSide3 || iSide2 == iSide3)
                return "Isosceles";

            else
                return "Scalene";
        }
       
       
    }
}
   
   

