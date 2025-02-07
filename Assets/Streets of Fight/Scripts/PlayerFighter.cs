using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFighter : MonoBehaviour
{
    public float moveSpeed;
    public Animator animator;
    public Rigidbody2D rb2;
	public SpriteRenderer spriteRenderer;

	private Vector2 movement, lastMovement;

    private const string ANIM_MOVE_SPEED = "MoveSpeed";
	private const string MOVE_XAXIS = "Horizontal";
	private const string MOVE_YAXIS = "Vertical";

	private void Update()
	{
		movement = new Vector2(Input.GetAxis(MOVE_XAXIS), Input.GetAxis(MOVE_YAXIS)).normalized;
	}

	private void LateUpdate()
	{
		PlayerMovement();
	}


	private void PlayerMovement()
	{

		rb2.velocity = movement * moveSpeed;
		animator.SetFloat(ANIM_MOVE_SPEED, rb2.velocity.sqrMagnitude);

		if (movement.sqrMagnitude > 0)
		{
			lastMovement = movement;
		}

		spriteRenderer.flipX = lastMovement.x < 0 ? true : false;
	}

}
