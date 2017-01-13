using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication
{
    public class Program
    {
        private static Grid _grid = new Grid {
            Height = 10,
            Width = 10,
            Obstacles = new List<int> { 12, 13, 14, 47, 48, 49, 50, 60 }
        };

        public static void Main(string[] args)
        {
            var search = new BreadthFirstSearch(_grid, goal: 100);
            
            // Draw 10 different paths, that starts from 1-10
            for(var startNode = 1; startNode <= 10; startNode++)
            {
                var path = search.GetPath(startNode);
                DrawGrid(path.ToList());
            }
        }

        static void DrawGrid(IEnumerable<int> path)
        {
            var index = 1;
            for(var y = 0; y < 100; y++)
            {
                if(path.Contains(index))
                {
                    // Path
                    Console.Write("x\t");
                }
                else if(_grid.Obstacles.Contains(index))
                {
                    // Wall
                    Console.Write("#\t");
                }
                else
                {
                    // Floor
                    Console.Write($"{index}\t");
                }

                if(index % 10 == 0)
                {
                    Console.WriteLine("\t");
                }
                index++;
            }
            Console.WriteLine("");
        }
    }
}
