using System;
using System.Collections.Generic;

namespace ConsoleApplication 
{
    public class BreadthFirstSearch
    {
        public int[] _edgesTo;
        public int[] _distTo;
        private bool[] _visited;
        private Grid _grid;
        private int _goal;

        public BreadthFirstSearch(Grid grid, int goal)
        {
            _goal = goal;
            _grid = grid;
            ResetArrays();
            MapGridData();
        }

        private void ResetArrays()
        {
            var arrayLength = _grid.NodeCount + 1;
            _edgesTo = new int[arrayLength];
            _distTo = new int[arrayLength];
            _visited = new bool[arrayLength];

            for (int i = 0; i < arrayLength; i++)
            {
                _distTo[i] = -1;
                _edgesTo[i] = -1;
                _visited[i] = false;
            }
        }

        private void MapGridData()
        {
            var queue = new Queue<int>();
            queue.Enqueue(_goal);
            _distTo[_goal] = 0;
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                foreach (var nearbyNode in _grid.GetNearbyNodes(node))
                {
                    if (_distTo.Length >= (nearbyNode + 1) && _distTo[nearbyNode] == -1)
                    {
                        queue.Enqueue(nearbyNode);
                        _distTo[nearbyNode] = _distTo[node] + 1;
                        _edgesTo[nearbyNode] = node;
                    }
                }
            }
        }

        public int[] GetPath(int start)
        {
            var distance = _distTo[start];
            if(distance == -1)
            {
                Console.WriteLine("No path available");
                return new int[0];
            }

            var path = new int[distance];
            if (_edgesTo[start] != 0)
            {
                while (start != _goal)
                {
                    start = _edgesTo[start];
                    path[--distance] = start;
                }
            }
            return path;
        }
    }
}