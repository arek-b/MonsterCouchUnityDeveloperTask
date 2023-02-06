using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;


namespace Enemy
{
    public class Spawner : MonoBehaviour
    {
        [SerializeField] private GameObject enemyContainer = null;
        [SerializeField] private int enemiesToSpawn = 1000;
        [SerializeField] private GameObject enemyPrefab = null;
        [SerializeField] private float spawnBoundX = 8f;
        [SerializeField] private float spawnBoundY = 4.5f;
        private const float Half = 0.5f;

        private void Awake()
        {
            Assert.IsNotNull(enemyPrefab);
            Assert.IsNotNull(enemyContainer);
        }

        // for editor button, not supposed to be called in game
        public void Spawn()
        {
            foreach (Transform child in enemyContainer.transform) {
                DestroyImmediate(child.gameObject);
            }

            for (int i = 0; i < enemiesToSpawn; i++)
            {
                Vector2 position = Vector2.zero;
                position.x = Random.value * spawnBoundX;
                position.y = Random.value * spawnBoundY;
                if (Random.value > Half)
                    position.x = -position.x;
                if (Random.value > Half)
                    position.y = -position.y;

                Instantiate(enemyPrefab, position, Quaternion.identity, enemyContainer.transform);
            }
        }
    }
}
