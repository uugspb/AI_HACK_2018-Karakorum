using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Karoku.Triggers
{
    public class TriggerEnableRigidbody : MonoBehaviour
    {

        protected virtual void OnTriggerEnter(Collider collider)
        {
            if (collider.tag.Equals("Orc"))
            {
                collider.GetComponent<NavMeshAgent>().enabled = false;
                collider.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }
}