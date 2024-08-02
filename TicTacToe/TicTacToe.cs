namespace TicTacToe
{
    internal class TicTacToe
    {
        private char[,] board;
        private char currentPlayer;
        private bool gameWon;
        private bool gameDraw;

        public TicTacToe()
        {
            board = new char[3, 3];
            currentPlayer = 'X';
            gameWon = false;
            gameDraw = false;
            InitializeBoard();
        }

        private void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        public void PlayGame()
        {
            while (!gameWon && !gameDraw)
            {
                PrintBoard();
                PlayerMove();
                CheckWin();
                CheckDraw();
                SwitchPlayer();
            }

            PrintBoard();

            if (gameWon)
            {
                Console.WriteLine($"Игрок {GetOpponent()} выиграл!");
            }
            else if (gameDraw)
            {
                Console.WriteLine("Игра завершилась вничью.");
            }
        }

        private void PrintBoard()
        {
            Console.Clear();
            Console.WriteLine("  1 2 3");
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"{i + 1} ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j]);
                    if (j < 2) Console.Write("|");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine("  -----");
            }
        }

        private void PlayerMove()
        {
            int row = 0;
            int col = 0;
            bool validMove = false;

            while (!validMove)
            {
                Console.WriteLine($"Ход игрока {currentPlayer}. Введите номер строки и столбца (например, 1 1):");
                string input = Console.ReadLine();
                string[] inputArr = input.Split(' ');

                row = int.Parse(inputArr[0]);
                col = int.Parse(inputArr[1]);

                if ((row >= 1 && row <= 3 && col >= 1 && col <= 3) && board[row - 1, col - 1].Equals(' '))
                {
                    board[row - 1, col - 1] = currentPlayer;
                    validMove = true;
                }
                else
                {
                    Console.WriteLine("Некорректный ход. Попробуйте снова.");
                }
            }
        }

        private void CheckWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                {
                    gameWon = true;
                    return;
                }

                if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                {
                    gameWon = true;
                    return;
                }

                if (board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer)
                {
                    gameWon = true;
                    return;
                }

                if (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer)
                {
                    gameWon = true;
                    return;
                }
            }
        }

        private void CheckDraw()
        {
            gameDraw = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == ' ')
                    {
                        gameDraw = false;
                        return;
                    }
                }
            }
        }

        private void SwitchPlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }

        private char GetOpponent()
        {
            return (currentPlayer == 'X') ? 'O' : 'X';
        }
    }
}
