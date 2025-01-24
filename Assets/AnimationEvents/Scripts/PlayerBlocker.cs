using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBlocker : MonoBehaviour
{
	public Collider playerCollider, playerBlockerCollider;

	private void Start()
	{
		Physics.IgnoreCollision(playerCollider, playerBlockerCollider, true);
	}
}
