using Blitzcrank.Manager;
using UnityEngine;

namespace Blitzcrank.Character
{
    public class Player : Character
    {
        [SerializeField] private TouchInput touchInput;
        private Vector2 _inputVector;
        private Rigidbody2D _rb;
        private int _jumpCount = 0;
        private float _thrust = 10.0f;
        public float maxSpeed = 10f;

        void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            _jumpCount = 0;
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
            touchInput.JoystickEvent += InputVector ;
        }
        void OnDisable()
        {
            touchInput.JoystickEvent -= InputVector;
        }
        void InputVector(Vector2 input)
        {
            _inputVector = input;
        }
        void Move()
        {

            _rb.velocity = new Vector2(_inputVector.x * maxSpeed, _rb.velocity.y);
            if (_inputVector.y > 0.6)
            {
                Jump(_inputVector);
            }
        }
        
        //TODO needs to be fixed with double jump here!
        void Jump(Vector2 inputVector)
        {
            if (_jumpCount < 1)
            {
                _rb.AddForce(transform.up * _thrust, ForceMode2D.Impulse);
                _jumpCount++;
                inputVector.y = 0;
            }
        }
    }
}

