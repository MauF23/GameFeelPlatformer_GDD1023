using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Hp : MonoBehaviour
{
    public int maxHp = 3;
    private int currentHp = 0;

    public AnimationManager animationManager;

	private void Start()
	{
		currentHp = maxHp;
	}

	public void TakeDamage(int amount)
    {
		if(currentHp <= 0)
		{
			return;
		}

		currentHp -= amount;

		if(currentHp <= 0)
		{
			Die();
			return;
		}

		animationManager?.SetAnimHit();      
	}

	public void Die() 
	{
		animationManager?.SetDeath();	
	}
}
