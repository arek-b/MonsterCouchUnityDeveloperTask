using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UpdateManagement;

namespace Enemy
{
    public class Movement : MonoBehaviour, IUpdateable
    {
        [SerializeField] private float movementBoundX = 8f;
        [SerializeField] private float movementBoundY = 4.5f;
        [SerializeField] private float speed = 0.001f;
        bool stopped = false;

        private void OnEnable()
        {
            UpdateManager.Instance.Register(this);
        }

        private void OnDisable()
        {
            UpdateManager.Instance.Unregister(this);
        }

        public void Tick(Vector2 playerPosition)
        {
            float distance = Vector2.Distance(transform.position, playerPosition);
            float step = (1f / Mathf.Clamp(distance, 2f, 10f)) * Time.deltaTime * speed;
            Vector2 newPosition = Vector2.MoveTowards(transform.position, playerPosition, -step);
            newPosition.x = Mathf.Clamp(newPosition.x, -movementBoundX, movementBoundX);
            newPosition.y = Mathf.Clamp(newPosition.y, -movementBoundY, movementBoundY);
            transform.Translate(newPosition - (Vector2)transform.position);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (stopped)
            {
                return;
            }
            stopped = true;
            UpdateManager.Instance.Unregister(this);
            GetComponent<SpriteRenderer>().color = Color.white;
        }
    }
}
