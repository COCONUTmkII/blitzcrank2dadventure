using Blitzcrank.Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Blitzcrank.Character
{
    public class Player : Character
    {
        [SerializeField] private TouchInput touchInput;
        Vector2 inputVector;
        private Rigidbody2D rb;
        private int jumpCount = 0;
        private float thrust = 10.0f;
        public float maxSpeed = 10f;

        void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            jumpCount = 0;
        }
        void Update()
        {
            
        }
        private void FixedUpdate()
        {
            Move();
        }
        void OnEnable()
        {
            touchInput.JoysticEvent += InputVector ;
        }
        void OnDisable()
        {
            touchInput.JoysticEvent -= InputVector;
        }
        void InputVector(Vector2 input)
        {
            inputVector = input;
        }
        void Move()
        {

            rb.velocity = new Vector2(inputVector.x * maxSpeed, rb.velocity.y);
            if (inputVector.y > 0.6)
            {
                Jump(inputVector);
            }
        }
        void Jump(Vector2 inputVector)
        {
            if (jumpCount < 1)
            {
                rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
                jumpCount++;
                inputVector.y = 0;
            }
        }
    }
}

