using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3]; 

        static char currentPlayer = 'X'; 

        static bool gameOver = false; 

        static void Main(string[] args)
        {
            InitializeBoard();
            while (!gameOver)
            {
                DrawBoard();
                TakeTurn();
                CheckForWinner();
                CheckForDraw();
                if (!gameOver) 
                    ChangePlayer();
            }

            Console.WriteLine("¿Quieres jugar de nuevo? (S/N)");
            string input = Console.ReadLine();
            if (input.ToLower() == "s")
            {
                gameOver = false;
                InitializeBoard();
                Main(null);
            }
            else
            {
                Console.WriteLine("Gracias por jugar. Presiona cualquier tecla para salir...");
                Console.ReadKey();
            }
        }


        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        static void DrawBoard()
        {
            Console.Clear();
            Console.WriteLine("  0 1 2");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(i + " ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(board[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void TakeTurn()
        {
            Console.WriteLine("Turno del jugador " + currentPlayer);
            Console.Write("Ingrese la fila: ");
            int row = int.Parse(Console.ReadLine());
            Console.Write("Ingrese la columna: ");
            int col = int.Parse(Console.ReadLine());

            if (board[row, col] == ' ')
            {
                board[row, col] = currentPlayer;
            }
            else
            {
                Console.WriteLine("La casilla ya está ocupada. Intente de nuevo.");
                TakeTurn();
            }
        }

        static void CheckForWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (board[i, 0] == currentPlayer && board[i, 1] == currentPlayer && board[i, 2] == currentPlayer)
                {
                    DrawBoard(); 
                    Console.WriteLine("¡El jugador " + currentPlayer + " ha ganado!");
                    gameOver = true;
                    return;
                }
            }

     
            for (int i = 0; i < 3; i++)
            {
                if (board[0, i] == currentPlayer && board[1, i] == currentPlayer && board[2, i] == currentPlayer)
                {
                    DrawBoard(); 
                    Console.WriteLine("¡El jugador " + currentPlayer + " ha ganado!");
                    gameOver = true;
                    return;
                }
            }

            if ((board[0, 0] == currentPlayer && board[1, 1] == currentPlayer && board[2, 2] == currentPlayer) ||
                (board[0, 2] == currentPlayer && board[1, 1] == currentPlayer && board[2, 0] == currentPlayer))
            {
                DrawBoard(); 
                Console.WriteLine("¡El jugador " + currentPlayer + " ha ganado!");
                gameOver = true;
                return;
            }
        }

        
        static void CheckForDraw()
        {
            bool isFull = true;
            foreach (char cell in board)
            {
                if (cell == ' ')
                {
                    isFull = false;
                    break;
                }
            }
            if (isFull)
            {
                DrawBoard(); 
                Console.WriteLine("¡Empate!");
                gameOver = true;
            }
        }

        static void ChangePlayer()
        {
            currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
        }
    }
}