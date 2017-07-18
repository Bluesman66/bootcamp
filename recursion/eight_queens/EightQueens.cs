using System;

namespace eight_queens
{
    class EightQueens
    {
        private static int[,] _board;
        private int _numQueens;

        public EightQueens()
        {
            _numQueens = 0;
            _board = new int[8, 8];

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    _board[i, j] = 0;
                }
            }
        }

        public bool Solve(int numQueens)
        {            
            if (numQueens == 8)
            {
                PrintBoard();
                return true;
            }
            else
            {
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (ValidMove(i, j))
                        {
                            PlaceQueen(i, j, true);
                            numQueens++;
                            if (Solve(numQueens))                            
                                return true;                            
                            else
                            {
                                PlaceQueen(i, j, false);
                                numQueens--;
                            }
                        }
                    }
                }
            }
            return false;
        }

        public bool ValidMove(int x, int y)
        {
            for (int k = 0; k < 8; k++)
            {
                if (this[x, k])
                    return false;

                if (this[k, y])
                    return false;

                if (this[x - k, y - k])
                    return false;

                if (this[x - k, y + k])
                    return false;

                if (this[x + k, y - k])
                    return false;

                if (this[x + k, y + k])
                    return false;
            }
            return true;
        }

        public int PlaceQueen(int x, int y, bool validMove)
        {
            if (validMove)
            {
                _board[x, y] = 1;
                _numQueens++;
                return 0;
            }
            else
            {
                _board[x, y] = 0;
                return 0;
            }            
        }

        public bool this[int x, int y]
        {
            get
            {
                if (x < 0 || x > 7 || y < 0 || y > 7)                
                    return false;                    
                if (_board[x, y] == 1)
                    return true;
                return false;
            }
        }

        public void PrintBoard()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(_board[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var board = new EightQueens();
            board.Solve(0);
        }
    }
}
