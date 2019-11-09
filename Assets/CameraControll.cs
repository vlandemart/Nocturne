using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
	[SerializeField]
	private float rotationSpeed = 1;
	[SerializeField]
	private Transform Target;
	[SerializeField]
	private Transform Player;

	private float mouseX;
	private float mouseY;

	void Start()
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
	}

	private void LateUpdate()
	{
		CamControl();
		if (Input.GetKeyDown(KeyCode.L))
		{
			if (Cursor.lockState == CursorLockMode.Locked)
				Cursor.lockState = CursorLockMode.None;
			else
				Cursor.lockState = CursorLockMode.Locked;
		}
	}

	void CamControl()
	{
		mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
		mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
		mouseY = Mathf.Clamp(mouseY, -35, 60);

		transform.LookAt(Target);

		if (Input.GetKey(KeyCode.LeftShift))
		{
			Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
		}
		else
		{
			Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
			Player.rotation = Quaternion.Euler(0, mouseX, 0);
		}
	}
}
