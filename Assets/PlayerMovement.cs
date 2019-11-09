using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	private CharacterController characterController;
	private Animator animator;

	[SerializeField]
	private float speed = 6.0f;
	[SerializeField]
	private float jumpSpeed = 8.0f;
	[SerializeField]
	private float gravity = 20.0f;

	[SerializeField]
	private Transform cameraTransform;
	private Vector3 moveDirection = Vector3.zero;

	private void Start()
	{
		characterController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
	}

	public void Move(Vector2 inputVector)
	{
		if (characterController.isGrounded)
		{
			moveDirection = new Vector3(inputVector.x, 0.0f, inputVector.y);
			moveDirection = moveDirection.normalized * (speed * Time.deltaTime);
			moveDirection = cameraTransform.TransformDirection(moveDirection);
		}

		moveDirection.y -= gravity * Time.deltaTime;
		characterController.Move(moveDirection);
		Animate();
	}

	public void Jump()
	{
		if (!characterController.isGrounded)
			return;
		moveDirection.y = jumpSpeed;
	}

	private void Animate()
	{
		//tmp solution for animation
		//later will be moved to player
		animator.SetFloat("horizontal", characterController.velocity.x / speed);
		animator.SetFloat("vertical", characterController.velocity.z / speed);
		animator.SetBool("aiming", Input.GetMouseButton(1));
		if (Input.GetKey(KeyCode.Alpha1))
			animator.SetFloat("weaponIdle", 0);
		else if (Input.GetKey(KeyCode.Alpha2))
			animator.SetFloat("weaponIdle", 1);
	}
}
