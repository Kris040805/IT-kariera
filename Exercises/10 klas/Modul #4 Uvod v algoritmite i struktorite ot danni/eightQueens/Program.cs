using System;
using System.Collections.Generic;

namespace eightQueens
{
    class Program
    {
        const int dashboardSize = 8;

        static int solutionFound = 0;
        static bool[,] chessboard = new bool[dashboardSize, dashboardSize];
        static HashSet<int> attackedRows = new HashSet<int>();
        static HashSet<int> attackedColumns = new HashSet<int>();
        static HashSet<int> attackedLeftDiagonals = new HashSet<int>();
        static HashSet<int> attackedRightDiagonals = new HashSet<int>();

        static void Main(string[] args)
        {
            PutQueens(0);
            Console.WriteLine(solutionFound);
        }

        static void PutQueens(int row)
        {
            if (row == dashboardSize)
            {
                PrintSolution();
            }
            else
            {
                for (int col = 0; col < dashboardSize; col++)
                {
                    if (CanPlaceQueen(row, col))
                    {
                        MarkAllAttackedPositions(row, col);
                        PutQueens(row + 1);
                        UnmarkAllAttackedPositions(row, col);
                    }
                }
            }
        }

        static void UnmarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Remove(row);
            attackedColumns.Remove(col);
            attackedLeftDiagonals.Remove(col - row);
            attackedRightDiagonals.Remove(col + row);
            chessboard[row, col] = false;
        }

        static void MarkAllAttackedPositions(int row, int col)
        {
            attackedRows.Add(row);
            attackedColumns.Add(col);
            attackedLeftDiagonals.Add(col - row);
            attackedRightDiagonals.Add(col + row);
            chessboard[row, col] = true;
        }

        static bool CanPlaceQueen(int row, int col)
        {
            var posIsOccupied =
                attackedRows.Contains(row) ||
                attackedColumns.Contains(col) ||
                attackedLeftDiagonals.Contains(col - row) ||
                attackedRightDiagonals.Contains(col + row);

            return !posIsOccupied;
        }

        static void PrintSolution()
        {
            for (int row = 0; row < dashboardSize; row++)
            {
                for (int col = 0; col < dashboardSize; col++)
                {
                    Console.Write(chessboard[row, col] ? "*" : "-");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            solutionFound++;
        }
    }
}
