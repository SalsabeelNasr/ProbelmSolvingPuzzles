using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PuzzleThree
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write(ReverseStrings("hello world"));
            Console.ReadLine();
        }
        static string ReverseStrings(string strMyString)
        {
            string reversedString = string.Empty;
            string result = string.Empty;
            int startIndex = 0;
            int endIndex = 0;
            bool space1 = false;
            bool space2 = false;

            //reverse the whole string
            for (int i = strMyString.Length - 1; i >= 0; i--)
            {
                reversedString += strMyString[i];
            }

            //loop over the reversed string
            for (int i = reversedString.Length - 1; i >= 0; i--)
            {
                //case of first word to move
                if (i == reversedString.Length - 1)
                {
                    space1 = true;
                    endIndex = reversedString.Length - 1;

                }
                //case of last word to move
                if (i == 0)
                {
                    space2 = true;
                    startIndex = 0;
                }
                //a delemiter is found
                if (reversedString[i] == ' ')
                {
                    
                    if (space1)
                    {
                        space2 = true;
                        startIndex = i + 1;

                    }

                }
                //a word is found
                if (space1 && space2)
                {
                   
                    for (int j = startIndex; j <= endIndex; j++)
                    {
                        result += reversedString[j];
                    }
                    if (!(i == reversedString.Length - 1) && (i!=0))
                    {
                        result += ' ';
                    }
                    space1 = true;
                    space2 = false;
                    endIndex = startIndex - 2;
                }
            }

            return result;
        }
    }
}
