using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(PlayerInteractions))]
public class Player : MonoBehaviour
{
	private PlayerMovement playerMovement;
	private Vector2 inputVector;
	private PlayerInteractions playerInteractions;

	private void Start()
	{
		playerMovement = GetComponent<PlayerMovement>();
		playerInteractions = GetComponent<PlayerInteractions>();
	}

	private void Update()
	{
		GetInput();
		playerMovement.Move(inputVector);
	}

	private void GetInput()
	{
		inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
		if (Input.GetKeyDown(KeyCode.E))
			playerInteractions.Interact();
		if (Input.GetKeyDown(KeyCode.Space))
			playerMovement.Jump();
	}
}
