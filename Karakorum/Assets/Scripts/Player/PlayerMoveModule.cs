using System.Collections;
using System.Collections.Generic;
using Karoku.Managers;
using Karoku.QLearning;
using UnityEngine;
using UnityEngine.AI;

namespace Karoku.Player
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class PlayerMoveModule : MonoBehaviour
    {
        [SerializeField] private float MinDistance = 0.4f;
        private NavMeshAgent agent;
        private Actor currentActor;
        private Vector3 currentPoint;

        protected virtual void Awake()
        {
            agent = GetComponent<NavMeshAgent>();
            currentPoint = transform.position;

        }


        public void SetActor(Actor findActor)
        {
            currentActor = findActor;
            NextPoint();
        }

        protected virtual void Update()
        {
            if (currentActor == null)
            {
                return;
            }

            var objPos = transform.position;
            objPos.y = currentPoint.y;
            if (Vector3.Distance(objPos, currentPoint) <= MinDistance)
            {
                NextPoint();
            }
        }

#if UNITY_EDITOR
        protected virtual void OnDrawGizmos()
        {
            var mapPositions = currentActor.Enviroment.PointToCoord(transform.position);
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(currentActor.Enviroment.CoordToPoint(mapPositions[0], mapPositions[1]), 0.35f);
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireSphere(currentPoint, 0.35f);
            Gizmos.DrawLine(transform.position, currentPoint);
        }
#endif


        
        private void NextPoint()
        {
            var mapPositions = currentActor.Enviroment.PointToCoord(transform.position);
            currentPoint = currentActor.Move(mapPositions[0], mapPositions[1]);
            agent.SetDestination(currentPoint);
        }

    }
}