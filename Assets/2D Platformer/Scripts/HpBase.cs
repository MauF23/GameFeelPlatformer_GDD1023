using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBase : MonoBehaviour
{
	[Range(1, 3)]
    public int maxHp;
    protected int currentHp;

	protected virtual void Start()
	{
		Revive();
	}

	public virtual void RemoveHp(int amount)
	{
		currentHp -= amount;
		Mathf.Clamp(currentHp, 0, maxHp);

		if(currentHp <= 0)
		{
			Death();	
		}
	}

	public virtual void Revive()
	{
		currentHp = maxHp;
	}

	protected virtual void Death()
	{

	}
}
