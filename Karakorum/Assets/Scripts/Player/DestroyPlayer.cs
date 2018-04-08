using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Karoku.Player
{
    public class DestroyPlayer : MonoBehaviour
    {
        [SerializeField] private float minY;

        protected virtual void Update()
        {
            if (transform.position.y < minY)
            {
                Destroy(gameObject);
            }
        }
    }
}