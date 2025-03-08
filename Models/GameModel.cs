using System;

namespace TicTacToe.Models
{
    public class GameModel
    {
        public char[,] Board { get; private set; }
        public char CurrentPlayer { get; private set; } = 'X';
        public string Message { get; set; }
        public int PlayerXScore { get; set; }
        public int PlayerOScore { get; set; }
        public int Draws { get; set; }
        public bool IsAIPlaying { get; private set; } = false;

        public GameModel()
        {
            ResetBoard();
        }

        public void ResetBoard()
        {
            Board = new char[3, 3];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    Board[i, j] = ' ';
            Message = "Player X's turn";
            CurrentPlayer = 'X';
        }

        public void MakeMove(int row, int col)
        {
            if (Board[row, col] != ' ')
                return;

            Board[row, col] = CurrentPlayer;
            if (CheckWin(CurrentPlayer))
            {
                Message = $"Player {CurrentPlayer} wins!";
                if (CurrentPlayer == 'X') PlayerXScore++;
                else PlayerOScore++;
                ResetBoard();
                return;
            }
            else if (IsDraw())
            {
                Message = "It's a draw!";
                Draws++;
                ResetBoard();
                return;
            }

            CurrentPlayer = (CurrentPlayer == 'X') ? 'O' : 'X';
            Message = $"Player {CurrentPlayer}'s turn";

            if (IsAIPlaying && CurrentPlayer == 'O')
                AITurn();
        }

        private void AITurn()
        {
            Random rand = new Random();
            int row, col;
            do
            {
                row = rand.Next(3);
                col = rand.Next(3);
            } while (Board[row, col] != ' ');

            MakeMove(row, col);
        }

        private bool CheckWin(char player)
        {
            for (int i = 0; i < 3; i++)
                if ((Board[i, 0] == player && Board[i, 1] == player && Board[i, 2] == player) ||
                    (Board[0, i] == player && Board[1, i] == player && Board[2, i] == player))
                    return true;

            return (Board[0, 0] == player && Board[1, 1] == player && Board[2, 2] == player) ||
                   (Board[0, 2] == player && Board[1, 1] == player && Board[2, 0] == player);
        }

        private bool IsDraw()
        {
            foreach (char cell in Board)
                if (cell == ' ')
                    return false;
            return true;
        }

        public void ToggleAI()
        {
            IsAIPlaying = !IsAIPlaying;
        }
    }
}