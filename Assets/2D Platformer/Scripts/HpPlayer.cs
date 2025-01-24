
using Platformer;
using UnityEngine;
using DG.Tweening; //Impotart Asset DoTweem

public class HpPlayer : HpBase
{
  public PlayerController playerController;
	public GameManager gameManager;
	private const float KNOCK_FORCE = 250f;

	//Variables efecto de da�o
	[Header("DamageTweenEffect")]
	public SpriteRenderer playerSpriteRenderer;

	[Tooltip("Color que reflaja el da�o")]
	public Color damageColor; //Color que reflaja el da�o
	public float damageTweenTime; //Tiempo de duraci�n del efecto
	public int effectLoops;
	public int playerLayer, inmuneLayer;
	public Transform playerCollisionRoot;// transfrom que tiene anexado el collider de da�o

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

		//(damageTweenTime / effectLoops) para que cada loop tenga duraci�n dividida entr el tiempo espefificado
		playerSpriteRenderer.DOColor(damageColor, (damageTweenTime / effectLoops))
			.SetLoops(effectLoops, LoopType.Yoyo)
			.OnStart(InvencibilityStart)
			.OnComplete(InvencibilityEnd);
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

	//Cambiar capa a la cual no tiene inteacci�n con los enemigos
	private void InvencibilityStart()
	{
		playerCollisionRoot.gameObject.layer = inmuneLayer;
	}

	//Regresar la capa del jugador a la default
	private void InvencibilityEnd()
	{
		playerCollisionRoot.gameObject.layer = playerLayer;
	}
}
