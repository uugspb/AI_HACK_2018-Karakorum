using System.Collections;
using System.Collections.Generic;
using Karoku.Managers;
using UnityEngine;

namespace Karoku.Debug
{
    [ExecuteInEditMode]
    public class DrawEnviroment : MonoBehaviour
    {
        [SerializeField] private GameManagerModule gameManager;


        protected virtual void Update()
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
            UnityEngine.Debug.DrawLine(startPosition, startPosition + new Vector3(size.x, 0f, 0f), Color.red);
            UnityEngine.Debug.DrawLine(startPosition, startPosition + new Vector3(0f, 0f, size.z), Color.red);
            UnityEngine.Debug.DrawLine(startPosition + new Vector3(size.x, 0f, 0f), startPosition + new Vector3(size.x, 0f, size.z), Color.red);
            UnityEngine.Debug.DrawLine(startPosition + new Vector3(0f, 0f, size.z), startPosition + new Vector3(size.x, 0f, size.z), Color.red);
        }

    }
}
