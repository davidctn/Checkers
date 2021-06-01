using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media.Imaging;

namespace CheckersGame.Model
{


    public class Board
    {
        private int[,] board_m;

        public Board()
        {
            board_m = new int[8, 8];
            for (int indexRow = 0; indexRow < 8; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < 8; indexColumn++)
                {
                    board_m[indexRow, indexColumn] = -1;
                }
            }
        }

       public int[,] GetBoard()
        {
            return board_m;
        }
        public bool SetState(int row, int column, int state)
        {
            if ((state > 4)
                || (state < -1))
            {
                return false;
            }
            board_m[row, column] = state;
            return true;
        }

        public int GetState(int row, int column)
        {
            if ((row > 7)
                || (row < 0)
                || (column > 7) 
                || (column < 0))
            {
                return -1;
            }
            return board_m[row, column];
        }

        public List<Move> VerifyJumps(string color)
        {
            List<Move> jumpsList = new List<Move>();

            for (int indexRow = 0; indexRow < 8; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < 8; indexColumn++)
                {
                    if (color == "Red")
                    {
                        if (GetState(indexRow, indexColumn) == 3)
                        {
                            if ((GetState(indexRow - 2, indexColumn - 2) == 0)
                                && ((GetState(indexRow - 1, indexColumn - 1) == 2) || (GetState(indexRow - 1, indexColumn - 1) == 4)))
                            {
                                jumpsList.Add(new Move(new Piece(indexRow + 1, indexColumn), new Piece(indexRow - 1, indexColumn - 2)));
                            }

                            if ((GetState(indexRow - 2, indexColumn + 2) == 0) 
                                && ((GetState(indexRow - 1, indexColumn + 1) == 2) || (GetState(indexRow - 1, indexColumn + 1) == 4)))
                            {
                                jumpsList.Add(new Move(new Piece(indexRow + 1, indexColumn), new Piece(indexRow - 1, indexColumn + 2)));
                            }

                            if ((GetState(indexRow + 2, indexColumn - 2) == 0) 
                                && ((GetState(indexRow + 1, indexColumn - 1) == 2) || (GetState(indexRow + 1, indexColumn - 1) == 4)))
                            {
                                jumpsList.Add(new Move(new Piece(indexRow + 1, indexColumn), new Piece(indexRow + 3, indexColumn - 2)));
                            }

                            if ((GetState(indexRow + 2, indexColumn + 2) == 0)
                                && ((GetState(indexRow + 1, indexColumn + 1) == 2) || (GetState(indexRow + 1, indexColumn + 1) == 4)))
                            {
                                jumpsList.Add(new Move(new Piece(indexRow + 1, indexColumn), new Piece(indexRow + 3, indexColumn + 2)));
                            }
                        }

                        if (GetState(indexRow, indexColumn) == 1)
                        {
                            if ((GetState(indexRow + 2, indexColumn - 2) == 0) 
                                && ((GetState(indexRow + 1, indexColumn - 1) == 2) || (GetState(indexRow + 1, indexColumn - 1) == 4)))
                            {
                                jumpsList.Add(new Move(new Piece(indexRow + 1, indexColumn), new Piece(indexRow + 3, indexColumn - 2)));
                            }

                            if ((GetState(indexRow + 2, indexColumn + 2) == 0)
                                && ((GetState(indexRow + 1, indexColumn + 1) == 2) || (GetState(indexRow + 1, indexColumn + 1) == 4)))
                            {
                                jumpsList.Add(new Move(new Piece(indexRow + 1, indexColumn), new Piece(indexRow + 3, indexColumn + 2)));
                            }
                        }
                    }

                    if (color == "Black")
                    {
                        if (GetState(indexRow, indexColumn) == 4)
                        {
                            if ((GetState(indexRow - 2, indexColumn - 2) == 0) 
                                && ((GetState(indexRow - 1, indexColumn - 1) == 1) || (GetState(indexRow - 1, indexColumn - 1) == 3)))
                            {
                                jumpsList.Add(new Move(new Piece(indexRow + 1, indexColumn), new Piece(indexRow - 1, indexColumn - 2)));
                            }

                            if ((GetState(indexRow - 2, indexColumn + 2) == 0) 
                                && ((GetState(indexRow - 1, indexColumn + 1) == 1) || (GetState(indexRow - 1, indexColumn + 1) == 3)))
                            {
                                jumpsList.Add(new Move(new Piece(indexRow + 1, indexColumn), new Piece(indexRow - 1, indexColumn + 2)));
                            }

                            if ((GetState(indexRow + 2, indexColumn - 2) == 0)
                                && ((GetState(indexRow + 1, indexColumn - 1) == 1) || (GetState(indexRow + 1, indexColumn - 1) == 3)))
                            {
                                jumpsList.Add(new Move(new Piece(indexRow + 1, indexColumn), new Piece(indexRow + 3, indexColumn - 2)));
                            }

                            if ((GetState(indexRow + 2, indexColumn + 2) == 0)
                                && ((GetState(indexRow + 1, indexColumn + 1) == 1) || (GetState(indexRow + 1, indexColumn + 1) == 3)))
                            {
                                jumpsList.Add(new Move(new Piece(indexRow + 1, indexColumn), new Piece(indexRow + 3, indexColumn + 2)));
                            }
                        }
                        if (GetState(indexRow, indexColumn) == 2)
                        {
                            if ((GetState(indexRow - 2, indexColumn - 2) == 0)
                                && ((GetState(indexRow - 1, indexColumn - 1) == 1) || (GetState(indexRow - 1, indexColumn - 1) == 3)))
                            {
                                jumpsList.Add(new Move(new Piece(indexRow + 1, indexColumn), new Piece(indexRow - 1, indexColumn - 2)));
                            }

                            if ((GetState(indexRow - 2, indexColumn + 2) == 0) 
                                && ((GetState(indexRow - 1, indexColumn + 1) == 1) || (GetState(indexRow - 1, indexColumn + 1) == 3)))
                            {
                                jumpsList.Add(new Move(new Piece(indexRow + 1, indexColumn), new Piece(indexRow - 1, indexColumn + 2)));
                            }
                        }
                    }
                }
            }
            return jumpsList;
        }
    }

}


