using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemySample : MonoBehaviour
{
	public AIPath enemyPath;
	public Animator animator;
	public SpriteRenderer spriteRenderer;
	private Vector2 lastMoveDirection;

	private const string ANIMATOR_MOVE_SPEED = "MovementSpeed";
	private const string ANIMATOR_ATTACK = "Attack";


	void Start()
	{
		enemyPath.onSearchPath += OnTargetReached;
	}

	void Update()
	{
		UpdateAnimator();
	}

	private void UpdateAnimator()
	{
		animator.SetFloat(ANIMATOR_MOVE_SPEED, enemyPath.velocity.sqrMagnitude);

		if (enemyPath.velocity.sqrMagnitude > 0)
		{
			lastMoveDirection = enemyPath.velocity;
		}

		spriteRenderer.flipX = lastMoveDirection.x < 0 ? false : true;
	}

	private void OnTargetReached()
	{
		if (enemyPath.reachedEndOfPath)
		{
			animator.SetTrigger(ANIMATOR_ATTACK);
		}
	}
}
