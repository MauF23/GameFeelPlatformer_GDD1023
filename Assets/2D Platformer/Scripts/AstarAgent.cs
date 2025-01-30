using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Pathfinding;

public class AstarAgent : MonoBehaviour
{
    public Transform groundPoint;
    public Transform player;
    public LayerMask groundLayer;
    public AIPath aiPath;
    public float groundedRadius, searchPlatformRadius;
	public bool grounded;

    private Tween jumpTween;
    private const float JUMP_POWER = 2;
    private const int JUMP_COUNT = 1;
    private const float JUMP_DURATION = 1f;

	void Start()
    {
        
    }


    void Update()
    {
        grounded = Grounded();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Jump(player.position);
        }
	}

	bool Grounded()
	{
		return Physics2D.OverlapCircleAll(groundPoint.transform.position, groundedRadius, groundLayer).Length > 0;
	}

    public void Jump(Vector3 destination)
    {
        jumpTween?.Kill(true);
		jumpTween = transform.DOJump(destination, JUMP_POWER, JUMP_COUNT, JUMP_DURATION)
            .OnStart(() => { aiPath.enabled = false; })
            .OnComplete(() => { aiPath.enabled = true; });
    }

	private void OnDrawGizmos()
	{
        Gizmos.color = grounded ? Color.green : Color.red;
        Gizmos.DrawWireSphere(groundPoint.position, groundedRadius);

        Gizmos.color = Color.cyan;
		Gizmos.DrawWireSphere(transform.position, searchPlatformRadius);
	}
}
