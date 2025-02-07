using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingPlatfom : MonoBehaviour
{
	public Transform platform, destination;
	public float moveTime = 2;
	Tween platformTween;
	public KeyCode movePLatformKey = KeyCode.Tab;
	public KeyCode killTween = KeyCode.K;
	private bool paused = false;
	void Start()
	{
		platformTween = platform.DOMove(destination.position, moveTime);
	}

	private void Update()
	{
		if (Input.GetKeyDown(movePLatformKey))
		{
			paused = !paused;

			if (paused)
			{
				platformTween.Play();
			}
			else
			{
				platformTween.Pause();
			}
		}

		if (Input.GetKeyDown(killTween))
		{
			platformTween.Kill();
		}
	}

}
