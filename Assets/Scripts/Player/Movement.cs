using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

namespace Player
{
    public class Movement : MonoBehaviour
    {
        [SerializeField] private float speed = 2f;
        [SerializeField] private float movementBoundX = 8f;
        [SerializeField] private float movementBoundY = 4.5f;
        private Rigidbody2D myRigidbody = null;
        private Vector2 direction = Vector2.zero;

        private void Awake()
        {
            myRigidbody = GetComponent<Rigidbody2D>();
            Assert.IsNotNull(myRigidbody);
        }

        private void Update()
        {
            direction = GetDirection();
            Vector2 newPosition = (Vector2)transform.position + (Time.deltaTime * speed * direction);
            newPosition.x = Mathf.Clamp(newPosition.x, -movementBoundX, movementBoundX);
            newPosition.y = Mathf.Clamp(newPosition.y, -movementBoundY, movementBoundY);
            myRigidbody.MovePosition(newPosition);
        }

        private Vector2 GetDirection()
        {
            Vector2 direction = Vector2.zero;

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                direction += Vector2.right;
            }
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                direction -= Vector2.right;
            }
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                direction += Vector2.up;
            }
            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                direction -= Vector2.up;
            }

            return direction;
        }
    }
}
