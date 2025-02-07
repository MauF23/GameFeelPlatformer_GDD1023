using DG.Tweening;
using System.Collections;
using UnityEngine;

public class HpEnemy : HpBase
{
	[Header("DeathTweenEffect")]
	public float deathTweenTime;
	public Vector3 deathScale;
	public Collider2D enemyDamageCollider;

	protected override void Death()
	{
		base.Death();
		enemyDamageCollider.enabled = false;
		transform.DOScale(deathScale, deathTweenTime).OnComplete(Dissapear);
	}

	private void Dissapear()
	{
		gameObject.SetActive(false);
	}
}
