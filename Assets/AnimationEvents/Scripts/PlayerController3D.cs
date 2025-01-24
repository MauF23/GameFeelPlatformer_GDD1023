using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
	private Vector3 movementVector;
    private Vector3 relativeToCameraDirection, relativeMovementVector;
    public float movementSpeed, rotationSpeed;
    private bool canMove, canAttack;

    private const float GROUND_SPHERE_RADIUS = 2;

	public LayerMask groundLayer;
    public Transform groundPoint;
	public Rigidbody rigidbody;
    public Camera playerCamera;
    public AnimationManager animationManager;

    void Start()
    {
        canMove = true;
	}

	private void Update()
	{
        if (Grounded())
        {
			movementVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			Attack();
		}
	}

	void FixedUpdate()
    {
		if (Grounded() && canMove)
        {
			rigidbody.velocity = Movement();

			if (Movement() != Vector3.zero)
            {
                Rotation();
            }
            animationManager?.SetAnimMovement(Movement().sqrMagnitude);
		}
    }

    Vector3 Movement()
    {
		relativeToCameraDirection = RelativeCameraDirection(movementVector);
		return relativeMovementVector = relativeToCameraDirection * movementSpeed;
    }

    void Rotation()
    {
        Vector3 v = RelativeCameraDirection(movementVector);
		Quaternion targetRotation = Quaternion.LookRotation(relativeMovementVector);
		transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
	}

    void Attack()
    {
        if (Input.GetButtonDown("Fire1") && canAttack)
        {
            animationManager?.SetAttack();
        }
    }

    bool Grounded()
    {
		return Physics.OverlapSphere(groundPoint.transform.position, 2, groundLayer).Length > 0;    
    }

    Vector3 RelativeCameraDirection(Vector3 referenceVector)
    {
		float cameraForward = playerCamera.transform.eulerAngles.y;
		return relativeToCameraDirection = (Quaternion.Euler(0, cameraForward, 0) * referenceVector).normalized;
	}

    public void ToggleMovement(bool canMove)
    {

        if (!canMove)
        {
            rigidbody.velocity = Vector3.zero;  
        }
        this.canMove = canMove;
    }

    public void ToggleAttack(bool attackValue)
    {
        canAttack = attackValue;
    }

}
