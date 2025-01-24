using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
	public PlayerController3D characterController;
    public Collider hitbox, owner;
    public int damage;
	private const float ATTACK_FORCE = 125;

	private void Start()
	{
		hitbox.isTrigger = true;
		DisableHitbox();
		Physics.IgnoreCollision(owner, hitbox);
	}

	public void EnableHitbox()
    {
		characterController.ToggleMovement(false);
		hitbox.enabled = true;
	}

    public void DisableHitbox()
    {
		characterController.ToggleMovement(true);
		hitbox.enabled = false;
	}

    public void ToggleHitbox(int intToggle)
    {
        intToggle = Mathf.Clamp(intToggle, 0, 1);
        bool toggle = intToggle >= 1 ? true : false;    
        hitbox.enabled = toggle;
    }

	private void OnTriggerEnter(Collider other)
	{
		Hp hp = other.GetComponent<Hp>();
		if (hp != null)
		{
			hp.TakeDamage(1);
		}
	}
}
