using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Karoku.Tools
{

    public class SingletonOneScene<T> : MonoBehaviour  where T : Component 
    {

        private static T instance;


        public static T Instance
        {
            get { return instance ?? new GameObject().AddComponent<T>(); }
        }


        protected virtual void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(this);
                return;
            }

            instance = this as T;
        }
    }
}