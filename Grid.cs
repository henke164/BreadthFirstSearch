using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication 
{
    public class Grid
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<int> Obstacles { get; set; } =  new List<int>();
        
        public int NodeCount { 
            get 
            { 
                return Width * Height; 
            }
        }

        public IEnumerable<int> GetNearbyNodes(int nodeIndex)
        {
            var yIndex = (int)Math.Ceiling((decimal)nodeIndex / (decimal)Width + 1) - 1;
            var xIndex = (int)Math.Ceiling((decimal)nodeIndex - ((yIndex - 1) * Width));

            var availableNeighbours = new int?[] {
                GetAvailableNorthNode(xIndex, yIndex),
                GetAvailableEastNode(xIndex, yIndex),
                GetAvailableSouthNode(xIndex, yIndex),
                GetAvailableWestNode(xIndex, yIndex)
            };

            return availableNeighbours
                    .Where(n => n.HasValue && !Obstacles.Contains(n.Value))
                    .Select(n => n.Value);
        }

        private int? GetAvailableNorthNode(int xIndex, int yIndex)
            => yIndex > 1 ? (yIndex - 2) * Width + xIndex : (int?)null;

        private int? GetAvailableSouthNode(int xIndex, int yIndex)
            => yIndex < Height ? (yIndex) * Width + xIndex : (int?)null;

        private int? GetAvailableWestNode(int xIndex, int yIndex)
            => xIndex > 1 ? (yIndex - 1) * Width + (xIndex - 1) : (int?)null;

        private int? GetAvailableEastNode(int xIndex, int yIndex)
            => xIndex < Width ? (yIndex - 1) * Width + (xIndex + 1) : (int?)null;
    }
}