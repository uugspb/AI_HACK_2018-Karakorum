using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Karoku.QLearning
{
    public class Actor
    {
        public Vector3 FocusPoint { get; set; }
        public readonly int Type;
        private readonly Enviroment enviroment;


        public float Gamma { get; set; }
        public float Alpha { get; set; }
        public float Epsilon { get; set; }

        public Actor(Enviroment enviroment, int type, float gamma, float alpha, float epsilon)
        {
            Type = type;
            this.enviroment = enviroment;
            Gamma = gamma;
            Alpha = alpha;
            Epsilon = epsilon;
        }

        public void Move(int posX, int posY)
        {
            FocusPoint = enviroment.CoordToPoint(posX, posY);
        }
    }
}