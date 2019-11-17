using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Grid
    {
        public const byte size = 9;
        public const char O = 'O';
        public const char X = 'X';
        public static void Reset (List<char> boxes)
        {
            //reset the given list to {1 , 2 , ... , 9}
            int tmp = 48; //0 --> 48(ASCII)
            boxes.Clear();

            for (var i = 0; i < size; ++i)
            {
                tmp += 1;
                boxes.Add(Convert.ToChar(tmp));
            }
        }

        public static void Table (List<char> boxes)
        {
            Console.WriteLine("\n       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", boxes[0], boxes[1], boxes[2]);
            Console.WriteLine("_______|_______|_______");
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", boxes[3], boxes[4], boxes[5]);
            Console.WriteLine("_______|_______|_______");
            Console.WriteLine("       |       |       ");
            Console.WriteLine("   {0}   |   {1}   |   {2}   ", boxes[6], boxes[7], boxes[8]);
            Console.WriteLine("       |       |       \n");
        }

        public static bool Valid (List<char> boxes, int index)
        {
            if (index < size && index >= 0)
            {
                //Console.WriteLine("test");
                if (boxes[index] == X || boxes[index] == O)
                    return false;
                else
                    return true;
            }
            else
                return false;

        }
    }
}
