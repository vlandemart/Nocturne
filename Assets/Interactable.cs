using UnityEngine;

public class Interactable : MonoBehaviour
{
	[SerializeField]
	private bool interacted = false;

	public virtual bool CanInteract()
	{
		return !interacted;
	}

	public virtual bool Interact()
	{
		if (!CanInteract())
			return false;

		interacted = true;
		OnInteract();
		return true;
	}

	protected virtual void OnInteract()
	{
		
	}
}
