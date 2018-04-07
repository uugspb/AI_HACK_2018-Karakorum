using System.Collections;
using System.Collections.Generic;
using Karoku.Managers;
using UnityEngine;
using UnityEngine.AI;

namespace Karoku.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMoveModule : MonoBehaviour
    {
        private NavMeshAgent agent;

        protected virtual void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        protected virtual void Start()
        {
            MoveToPoint(GameManagerModule.Instance.Mark);
        }


        public void MoveToPoint(Vector3 point)
        {
            agent.SetDestination(point);
        }

        public void MoveDirection(Vector3 direction)
        {

        }
    }
}