
using CheckersGame.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckersGame.ViewModel
{
    class BoardVM
    {
        public ObservableCollection<Piece> pieces { get; set; }
        public BoardVM()
        {
            pieces = new ObservableCollection<Piece>();

        }
    }
}
