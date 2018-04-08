using System.Collections;
using System.Collections.Generic;
using Karoku.Managers;
using UnityEngine;

namespace Karoku.Debug
{
#if UNITY_EDITOR
    [ExecuteInEditMode]
    public class DrawEnviroment : MonoBehaviour
    {
        [SerializeField] private GameManagerModule gameManager;


        protected virtual void OnDrawGizmos()
        {
            gameManager = gameManager ?? FindObjectOfType<GameManagerModule>();

            if (!gameManager)
            {
                return;
            }
            Vector3 size = new Vector3(gameManager.quadWidth, 0f, gameManager.quadHeight);

            for (int i = 0; i < gameManager.mapWidth; ++i)
            {
                for (int j = 0; j < gameManager.mapHeight; ++j)
                {
                    DrawQuad(i, j, size);
                }
            }
        }


        private void DrawQuad(int x, int y, Vector3 size)
        {
            Vector3 startPosition = gameManager.mapOffset + new Vector3(gameManager.quadWidth * x, 0f, gameManager.quadHeight * y);
            Color temp = Color.red;
            if (gameManager.enviroment != null)
            {
                temp = Color.LerpUnclamped(Color.green, Color.red, gameManager.enviroment[x, y] / 80f);
            }

            UnityEngine.Debug.DrawLine(startPosition, startPosition + new Vector3(size.x, 0f, 0f), temp);
            UnityEngine.Debug.DrawLine(startPosition, startPosition + new Vector3(0f, 0f, size.z), temp);
            UnityEngine.Debug.DrawLine(startPosition + new Vector3(size.x, 0f, 0f), startPosition + new Vector3(size.x, 0f, size.z), temp);
            UnityEngine.Debug.DrawLine(startPosition + new Vector3(0f, 0f, size.z), startPosition + new Vector3(size.x, 0f, size.z), temp);
        }

    }
#endif
}
