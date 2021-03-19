using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RecursionExercises
{
    class Program
    {
        public static StreamWriter writer = new StreamWriter("solutions.txt");
        static int solutionsCount = 0;

        static void Main(string[] args)
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter labyrinth size X: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                int matrixX = int.Parse(Console.ReadLine());
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("Enter labyrinth size Y: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                int matrixY = int.Parse(Console.ReadLine());
                Console.WriteLine();

                char[,] labyrinth = new char[matrixY, matrixX];

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Enter labyrinth: ('S' - Start, '-' - Free, '*' - Wall, 'E' - Exit.)"); Console.ForegroundColor = ConsoleColor.Blue;
                Console.ForegroundColor = ConsoleColor.Blue;

                int startX = 0;
                int startY = 0;

                for (int i = 0; i < labyrinth.GetLength(0); i++)
                {
                    string current = Console.ReadLine();

                    for (int j = 0; j < labyrinth.GetLength(1); j++)
                    {
                        labyrinth[i, j] = current[j];

                        if (current[j] == 'S' || current[j] == 's')
                        {
                            startX = i;
                            startY = j;
                        }
                    }
                }

                List<char> path = new List<char>();
                solutionsCount = 0;
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Possible solutions:");
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Blue;

                using (writer)
                {
                    FindPath(startX, startY, labyrinth, 'S', path);
                }

                if (solutionsCount == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("There are no possible solutions.");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(solutionsCount + " possible solutions.");
                    Console.ResetColor();
                }
            }
            catch (Exception exp)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine();
                Console.WriteLine("Error: " + exp.Message);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(exp.ToString());
                Console.WriteLine();
                Console.ResetColor();
            }

        }

        //The main method for finding all paths.
        static void FindPath(int row, int col, char[,] labyrinth, char direction, List<char> path)
        {
            if (!IsInBounds(row, col, labyrinth))
            {
                return;
            }

            path.Add(direction);

            if (IsExit(row, col, labyrinth))
            {
                PrintPath(path);
            }
            else if (!IsVisited(row, col, labyrinth) && IsFree(row, col, labyrinth))
            {
                Mark(row, col, labyrinth);
                FindPath(row, col + 1, labyrinth, 'R', path);
                FindPath(row + 1, col, labyrinth, 'D', path);
                FindPath(row, col - 1, labyrinth, 'L', path);
                FindPath(row - 1, col, labyrinth, 'U', path);
                Unmark(row, col, labyrinth);
            }

            path.RemoveAt(path.Count - 1);
        }

        //Checks if current coordinates are in the bounds of the matrix.
        static bool IsInBounds(int row, int col, char[,] labyrinth)
        {
            try
            {
                char current = labyrinth[row, col];

                labyrinth[row, col] = 'k';
                labyrinth[row, col] = current;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //Prints the current path.
        static void PrintPath(List<char> path)
        {
            solutionsCount++;
            writer.WriteLine(String.Join(null, path.Skip(1)));
            Console.WriteLine(String.Join(null, path.Skip(1)));
        }

        //Checks if current coordinates are the exit.
        static bool IsExit(int row, int col, char[,] labyrinth)
        {
            return labyrinth[row, col] == 'E' || labyrinth[row, col] == 'e';
        }

        //Checks if current coordinates are free (not a wall).
        static bool IsFree(int row, int col, char[,] labyrinth)
        {
            return labyrinth[row, col] == '-' || labyrinth[row, col] == 's' || labyrinth[row, col] == 'S';
        }

        //Checks if current coordinates are a wall.
        static bool IsWall(int row, int col, char[,] labyrinth)
        {
            return labyrinth[row, col] == '*';
        }

        //Checks if current coordinates have been already visited in the current path.
        static bool IsVisited(int row, int col, char[,] labyrinth)
        {
            return labyrinth[row, col] == '#';
        }

        //Marks the current coordinates as 'visited';
        static void Mark(int row, int col, char[,] labyrinth)
        {
            labyrinth[row, col] = '#';
        }

        //Marks the current coordinates as 'unvisited'.
        static void Unmark(int row, int col, char[,] labyrinth)
        {
            labyrinth[row, col] = '-';
        }
    }
}
