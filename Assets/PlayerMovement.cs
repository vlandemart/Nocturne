using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
	CharacterController characterController;
	private Animator animator;

	[SerializeField]
	private float speed = 6.0f;
	[SerializeField]
	private float jumpSpeed = 8.0f;
	[SerializeField]
	private float gravity = 20.0f;

	private Vector3 moveDirection = Vector3.zero;

	void Start()
	{
		characterController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
	}

	void Update()
	{
		if (characterController.isGrounded)
		{
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
			moveDirection *= speed * Time.deltaTime;

			if (Input.GetButton("Jump"))
			{
				moveDirection.y = jumpSpeed;
				Debug.Log("Jumped");
			}
		}

		moveDirection.y -= gravity * Time.deltaTime;

		characterController.Move(moveDirection);

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
