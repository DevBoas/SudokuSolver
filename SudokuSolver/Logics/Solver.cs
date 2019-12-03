using SudokuSolver.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SudokuSolver.Logics
{
    public class Solver
    {

        public Boolean isFull(int[][] sudoku)
        {
            for (int i = 0; i < sudoku.Length; i++)
            {
                for (int j = 0; j < sudoku[i].Length; j++)
                {
                    if (sudoku[i][j] == 0)
                        return false;
                }
            }
            return true;
        }

        public int WhichColum(int i, int j)
        {
            int columx = (i / 3) * 3;
            int columy = j / 3;
            int colum = columx + columy;
            return colum;
        }

        public int [] PossibleNumbers(int [][] sudoku,int i, int j)
        {
            List<int> numbers = new List<int>();
            int[] marks = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int col = WhichColum(i, j);

            Debug.Print(sudoku[i][j].ToString());
            Debug.Print("---------------");
            for (int q = 0; q < sudoku.Length; q++)
            {
                for (int w = 0; w < sudoku[q].Length; w++)
                {
                    if ((WhichColum(q, w) == col) && (sudoku[q][w] != 0))
                    {
                        for (int t = 0; t < marks.Length; t++)
                        {
                            if (marks[t] == sudoku[q][w])
                            {
                                marks[t] = 0;
                                break;
                            }
                        }
                    }
                }
            }
            for (int y = 0; y < sudoku[i].Length; y++)
            {
                if (sudoku[y][j] != 0)
                {
                    for (int t = 0; t < marks.Length; t++)
                    {
                        if (marks[t] == sudoku[y][j])
                        {
                            marks[t] = 0;
                            break;
                        }
                    }
                }
            }
            for (int x = 0; x < sudoku[i].Length; x++)
            {
                if (sudoku[i][x] != 0)
                {
                    for (int t = 0; t < marks.Length; t++)
                    {
                        if (marks[t] == sudoku[i][x])
                        {
                            marks[t] = 0;
                            break;
                        }
                    }
                }
            }
            for (int t = 0; t < marks.Length; t++)
            {
                if (marks[t] > 0)
                {
                    numbers.Add(marks[t]);
                    //Debug.Print(marks[t].ToString());
                }
            }

            //Debug.Print(col.ToString());
            return numbers.ToArray();
        }


        public int which_sq(int i)
        {
            return (i - i % 3);
        }

        public Boolean can_place(int[][] sudoku, int row, int col, int val)
        {
            int i;
            int j;

            i = 0;
            while (i < 9)
            {
                if (sudoku[i][col] == val || sudoku[row][i] == val)
                    return (false);
                i++;
            }
            i = 0;
            j = 0;
            while (i < 3)
            {
                j = 0;
                while (j < 3)
                {
                    if (sudoku[which_sq(row) + i][which_sq(col) + j] == val)
                        return (false);
                    j++;
                }
                i++;
            }
            return (true);
        }

        public Boolean calc(int[][] sudoku, int val)
        {
            int x;
            int y;
            int i;

            x = val / 9;
            y = val % 9;
            i = 1;
            if (val >= 81)
                return (true);
            if (sudoku[x][y] != 0)
                return (calc(sudoku, val + 1));
            while (i < 10)
            {
                if (can_place(sudoku, x, y, i))
                {
                    sudoku[x][y] = i;
                    if (calc(sudoku, val + 1))
                        return (true);
                    else
                        sudoku[x][y] = 0;
                }
                i++;
            }
            return false;
        }

        public int[][] Solve(int[][] sudoku)
        {
            calc(sudoku, 0);
            //int[] arr = PossibleNumbers(sudoku, 7, 5);

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    Debug.Print(arr[i].ToString());
            //}

            /*for (int i = 0; i < sudoku.Length; i++)
            {
                for (int j = 0; j < sudoku[i].Length; j++)
                {
                    sudoku[i][j] = 1;
                    if ((j < 3) && (i < 3))
                    {
                        //Debug.Print(sudoku[i][j].ToString());
                    }
                }
            }*/

            return sudoku;
        }

        public int[][] Create(int[][] sudoku)
        {
            return sudoku;
        }
    }
}