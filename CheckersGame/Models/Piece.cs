using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGame
{
   public class Piece
    {
        public Piece(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
        public int Row { get; set; }
        public int Column { get; set; }

        public bool IsEqual(System.Object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Piece piece = obj as Piece;

            if ((System.Object)piece == null)
            {
                return false;
            }

            return Row == piece.Row && Column == piece.Column;
        }
    }
}

