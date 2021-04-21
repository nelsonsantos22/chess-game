using System;
using board;
using game;
using System.Collections.Generic;

namespace Chess_game
{
    class Screen
    {

        public static void printMatch(ChessMatch chessMatch)
        {
            printBoard(chessMatch.gameBoard);
            Console.WriteLine();
            printCapturedPieces(chessMatch);
            Console.WriteLine();
            Console.WriteLine("Turn: " + chessMatch.turn);
            if (!chessMatch.matchFinnished)
            {
                Console.WriteLine("Waiting for player: " + chessMatch.currentPlayer);
                if (chessMatch.check)
                {
                    Console.WriteLine("CHECK!");
                }
            }
            else
            {
                Console.WriteLine("CHECKMATE!");
                Console.WriteLine("WInner: " + chessMatch.currentPlayer);
            }
        }

        public static void printCapturedPieces(ChessMatch chessMatch)
        {
            Console.WriteLine("Lost Pieces:");
            Console.Write("White ones: ");
            printAllPieces(chessMatch.capturedPieces(Color.White));
            Console.WriteLine();
            Console.Write("Black ones: ");
            ConsoleColor aux = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            printAllPieces(chessMatch.capturedPieces(Color.Black));
            Console.ForegroundColor = aux;
            Console.WriteLine();
        }

        public static void printAllPieces(HashSet<Piece> conjunto)
        {
            Console.Write("[");
            foreach (Piece piece in conjunto)
            {
                Console.Write(piece + " ");
            }
            Console.Write("]");
        }

        public static void printBoard(Board gameBoard)
        {

            for (int i = 0; i < gameBoard.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < gameBoard.columns; j++)
                {
                    printPiece(gameBoard.piece(i, j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void printBoard(Board gameBoard, bool[,] possiblePositions)
        {

            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor possibleBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < gameBoard.lines; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < gameBoard.columns; j++)
                {
                    if (possiblePositions[i, j])
                    {
                        Console.BackgroundColor = possibleBackground;
                    }
                    else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    printPiece(gameBoard.piece(i, j));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = originalBackground;
        }

        public static ChessPosition readChessPosition()
        {
            string s = Console.ReadLine();
            char column = s[0];
            int line = int.Parse(s[1] + "");
            return new ChessPosition(column, line);
        }

        public static void printPiece(Piece gamePiece)
        {

            if (gamePiece == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (gamePiece.color == Color.White)
                {
                    Console.Write(gamePiece);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(gamePiece);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }

    }
}
