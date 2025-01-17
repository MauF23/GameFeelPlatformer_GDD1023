using Platformer;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CoinChecker : MonoBehaviour
{
  public KeyCode checkCoinKey;

	private void Update()
	{
		if (Input.GetKeyDown(checkCoinKey)) 
		{
			Debug.Log("Player has " + GameManager.gameManagerInstance.coinsCounter + "coin");
		}
	}
}
