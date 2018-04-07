using System.Collections;
using System.Collections.Generic;
using Karoku.Tools;
using UnityEngine;

namespace Karoku.Managers
{
    public class GameManagerModule : SingletonOneScene<GameManagerModule>
    {
        [SerializeField] private Vector3 mark;

        public Vector3 Mark
        {
            get { return mark; }
        }
    }
}