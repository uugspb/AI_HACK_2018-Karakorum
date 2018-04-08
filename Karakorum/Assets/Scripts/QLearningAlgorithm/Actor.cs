using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Karoku.QLearning
{
    public class Actor
    {
        private enum ActorDirection
        {
            None =0,
            Up = 1,
            UpRight = 2,
            Right = 3,
            DownRight = 4,
            Down = 5,
            DownLeft = 6,
            Left = 7,
            UpLeft = 8
        }

        public readonly int Type;
        public readonly Enviroment Enviroment;


        public float Gamma { get; set; }
        public float Alpha { get; set; }
        public float Epsilon { get; set; }
        public float MaxAlpha { get; set; }
        public float DeltaAlpha { get; set; }

        private readonly float[,,] qTable;
        private readonly int actionCount;

        public Actor(Enviroment enviroment, int type, float gamma, float alpha, float epsilon, float maxAlpha, float deltaAlpha)
        {
            Type = type;
            Enviroment = enviroment;
            Gamma = gamma;
            Alpha = alpha;
            Epsilon = epsilon;
            MaxAlpha = maxAlpha;
            DeltaAlpha = deltaAlpha; 
            qTable = new float[enviroment.Width, enviroment.Height, actionCount = (System.Enum.GetNames(typeof(ActorDirection)).Length)];
        }

        public Vector3 Move(int posX, int posY)
        {

            var action = GetActionFromState(posX, posY);
            var newPositions = MoveToPosition(posX, posY, action);
            var newReward = Enviroment[newPositions[0], newPositions[1]];
            var actionId = (int) action;
            qTable[posX, posY, actionId] = qTable[posX, posY, actionId]
                                           + Alpha * (newReward + Gamma * qTable[newPositions[0], newPositions[1],
                                                          GetMaxRewardId(newPositions[0], newPositions[1])]
                                                      - qTable[posX, posY, actionId]);
            Alpha = Mathf.Min(MaxAlpha, Alpha + DeltaAlpha);
            DebugLog();
            return Enviroment.CoordToPoint(newPositions[0], newPositions[1]);
        }

        private void DebugLog()
        {
            //UnityEngine.Debug.Log("Actor");
            //UnityEngine.Debug.Log("Alpha: " + Alpha);
        }

        private ActorDirection GetActionFromState(int posX, int posY)
        {
            if (Random.Range(0f, 1f) < Epsilon)
            {
                return (ActorDirection)Random.Range(0, actionCount);
            }

            return (ActorDirection)GetMaxRewardId(posX, posY);
        }

        private int GetMaxRewardId(int x, int y)
        {
            int maxId = 0;
            float maxReward = qTable[x, y, maxId];
            for (int i = 1; i < actionCount; ++i)
            {
                if (maxReward < qTable[x, y, i] || (maxReward.Equals(qTable[x, y, i]) && Random.value < .5f))
                {
                    maxReward = qTable[x, y, maxId = i];
                }
            }

            return maxId;
        }


        private int[] MoveToPosition(int posX, int posY, ActorDirection direction)
        {
            int[] res = new[] {posX, posY};
            switch (direction)
            {
                case ActorDirection.Up:
                    res[1] = posY + 1;
                    break;
                case ActorDirection.UpRight:
                    res[0] = posX + 1;
                    res[1] = posY + 1;
                    break;
                case ActorDirection.Right:
                    res[0] = posX + 1;
                    break;
                case ActorDirection.DownRight:
                    res[0] = posX + 1;
                    res[1] = posY - 1;
                    break;
                case ActorDirection.Down:
                    res[1] = posY - 1;
                    break;
                case ActorDirection.DownLeft:
                    res[0] = posX - 1;
                    res[1] = posY - 1;
                    break;
                case ActorDirection.Left:
                    res[0] = posX - 1;
                    break;
                case ActorDirection.UpLeft:
                    res[0] = posX - 1;
                    res[1] = posY + 1;                 
                    break;
                case ActorDirection.None:
                    break;
            }

            res[0] = Mathf.Max(0, Mathf.Min(Enviroment.Width - 1, res[0]));
            res[1] = Mathf.Max(0, Mathf.Min(Enviroment.Height - 1, res[1]));
            return res;
        }
    }
}