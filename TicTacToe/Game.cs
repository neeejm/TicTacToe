using System.Collections.Generic;


namespace TicTacToe
{
    class Game
    {
        public static byte diagonal = 0;
        public const byte win = 3;
        public static List<char> side = new List<char>();
        public static bool Result(List<char> boxes)
        {
            //this will check each row of TicTacToe grid
            for (int start = 0, end = 2; start <= 6; start += 3, end += 3)
            {
                var result = 0;

                if (boxes[start] == Grid.X || boxes[start] == Grid.O)
                {
                    for (var i = start; i <= end; ++i)
                        if (boxes[i] == boxes[start])
                            result++;

                    if (result == win)
                        return true;
                }
            }

            //this will check each column of TicTacToe grid
            for (int start = 0, end = 7; start <= 2; ++start, ++end)
            {
                var result = 0;

                for (var i = start; i <= end; i += 3)
                    if (boxes[i] == boxes[start])
                        result++;

                if (result == win)
                {
                    return true;
                }
            }

            //this will check each diagonal of TicTacToe grid
            for (int start = 0, end = 8; start <= 2; start += 2, end -= 2)
            {
                var result = 0;

                if (start == 0 && end == 8)
                    diagonal = 4; //first diagonal
                else
                    diagonal = 2; //second diagonal

                for (var i = start; i <= end; i += diagonal)
                    if (boxes[i] == boxes[start])
                        result++;

                if (result == win)
                    return true;
            }

            return false;
        }
        public static List<char> Side (List<char> side)
        {
            if (side[0] == 'X')
            {
                side[0] = Grid.X;
                side.Add(Grid.O);
            }
            else
            {
                side[0] = Grid.O;
                side.Add(Grid.X);
            }

            return side;
        }
    }
}
