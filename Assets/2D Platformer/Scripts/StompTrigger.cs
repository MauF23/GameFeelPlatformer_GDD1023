using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompTrigger : MonoBehaviour
{
	public PlayerController playerController;
	public AudioSource stompAudio;
	public float bounceForce;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		HpEnemy hpEnemy = collision.GetComponent<HpEnemy>();

		if (hpEnemy != null)
		{
			stompAudio?.Play();
			hpEnemy.RemoveHp(hpEnemy.maxHp);
			playerController?.Knockback(Vector2.up * bounceForce);
		}
	}
}
