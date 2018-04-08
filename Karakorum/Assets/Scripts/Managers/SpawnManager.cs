using System.Collections;
using System.Collections.Generic;
using Karoku.Managers;
using Karoku.Player;
using Karoku.QLearning;
using Karoku.Tools;
using UnityEngine;

namespace Karoku
{
    public class SpawnManager : SingletonOneScene<SpawnManager>
    {
        [Header("Orcs setting")]
        [SerializeField] private GameObject[] orcs;

        [SerializeField] private float[] gamma;
        [SerializeField] private float[] epsilon;
        [SerializeField] private float[] deltaAlpha;
        [SerializeField] private float[] maxAlpha;
        [Header("Spawn Territory")]
        [SerializeField] private float minRadius, maxRadius;
        [SerializeField] private Vector3 center;
        [SerializeField] private float heightSpawn = 1.5f;

        private Actor[] orcsActor;

        protected override void Awake()
        {
            base.Awake();
            orcsActor = new Actor[orcs.Length];
            var env = GameManagerModule.Instance.enviroment;
            for (int i = 0; i < orcs.Length; ++i)
            {
                orcsActor[i] = new Actor(env, i, gamma[i], 1f, epsilon[i], maxAlpha[i], deltaAlpha[i]);
            }
        }

        protected virtual void Update()
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                var radius = Random.Range(minRadius, maxRadius);
                Vector3 pos = RandomOnCircle(radius) + center;
                pos.y = heightSpawn;
                Spawn(0, pos);
            }
        }

        private Vector3 RandomOnCircle(float radius)
        {
            var x = Random.Range(0f, radius);
            return new Vector3(x, 0f, Random.value < .5f ? -Mathf.Sqrt(radius * radius - x * x) : Mathf.Sqrt(radius * radius - x * x));
        }

#if UNITY_EDITOR
        protected virtual void OnDrawGizmos()
        {

            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(center, minRadius);
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(center, maxRadius);
        }
#endif


        private void Spawn(int id, Vector3 position)
        {
            var orc = Instantiate(orcs[id], position, Quaternion.identity);
            orc.GetComponent<PlayerMoveModule>().SetActor(orcsActor[id]);
        }


        private bool CheckPosition(Vector3 position)
        {
            var distance = Vector3.Distance(position, center);
            return distance >= minRadius && distance <= maxRadius;
        }
    }
}