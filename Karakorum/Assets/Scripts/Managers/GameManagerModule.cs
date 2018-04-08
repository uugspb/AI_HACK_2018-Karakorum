using System.Collections;
using System.Collections.Generic;
using Karoku.QLearning;
using Karoku.Tools;
using UnityEngine;

namespace Karoku.Managers
{
    public class GameManagerModule : SingletonOneScene<GameManagerModule>
    {
        [SerializeField] private Vector3 mark;

        [Header("Map settings")] [SerializeField]
        public Vector3 mapOffset;

        [SerializeField] public int mapWidth, mapHeight;
        [SerializeField] public float quadWidth, quadHeight;


        public Enviroment enviroment { get; private set; }

        public Vector3 Mark
        {
            get { return mark; }
        }


        protected override void Awake()
        {
            base.Awake();
            enviroment = new Enviroment(mapWidth, mapHeight, quadWidth, quadHeight, mapOffset);
            CalculateEnviroment();
        }

        private void CalculateEnviroment()
        {
            CalculateDfs();
            UnityEngine.Debug.Log("End calculate enviroment");
        }

        private void CalculateDfs()
        {
            var position = enviroment.PointToCoord(mark);
            Queue<int[]> dfs = new Queue<int[]>();
            dfs.Enqueue(new[] { position[0], position[1], Mathf.Max(enviroment.Width, enviroment.Height) });
            bool[,] wasInQueue = new bool[enviroment.Width, enviroment.Height];
            while (dfs.Count > 0)
            {
                var node = dfs.Dequeue();
                enviroment[node[0], node[1]] = node[2];
                if (node[0] > 0 && !wasInQueue[node[0] - 1, node[1]])
                {
                    dfs.Enqueue(new[] { node[0] - 1, node[1], node[2] - 1 });
                    wasInQueue[node[0] - 1, node[1]] = true;
                }

                if (node[0] < enviroment.Width - 1 && !wasInQueue[node[0] + 1, node[1]])
                {
                    dfs.Enqueue(new[] { node[0] + 1, node[1], node[2] - 1 });
                    wasInQueue[node[0] + 1, node[1]] = true;
                }

                if (node[1] > 0 && !wasInQueue[node[0], node[1] - 1])
                {
                    dfs.Enqueue(new[] { node[0], node[1] - 1, node[2] - 1 });
                    wasInQueue[node[0], node[1] - 1] = true;
                }

                if (node[1] < enviroment.Height - 1 && !wasInQueue[node[0], node[1] + 1])
                {
                    dfs.Enqueue(new[] { node[0], node[1] + 1, node[2] - 1 });
                    wasInQueue[node[0], node[1] + 1] = true;
                }

            }
        }


        private void CalculateUnnodes()
        {
            foreach (var o in GameObject.FindGameObjectsWithTag("Stopable"))
            {
                foreach (var component in o.GetComponents<Collider>())
                {
                    //component.
                }
            }
        }
    }
}