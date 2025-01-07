using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class PlayerController : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        private float moveInput;

		[HideInInspector]
		public bool facingRight = false;

        [HideInInspector]
        public bool deathState = false;

        private bool isGrounded;
		public LayerMask ground;
		public Transform groundCheck;
        public float groundRayLenght;

        private Rigidbody2D rigidbody;
        private Animator animator;
        private GameManager gameManager;

        private int jumpCounter = 0;
        private const int JUMP_COUNT = 1;

        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        }

        private void FixedUpdate()
        {
            CheckGround();
        }

        void Update()
        {
            if (Input.GetButton("Horizontal")) 
            {
                moveInput = Input.GetAxis("Horizontal");
                Vector3 direction = transform.right * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
                animator.SetInteger("playerState", 1); // Turn on run animation
            }
            else
            {
                if (isGrounded) animator.SetInteger("playerState", 0); // Turn on idle animation
            }
            if(Input.GetKeyDown(KeyCode.Space) && jumpCounter < JUMP_COUNT)
            {
                rigidbody.velocity = Vector2.zero;
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
                jumpCounter++;
			}
            if (!isGrounded)animator.SetInteger("playerState", 2); // Turn on jump animation

            if(facingRight == false && moveInput > 0)
            {
                Flip();
            }
            else if(facingRight == true && moveInput < 0)
            {
                Flip();
            }
        }

        private void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }

        private void CheckGround()
        {
            isGrounded = Physics2D.Raycast(groundCheck.position, Vector2.down, groundRayLenght, ground);

            if (isGrounded ) { jumpCounter = 0;}

			Debug.DrawRay(groundCheck.position, Vector2.down * groundRayLenght, Color.green);
		}

        public void Knockback(Vector2 knockbackForce)
        {
            rigidbody.velocity = Vector2.zero;
            rigidbody.AddForce(knockbackForce);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.tag == "Coin")
            {
                gameManager.CollectCoin();
                Destroy(other.gameObject);
            }
        }
    }
}
