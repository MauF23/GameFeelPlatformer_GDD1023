using Platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompTrigger : MonoBehaviour
{
	public PlayerController playerController;
	public AudioSource stompAudio;
	public float bounceForce;
	public const float FREEZE_FRAME_TIME = 2f;
	private Coroutine timeRoutine;

	private void OnTriggerEnter2D(Collider2D collision)
	{
		HpEnemy hpEnemy = collision.GetComponent<HpEnemy>();
		
		if (hpEnemy != null)
		{
			stompAudio?.Play();
			hpEnemy.RemoveHp(hpEnemy.maxHp);
			playerController?.Knockback(Vector2.up * bounceForce);

			StopCoroutine(timeRoutine);
			timeRoutine = StartCoroutine(FreezeFrameRoutine());
		}
	}

	IEnumerator FreezeFrameRoutine()
	{
		Time.timeScale = 2f;
		yield return new WaitForSecondsRealtime(FREEZE_FRAME_TIME);
		Time.timeScale = 1;
	}
}
