using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompTrigger : MonoBehaviour
{
	public PlayerController playerController;
	public float bounceForce;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		HpEnemy hpEnemy = collision.GetComponent<HpEnemy>();

		if (hpEnemy != null)
		{
			hpEnemy.RemoveHp(hpEnemy.maxHp);
			playerController?.Knockback(Vector2.up * bounceForce);
		}
	}
}
