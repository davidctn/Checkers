using CheckersGame;
using CheckersGame.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace Checkers
{
    public partial class PlayWindow : Window
    {
        private Move currentMove_m;
        private string winner_m;
        private string turn_m;
        Board myBoard;

        public PlayWindow()
        {
            InitializeComponent();
            myBoard = new Board();
            this.Title = "Blacks turn!";
            turn_m = "Black";
            currentMove_m = null;
            winner_m = null;
            CreateBoard();
        }
        //=============================================================
        public void SaveState()
        {
            Board current = GetCurrentBoard();
            File.WriteAllText(@"C:\Users\David\source\repos\CheckersGame\CheckersGame\TextFiles\SavedState.txt", String.Empty);
            using (TextWriter textWriter = new StreamWriter(@"C:\Users\David\source\repos\CheckersGame\CheckersGame\TextFiles\SavedState.txt"))
            {
                for (int indexRow = 0; indexRow < 8; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < 8; indexColumn++)
                    {
                        textWriter.Write(current.GetBoard()[indexRow,indexColumn] + " ");
                    }
                    textWriter.WriteLine();
                }
                textWriter.Close();
            }
        }

        public void LoadState(string path)
        {
            path = @"C:\Users\David\source\repos\CheckersGame\CheckersGame\TextFiles\SavedState.txt";
            StreamReader reader = new StreamReader(path);

            for (int indexRow = 0; indexRow < 8; indexRow++)
            {
                string line;
                string[] splittedLine;
                line = reader.ReadLine();
                splittedLine = line.Split(' ');

                for (int indexColumn = 0; indexColumn < 8; indexColumn++)
                {
                    myBoard.GetBoard()[indexRow, indexColumn] = int.Parse(splittedLine[indexColumn]);
                }
            }
            ClearBoard();
            var redBrush = new ImageBrush();
            redBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\David\source\repos\CheckersGame\CheckersGame\Images\rp.png", UriKind.Relative));
            var blackBrush = new ImageBrush();
            blackBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\David\source\repos\CheckersGame\CheckersGame\Images\bp.png", UriKind.Relative));
            var redKingBrush = new ImageBrush();
            redKingBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\David\source\repos\CheckersGame\CheckersGame\Images\rpk.png", UriKind.Relative));
            var blackKingBrush = new ImageBrush();
            blackKingBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\David\source\repos\CheckersGame\CheckersGame\Images\bpk.png", UriKind.Relative));
            for (int indexRow = 1; indexRow < 9; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < 8; indexColumn++)
                {
                    StackPanel stackPanel = new StackPanel();

                    if (indexRow % 2 == 1)
                    {
                        if (indexColumn % 2 == 0)
                        {
                            stackPanel.Background = Brushes.DarkTurquoise;
                        }

                        else
                        {
                            stackPanel.Background = Brushes.BlueViolet;
                        }
                    }

                    else
                    {
                        if (indexColumn % 2 == 0)
                        {
                            stackPanel.Background = Brushes.BlueViolet;
                        }

                        else
                        {
                            stackPanel.Background = Brushes.DarkTurquoise;
                        }
                    }

                    Grid.SetRow(stackPanel, indexRow);
                    Grid.SetColumn(stackPanel, indexColumn);
                    MyGrid.Children.Add(stackPanel);
                }

            }

            for (int indexRow = 1; indexRow < 9; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < 8; indexColumn++)
                {


                    if (indexRow % 2 == 1
                      && indexColumn % 2 == 1)
                    {
                        StackPanel stackPanel = (StackPanel)GetUIElementFromGrid(MyGrid, indexRow, indexColumn);
                        Button current = new Button();
                        current.Click += new RoutedEventHandler(ButtonClick);
                        current.Height = 60;
                        current.Width = 60;
                        current.HorizontalAlignment = HorizontalAlignment.Center;
                        current.VerticalAlignment = VerticalAlignment.Center;
                        Console.Write(myBoard.GetState(indexRow - 1, indexColumn) + " ");
                        Console.WriteLine("");
                        switch (myBoard.GetState(indexRow - 1, indexColumn))
                        {
                            case 0:
                                current.Background = Brushes.BlueViolet;
                                current.Name = "button" + indexRow + indexColumn;
                                stackPanel.Children.Add(current);
                                break;

                            case 1:
                                current.Background = redBrush;
                                current.Name = "buttonRed" + indexRow + indexColumn;
                                stackPanel.Children.Add(current);
                                break;

                            case 2:
                                current.Background = blackBrush;
                                current.Name = "buttonBlack" + indexRow + indexColumn;
                                stackPanel.Children.Add(current);
                                break;

                            case 3:
                                current.Background = redKingBrush;
                                current.Name = "buttonRedKing" + indexRow + indexColumn;
                                stackPanel.Children.Add(current);
                                break;

                            case 4:
                                current.Background = blackKingBrush;
                                current.Name = "buttonBlackKing" + indexRow + indexColumn;
                                stackPanel.Children.Add(current);
                                break;

                            default:
                                break;
                        }
                    }
                    else
                    {
                        StackPanel stackPanel = (StackPanel)GetUIElementFromGrid(MyGrid, indexRow, indexColumn);
                        Button current = new Button();
                        current.Click += new RoutedEventHandler(ButtonClick);
                        current.Height = 60;
                        current.Width = 60;
                        current.HorizontalAlignment = HorizontalAlignment.Center;
                        current.VerticalAlignment = VerticalAlignment.Center;
                        if (indexRow % 2 == 0
                      && indexColumn % 2 == 0)
                        {
                            switch (myBoard.GetState(indexRow - 1, indexColumn))
                            {
                                case 0:
                                    current.Background = Brushes.BlueViolet;
                                    current.Name = "button" + indexRow + indexColumn;
                                    stackPanel.Children.Add(current);
                                    break;

                                case 1:
                                    current.Background = redBrush;
                                    current.Name = "buttonRed" + indexRow + indexColumn;
                                    stackPanel.Children.Add(current);
                                    break;

                                case 2:
                                    current.Background = blackBrush;
                                    current.Name = "buttonBlack" + indexRow + indexColumn;
                                    stackPanel.Children.Add(current);
                                    break;

                                case 3:
                                    current.Background = redKingBrush;
                                    current.Name = "buttonRedKing" + indexRow + indexColumn;
                                    stackPanel.Children.Add(current);
                                    break;

                                case 4:
                                    current.Background = blackKingBrush;
                                    current.Name = "buttonBlackKing" + indexRow + indexColumn;
                                    stackPanel.Children.Add(current);
                                    break;

                                default:
                                    break;
                            }
                        }
                    }

                }
            }
        }

        private void UpdateHistory(string winnerColor)
        {
            string path = @"C:\Users\David\source\repos\CheckersGame\CheckersGame\TextFiles\History.txt";
            StreamReader reader = new StreamReader(path);
            string line1, line2;
            string[] splittedLine1, splittedLine2;
            line1 = reader.ReadLine();
            splittedLine1 = line1.Split(' ');
            line2 = reader.ReadLine();
            splittedLine2 = line2.Split(' ');
            if (splittedLine1[0] == winnerColor)
            {
                int newValue = int.Parse(splittedLine1[1]);
                newValue++;
                splittedLine1[1] = newValue.ToString();
            }

            else
            {
                int newValue = int.Parse(splittedLine2[1]);
                newValue++;
                splittedLine2[1] = newValue.ToString();
            }
            reader.Close();
            File.WriteAllText(path, String.Empty);
            using (TextWriter historyWriter = new StreamWriter(path))
            {
                historyWriter.Write(splittedLine1[0] + " " + splittedLine1[1]);
                historyWriter.WriteLine();
                historyWriter.Write(splittedLine2[0] + " " + splittedLine2[1]);
                historyWriter.Close();
            }
        }

        //=============================================================
        private void VerifyGame()
        {
            int numberOfBP = 0, numberOfRP = 0;
            for (int indexRow = 1; indexRow < 9; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < 8; indexColumn++)
                {
                    StackPanel stackPanel = (StackPanel)GetUIElementFromGrid(MyGrid, indexRow, indexColumn);
                    if (stackPanel.Children.Count > 0)
                    {
                        Button button = (Button)stackPanel.Children[0];
                        if (button.Name.Contains("Red"))
                            numberOfRP++;
                        if (button.Name.Contains("Black"))
                            numberOfBP++;
                    }
                }
            }

            if (numberOfBP == 0)
            {
                winner_m = "Red";
                UpdateHistory(winner_m);
            }

            if (numberOfRP == 0)
            {
                winner_m = "Black";
                UpdateHistory(winner_m);
            }

            if (winner_m != null)
            {
                for (int indexRow = 1; indexRow < 9; indexRow++)
                {
                    for (int indexColumn = 0; indexColumn < 8; indexColumn++)
                    {
                        StackPanel stackPanel = (StackPanel)GetUIElementFromGrid(MyGrid, indexRow, indexColumn);
                        if (stackPanel.Children.Count > 0)
                        {
                            Button button = (Button)stackPanel.Children[0];
                            button.Click -= new RoutedEventHandler(ButtonClick);
                        }
                    }
                }

                MessageBoxResult result = MessageBox.Show(winner_m + " Wins the game ! Would you like to play another game ?", "Winner", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    StartNewGame();
                }
            }
        }

        private void StartNewGame()
        {
            this.Title = "Blacks turn!";
            turn_m = "Black";
            currentMove_m = null;
            winner_m = null;
            ClearBoard();
            CreateBoard();
        }

        private void CreateBoard()
        {
            for (int indexRow = 1; indexRow < 9; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < 8; indexColumn++)
                {
                    StackPanel stackPanel = new StackPanel();
                    if (indexRow % 2 == 1)
                    {
                        if (indexColumn % 2 == 0)
                        {
                            stackPanel.Background = Brushes.DarkTurquoise;
                        }

                        else
                        {
                            stackPanel.Background = Brushes.BlueViolet;
                        }
                    }

                    else
                    {
                        if (indexColumn % 2 == 0)
                        {
                            stackPanel.Background = Brushes.BlueViolet;
                        }

                        else
                        {
                            stackPanel.Background = Brushes.DarkTurquoise;
                        }
                    }

                    Grid.SetRow(stackPanel, indexRow);
                    Grid.SetColumn(stackPanel, indexColumn);
                    MyGrid.Children.Add(stackPanel);
                }
            }

            CreateButtons();
        }

        private Board GetCurrentBoard()
        {
            Board board = new Board();
            for (int indexRow = 1; indexRow < 9; indexRow++)
            {
                for (int indexcolumn = 0; indexcolumn < 8; indexcolumn++)
                {
                    StackPanel stackPanel = (StackPanel)GetUIElementFromGrid(MyGrid, indexRow, indexcolumn);
                    if (stackPanel.Children.Count > 0)
                    {
                        Button current = (Button)stackPanel.Children[0];
                        if (current.Name.Contains("Red"))
                        {
                            if (current.Name.Contains("King"))
                            {
                                board.SetState(indexRow - 1, indexcolumn, 3);
                            }

                            else
                            {
                                board.SetState(indexRow - 1, indexcolumn, 1);
                            }
                        }

                        else if (current.Name.Contains("Black"))
                        {
                            if (current.Name.Contains("King"))
                            {
                                board.SetState(indexRow - 1, indexcolumn, 4);
                            }

                            else
                            {
                                board.SetState(indexRow - 1, indexcolumn, 2);
                            }
                        }

                        else
                            board.SetState(indexRow - 1, indexcolumn, 0);
                    }

                    else
                    {
                        board.SetState(indexRow - 1, indexcolumn, -1);
                    }
                }
            }
            return board;
        }

        private void ClearBoard()
        {
            for (int indexRow = 1; indexRow < 9; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < 8; indexColumn++)
                {
                    StackPanel stackPanel = (StackPanel)GetUIElementFromGrid(MyGrid, indexRow, indexColumn);
                    MyGrid.Children.Remove(stackPanel);
                }
            }
        }

        private void CreateButtons()
        {
            for (int indexRow = 1; indexRow < 9; indexRow++)
            {
                for (int indexColumn = 0; indexColumn < 8; indexColumn++)
                {
                    StackPanel stackPanel = (StackPanel)GetUIElementFromGrid(MyGrid, indexRow, indexColumn);
                    Button current = new Button();
                    current.Click += new RoutedEventHandler(ButtonClick);
                    current.Height = 60;
                    current.Width = 60;
                    current.HorizontalAlignment = HorizontalAlignment.Center;
                    current.VerticalAlignment = VerticalAlignment.Center;
                    var redBrush = new ImageBrush();
                    redBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\David\source\repos\CheckersGame\CheckersGame\Images\rp.png", UriKind.Relative));
                    var blackBrush = new ImageBrush();
                    blackBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\David\source\repos\CheckersGame\CheckersGame\Images\bp.png", UriKind.Relative));
                    switch (indexRow)
                    {
                        case 1:
                            if (indexColumn % 2 == 1)
                            {

                                current.Background = redBrush;
                                current.Name = "buttonRed" + indexRow + indexColumn;
                                stackPanel.Children.Add(current);
                            }
                            break;

                        case 2:
                            if (indexColumn % 2 == 0)
                            {
                                current.Background = redBrush;
                                current.Name = "buttonRed" + indexRow + indexColumn;
                                stackPanel.Children.Add(current);
                            }
                            break;

                        case 3:
                            if (indexColumn % 2 == 1)
                            {
                                current.Background = redBrush;
                                current.Name = "buttonRed" + indexRow + indexColumn;
                                stackPanel.Children.Add(current);
                            }
                            break;

                        case 4:
                            if (indexColumn % 2 == 0)
                            {
                                current.Background = Brushes.BlueViolet;
                                current.Name = "button" + indexRow + indexColumn;
                                stackPanel.Children.Add(current);
                            }
                            break;

                        case 5:
                            if (indexColumn % 2 == 1)
                            {
                                current.Background = Brushes.BlueViolet;
                                current.Name = "button" + indexRow + indexColumn;
                                stackPanel.Children.Add(current);
                            }
                            break;

                        case 6:
                            if (indexColumn % 2 == 0)
                            {
                                current.Background = blackBrush;
                                current.Name = "buttonBlack" + indexRow + indexColumn;
                                stackPanel.Children.Add(current);
                            }
                            break;

                        case 7:
                            if (indexColumn % 2 == 1)
                            {
                                current.Background = blackBrush;
                                current.Name = "buttonBlack" + indexRow + indexColumn;
                                stackPanel.Children.Add(current);
                            }
                            break;

                        case 8:
                            if (indexColumn % 2 == 0)
                            {
                                current.Background = blackBrush;
                                current.Name = "buttonBlack" + indexRow + indexColumn;
                                stackPanel.Children.Add(current);
                            }
                            break;

                        default:
                            break;
                    }
                }
            }
        }
        //=============================================================

        UIElement GetUIElementFromGrid(Grid grid, int row, int column)
        {
            for (int index = 0; index < grid.Children.Count; index++)
            {
                UIElement element = grid.Children[index];
                if (Grid.GetRow(element) == row
                    && Grid.GetColumn(element) == column)
                {
                    return element;
                }
            }

            return null;
        }

        public void ButtonClick(Object sender, RoutedEventArgs e)
        {
            Button current = (Button)sender;
            StackPanel stackPanel = (StackPanel)current.Parent;
            int row = Grid.GetRow(stackPanel);
            int column = Grid.GetColumn(stackPanel);
            Console.WriteLine("Row: " + row + "  -- Column: " + column);
            if (currentMove_m == null)
            {
                currentMove_m = new Move();
            }

            if (currentMove_m.piece1 == null)
            {
                currentMove_m.piece1 = new Piece(row, column);
                stackPanel.Background = Brushes.DarkTurquoise;
            }

            else
            {
                currentMove_m.piece2 = new Piece(row, column);
                stackPanel.Background = Brushes.DarkTurquoise;
            }

            if ((currentMove_m.piece1 != null) 
                && (currentMove_m.piece2 != null))
            {
                if (VerifyMove() == true)
                {
                    MakeMove();
                }
            }
        }

        private void AddButton(Piece middleMove)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Background = Brushes.BlueViolet;
            Button current = new Button();
            current.Click += new RoutedEventHandler(ButtonClick);
            current.Height = 60;
            current.Width = 60;
            current.HorizontalAlignment = HorizontalAlignment.Center;
            current.VerticalAlignment = VerticalAlignment.Center;
            current.Background = Brushes.BlueViolet;
            current.Name = "button" + middleMove.Row + middleMove.Column;
            stackPanel.Children.Add(current);
            Grid.SetColumn(stackPanel, middleMove.Column);
            Grid.SetRow(stackPanel, middleMove.Row);
            MyGrid.Children.Add(stackPanel);
        }

        private void ShowMessage(string error)
        {
            MessageBox.Show(error, "Invalid move", MessageBoxButton.OK);
        }
        //=============================================================

        private Boolean VerifyMove()
        {
            StackPanel stackPanel1 = (StackPanel)GetUIElementFromGrid(MyGrid, currentMove_m.piece1.Row, currentMove_m.piece1.Column);
            StackPanel stackPanel2 = (StackPanel)GetUIElementFromGrid(MyGrid, currentMove_m.piece2.Row, currentMove_m.piece2.Column);
            Button button1 = (Button)stackPanel1.Children[0];
            Button button2 = (Button)stackPanel2.Children[0];
            stackPanel1.Background = Brushes.BlueViolet;
            stackPanel2.Background = Brushes.BlueViolet;

            if ((turn_m == "Black")
                && (button1.Name.Contains("Red")))
            {
                currentMove_m.piece1 = null;
                currentMove_m.piece2 = null;
                ShowMessage("Its blacks turn.");
                return false;
            }

            if ((turn_m == "Red") 
                && (button1.Name.Contains("Black")))
            {
                currentMove_m.piece1 = null;
                currentMove_m.piece2 = null;
                ShowMessage("Its reds turn.");
                return false;
            }

            if (button1.Equals(button2))
            {
                currentMove_m.piece1 = null;
                currentMove_m.piece2 = null;
                return false;
            }

            if (button1.Name.Contains("Black"))
            {
                return VerifyMoveForBlack(button1, button2);
            }

            else if (button1.Name.Contains("Red"))
            {
                return VerifyMoveForRed(button1, button2);
            }

            else
            {
                currentMove_m.piece1 = null;
                currentMove_m.piece2 = null;
                Console.WriteLine("False");
                return false;
            }
        }

        private bool VerifyMoveForRed(Button button1, Button button2)
        {
            Board currentBoard = GetCurrentBoard();
            List<Move> jumpMovesList = currentBoard.VerifyJumps("Red");

            if (button1.Name.Contains("Red"))
            {
                if (button1.Name.Contains("King"))
                {
                    if ((currentMove_m.isAdjacent("King"))
                        && (!button2.Name.Contains("Black"))
                        && (!button2.Name.Contains("Red")))
                    {
                        return true;
                    }
                    Piece middlePiece = currentMove_m.VerifyJump("King");

                    if ((middlePiece != null)
                        && (!button2.Name.Contains("Black"))
                        && (!button2.Name.Contains("Red")))
                    {
                        StackPanel middleStackPanel = (StackPanel)GetUIElementFromGrid(MyGrid, middlePiece.Row, middlePiece.Column);
                        Button middleButton = (Button)middleStackPanel.Children[0];
                        if (middleButton.Name.Contains("Black"))
                        {
                            MyGrid.Children.Remove(middleStackPanel);
                            AddButton(middlePiece);
                            return true;
                        }
                    }
                }
                else
                {
                    if ((currentMove_m.isAdjacent("Red"))
                        && (!button2.Name.Contains("Black"))
                        && (!button2.Name.Contains("Red")))
                    {
                        return true;
                    }
                    Piece middlePiece = currentMove_m.VerifyJump("Red");

                    if ((middlePiece != null)
                        && (!button2.Name.Contains("Black"))
                        && (!button2.Name.Contains("Red")))
                    {
                        StackPanel middleStackPanel = (StackPanel)GetUIElementFromGrid(MyGrid, middlePiece.Row, middlePiece.Column);
                        Button middleButton = (Button)middleStackPanel.Children[0];

                        if (middleButton.Name.Contains("Black"))
                        {
                            MyGrid.Children.Remove(middleStackPanel);
                            AddButton(middlePiece);
                            return true;
                        }
                    }
                }
            }
            currentMove_m = null;
            ShowMessage("Invalid move,please make another move.");
            return false;
        }

        private bool VerifyMoveForBlack(Button button1, Button button2)
        {
            Board currentBoard = GetCurrentBoard();
            List<Move> movesList = currentBoard.VerifyJumps("Black");


            if (button1.Name.Contains("Black"))
            {
                if (button1.Name.Contains("King"))
                {
                    if ((currentMove_m.isAdjacent("King"))
                        && (!button2.Name.Contains("Black"))
                        && (!button2.Name.Contains("Red")))
                    {
                        return true;
                    }
                    Piece middlePiece = currentMove_m.VerifyJump("King");

                    if ((middlePiece != null)
                        && (!button2.Name.Contains("Black"))
                        && (!button2.Name.Contains("Red")))
                    {
                        StackPanel middleStackPanel = (StackPanel)GetUIElementFromGrid(MyGrid, middlePiece.Row, middlePiece.Column);
                        Button middleButton = (Button)middleStackPanel.Children[0];

                        if (middleButton.Name.Contains("Red"))
                        {
                            MyGrid.Children.Remove(middleStackPanel);
                            AddButton(middlePiece);
                            return true;
                        }
                    }
                }

                else
                {
                    if ((currentMove_m.isAdjacent("Black"))
                        && (!button2.Name.Contains("Black"))
                        && (!button2.Name.Contains("Red")))
                    {
                        return true;
                    }
                    Piece middlePiece = currentMove_m.VerifyJump("Black");

                    if ((middlePiece != null)
                        && (!button2.Name.Contains("Black")) 
                        && (!button2.Name.Contains("Red")))
                    {
                        StackPanel middleStackPanel = (StackPanel)GetUIElementFromGrid(MyGrid, middlePiece.Row, middlePiece.Column);
                        Button middleButton = (Button)middleStackPanel.Children[0];
                        if (middleButton.Name.Contains("Red"))
                        {
                            MyGrid.Children.Remove(middleStackPanel);
                            AddButton(middlePiece);
                            return true;
                        }
                    }
                }
            }
            currentMove_m = null;
            ShowMessage("Invalid move, please make another move.");
            return false;
        }

        private void VerifyKing(Piece temp)
        {
            StackPanel stackPanel = (StackPanel)GetUIElementFromGrid(MyGrid, temp.Row, temp.Column);
            if (stackPanel.Children.Count > 0)
            {
                Button button = (Button)stackPanel.Children[0];
                var redBrush = new ImageBrush();
                redBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\David\source\repos\CheckersGame\CheckersGame\Images\rpk.png", UriKind.Relative));
                var blackBrush = new ImageBrush();
                blackBrush.ImageSource = new BitmapImage(new Uri(@"C:\Users\David\source\repos\CheckersGame\CheckersGame\Images\bpk.png", UriKind.Relative));
                if ((button.Name.Contains("Black"))
                    && (!button.Name.Contains("King")))
                {
                    if (temp.Row == 1)
                    {
                        button.Name = "button" + "Black" + "King" + temp.Row + temp.Column;
                        button.Background = blackBrush;
                    }
                }
                else if ((button.Name.Contains("Red"))
                    && (!button.Name.Contains("King")))
                {
                    if (temp.Row == 8)
                    {
                        button.Name = "button" + "Red" + "King" + temp.Row + temp.Column;
                        button.Background = redBrush;
                    }
                }
            }
        }

        private void MakeMove()
        {
            if ((currentMove_m.piece1 != null) && (currentMove_m.piece2 != null))
            {
                Console.WriteLine("Piece1 --> " + currentMove_m.piece1.Row + ", " + currentMove_m.piece1.Column);
                Console.WriteLine("Piece2 --> " + currentMove_m.piece2.Row + ", " + currentMove_m.piece2.Column);
                StackPanel stackPanel1 = (StackPanel)GetUIElementFromGrid(MyGrid, currentMove_m.piece1.Row, currentMove_m.piece1.Column);
                StackPanel stackPanel2 = (StackPanel)GetUIElementFromGrid(MyGrid, currentMove_m.piece2.Row, currentMove_m.piece2.Column);
                MyGrid.Children.Remove(stackPanel1);
                MyGrid.Children.Remove(stackPanel2);
                Grid.SetRow(stackPanel1, currentMove_m.piece2.Row);
                Grid.SetColumn(stackPanel1, currentMove_m.piece2.Column);
                MyGrid.Children.Add(stackPanel1);
                Grid.SetRow(stackPanel2, currentMove_m.piece1.Row);
                Grid.SetColumn(stackPanel2, currentMove_m.piece1.Column);
                MyGrid.Children.Add(stackPanel2);
                VerifyKing(currentMove_m.piece2);
                currentMove_m = null;
                if (turn_m == "Black")
                {
                    this.Title = "Reds turn!";
                    turn_m = "Red";
                }
                else if (turn_m == "Red")
                {
                    this.Title = "Blacks turn!";
                    turn_m = "Black";
                }
                VerifyGame();
            }
        }
    
        //=============================================================
        private void StartNewGame_Click(object sender, RoutedEventArgs e)
        {
            StartNewGame();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            GetCurrentBoard();
            this.SaveState();
        }

        private void LoadButton_Click(object sender, RoutedEventArgs e)
        {
            this.LoadState(@"C:\Users\David\source\repos\CheckersGame\CheckersGame\TextFiles\SavedState.txt");
        }
        //=============================================================
    }
}

