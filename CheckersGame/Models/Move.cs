using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGame.Model
{
    public class Move
    {
        public Piece piece1 { get; set; }
        public Piece piece2 { get; set; }

        public Move()
        {
            this.piece1 = null;
            this.piece2 = null;
        }

        public Move(Piece piece1, Piece piece2)
        {
            this.piece1 = piece1;
            this.piece2 = piece2;
        }

        public bool isAdjacent(string color)
        {
            switch (color)
            {
                case "Black":
                    {
                        if ((piece1.Row - 1 == piece2.Row)
                            && (piece1.Column - 1 == piece2.Column))
                        {
                            return true;
                        }

                        if ((piece1.Row - 1 == piece2.Row)
                            && (piece1.Column + 1 == piece2.Column))
                        {
                            return true;
                        }
                    }
                    break;

                case "Red":
                    {
                        if ((piece1.Row + 1 == piece2.Row)
                            && (piece1.Column - 1 == piece2.Column))
                        {
                            return true;
                        }

                        if ((piece1.Row + 1 == piece2.Row)
                            && (piece1.Column + 1 == piece2.Column))
                        {
                            return true;
                        }
                    }
                    break;

                case "King":
                    {
                        if ((piece1.Row - 1 == piece2.Row)
                            && (piece1.Column - 1 == piece2.Column))
                        {
                            return true;
                        }

                        if ((piece1.Row - 1 == piece2.Row)
                            && (piece1.Column + 1 == piece2.Column))
                        {
                            return true;
                        }

                        if ((piece1.Row + 1 == piece2.Row)
                            && (piece1.Column - 1 == piece2.Column))
                        {
                            return true;
                        }

                        if ((piece1.Row + 1 == piece2.Row)
                            && (piece1.Column + 1 == piece2.Column))
                        {
                            return true;
                        }
                    }
                    break;

                default:
                    {
                        return false;
                    }
            }
            return false;
        }

        public Piece VerifyJump(string color)
        {
            if (color == "Black")
            {
                if ((piece1.Row - 2 == piece2.Row)
                && (piece1.Column - 2 == piece2.Column))
                {
                    return new Piece(piece1.Row - 1, piece1.Column - 1);

                }

                if ((piece1.Row - 2 == piece2.Row)
                    && (piece1.Column + 2 == piece2.Column))
                {
                    return new Piece(piece1.Row - 1, piece1.Column + 1);
                }

            }

            if (color == "Red")
            {

                if ((piece1.Row + 2 == piece2.Row)
                && (piece1.Column - 2 == piece2.Column))
                {
                    return new Piece(piece1.Row + 1, piece1.Column - 1);
                }

                if ((piece1.Row + 2 == piece2.Row)
                && (piece1.Column + 2 == piece2.Column))
                {
                    return new Piece(piece1.Row + 1, piece1.Column + 1);
                }
            }

            if (color == "King")
            {
                    if ((piece1.Row - 2 == piece2.Row)
                        && (piece1.Column - 2 == piece2.Column))
                    {
                        return new Piece(piece1.Row - 1, piece1.Column - 1);
                    }
                    if ((piece1.Row - 2 == piece2.Row)
                        && (piece1.Column + 2 == piece2.Column))
                    {
                        return new Piece(piece1.Row - 1, piece1.Column + 1);
                    }
                    if ((piece1.Row + 2 == piece2.Row)
                        && (piece1.Column - 2 == piece2.Column))
                    {
                        return new Piece(piece1.Row + 1, piece1.Column - 1);
                    }
                    if ((piece1.Row + 2 == piece2.Row)
                        && (piece1.Column + 2 == piece2.Column))
                    {
                        return new Piece(piece1.Row + 1, piece1.Column + 1);
                    }
            }
            
                return null;
        }

            public bool IsEqual(System.Object obj)
            {
                if (obj == null)
                {
                    return false;
                }
                Move move = obj as Move;
                if ((System.Object)move == null)
                {
                    return false;
                }

                return piece1.IsEqual(move.piece1) && piece2.IsEqual(move.piece2);
            }
        }
    }



