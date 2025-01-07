
using Platformer;
using UnityEngine;

public class HpPlayer : HpBase
{
    public PlayerController playerController;
	public GameManager gameManager;
	private const float KNOCK_FORCE = 250f;

	protected override void Start()
	{
		base.Start();
		if (playerController == null) 
		{
			playerController = GetComponent<PlayerController>();
		}
	}

	public override void RemoveHp(int amount)
	{
		base.RemoveHp(amount);
		Vector2 knockbackForce = playerController.facingRight ? (Vector2.left * KNOCK_FORCE) : (Vector2.right * KNOCK_FORCE);
		playerController.Knockback(knockbackForce);
		playerController.Knockback(Vector2.up * (KNOCK_FORCE/2));
	}

	protected override void Death()
	{
		base.Death();
		playerController.deathState = true;
		gameManager?.GameOver();
	}

	public override void Revive()
	{
		base.Revive();
		playerController.deathState = false;
	}
}
