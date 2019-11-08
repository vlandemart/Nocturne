using UnityEngine;

public class Item : Interactable
{
	protected override void OnInteract()
	{
		gameObject.SetActive(false);
		Debug.Log("Picked up item");
	}
}
