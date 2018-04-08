using System.Collections;
using System.Collections.Generic;
using Karoku.Managers;
using UnityEngine;

namespace Karoku.QLearning
{
    [ExecuteInEditMode]
    public class EnviromentRemove : MonoBehaviour
    {
        [SerializeField] private int width;
        [SerializeField] private int height;
        [SerializeField] private int xOffset;
        [SerializeField] private int yOffset;

        private GameManagerModule gameManager;
        protected virtual void OnDrawGizmos()
        {
            gameManager = gameManager ?? FindObjectOfType<GameManagerModule>();

            if (!gameManager)
            {
                return;
            }
            Vector3 size = new Vector3(gameManager.quadWidth, 0f, gameManager.quadHeight);

            for (int i = xOffset; i < width; ++i)
            {
                for (int j = yOffset; j < height; ++j)
                {
                    DrawQuad(i, j, size);
                }
            }
        }


        private void DrawQuad(int x, int y, Vector3 size)
        {
            Vector3 startPosition = gameManager.mapOffset + new Vector3(gameManager.quadWidth * x, 0f, gameManager.quadHeight * y);
            UnityEngine.Debug.DrawLine(startPosition, startPosition + new Vector3(size.x, 0f, 0f), Color.black);
            UnityEngine.Debug.DrawLine(startPosition, startPosition + new Vector3(0f, 0f, size.z), Color.black);
            UnityEngine.Debug.DrawLine(startPosition + new Vector3(size.x, 0f, 0f), startPosition + new Vector3(size.x, 0f, size.z), Color.black);
            UnityEngine.Debug.DrawLine(startPosition + new Vector3(0f, 0f, size.z), startPosition + new Vector3(size.x, 0f, size.z), Color.black);
        }
    }
}
