# BreadthFirstSearch
Simple BFS solution written in c# .Net core.

A fast way to find the shortest path from multiple nodes to a single goal.

Also added some obstacles/walls.

# Example
```C#
var targetNodeIndex = 100;

var grid = new Grid {
  Height = 3,
  Width = 10,
  Obstacles = new List<int> { 6, 16, 18, 19, 28, 29 } // Indexes of nodes that cannot be passed
};

var search = new BreadthFirstSearch(grid, targetNodeIndex);

// Get path to the goal from any node ex: 5
var startNodeIndex = 5;
var path = search.GetPath(startNodeIndex);
```
```
Result: int[] { 15, 25, 26, 27, 17, 7, 8, 9, 20, 30 }

1   2   3   4  Start 6   x   x   x   x
11  12  13  14  x   16   x  18  19   x
21  22  23  24  x    x   x  28  29  Goal
```
