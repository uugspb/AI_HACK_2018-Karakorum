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

        [Header("Map settings")] 
        [SerializeField] public Vector3 mapOffset;
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
        }
    }
}