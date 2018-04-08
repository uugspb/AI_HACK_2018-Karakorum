using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Karoku.QLearning
{
    public class Enviroment
    {
        public Enviroment(
            int width,
            int height,
            float quadWidth,
            float quadHeights,
            Vector3 mapOffset)
        {
            map = new int[Width = width, Height = height];
            MapOffset = mapOffset;
            QuadWidth = quadWidth;
            QuadHeights = quadHeights;

        }


        public readonly int Width;
        public readonly int Height;
        public readonly float QuadWidth;
        public readonly float QuadHeights;
        public readonly Vector3 MapOffset;

        private readonly int[,] map;


        public int this[int x, int y]
        {
            get { return map[x, y]; }
            set { map[x, y] = value; }
        }


        public Vector3 CoordToPoint(int x, int y)
        {
            return new Vector3(QuadWidth * (x + .5f), 0f, QuadHeights * (y + .5f)) + MapOffset;
        }

        public int[] PointToCoord(Vector3 position)
        {
            position -= MapOffset;
            int[] res = new int[2];
            res[0] = Mathf.RoundToInt(position.x / QuadWidth - .5f);
            res[1] = Mathf.RoundToInt(position.z / QuadHeights - .5f);
            return res;
        }
    }
}