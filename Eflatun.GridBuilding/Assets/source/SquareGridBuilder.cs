using System.Collections.Generic;
using UnityEngine;

namespace Eflatun.GridBuilding
{
    /// <summary>
    /// Methods for generating symmetrical square grids.
    /// </summary>
    public static class SquareGridBuilder
    {
        /// <summary>
        /// Generates a grid inside a circle.
        /// </summary>
        /// <param name="origin">Origin of circle.</param>
        /// <param name="radius">Radius of circle.</param>
        /// <param name="cellSize">Distance between nodes.</param>
        public static IEnumerable<Vector2> BuildGridInCircle(Vector2 origin, float radius, float cellSize)
        {
            float halfCellSize = cellSize / 2;

            float offset = radius % cellSize;

            Vector2 min = new Vector2(origin.x - radius, origin.y - radius);
            Vector2 max = new Vector2(origin.x + radius, origin.y + radius);

            var xBegin = min.x + offset;
            var yBegin = min.y + offset;

            float xLimit = max.x;
            float yLimit = max.y;
            float radiusLimit = radius - halfCellSize;

            for (float x = xBegin; x <= xLimit; x += cellSize)
            {
                for (float y = yBegin; y <= yLimit; y += cellSize)
                {
                    var candidate = new Vector2(x, y);
                    if (candidate.TestDistanceLowerThan(origin, radiusLimit, true))
                    {
                        yield return new Vector2(x, y);
                    }
                }
            }
        }

        /// <summary>
        /// Generates a grid inside a rectangle.
        /// </summary>
        /// <param name="min">Minimum point of rectangle.</param>
        /// <param name="max">Maximum point of rectangle.</param>
        /// <param name="cellSize">Distance between nodes.</param>
        public static IEnumerable<Vector2> BuildGridInRectangle(Vector2 min, Vector2 max, float cellSize)
        {
            float halfCellSize = cellSize / 2;

            float xOffset = ((max.x - min.x) / 2) % cellSize;
            float yOffset = ((max.y - min.y) / 2) % cellSize;

            float xBegin = min.x + halfCellSize + xOffset;
            float yBegin = min.y + halfCellSize + yOffset;

            float xLimit = max.x - halfCellSize;
            float yLimit = max.y - halfCellSize;

            for (float x = xBegin; x <= xLimit; x += cellSize)
            {
                for (float y = yBegin; y <= yLimit; y += cellSize)
                {
                    yield return new Vector2(x, y);
                }
            }
        }
    }
}
