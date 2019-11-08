using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
	[SerializeField]
	private List<Interactable> interactables;
	[SerializeField]
	private Interactable currentInteractable;

	[ContextMenu("Interact")]
	public bool Interact()
	{
		if (currentInteractable == null)
			return false;
		if (currentInteractable.Interact())
		{
			RemoveInteractable(currentInteractable);
			currentInteractable = null;
			UpdateClosestInteractable();
			return true;
		}
		return false;
	}

	public void UpdateClosestInteractable()
	{
		if (interactables.Count <= 0)
		{
			currentInteractable = null;
			return;
		}

		Interactable closestInteractable = null;
		float closestDistance = 9999f;
		foreach (Interactable interactable in interactables)
		{
			if (!interactable.CanInteract())
				continue;
			float dist = Vector3.SqrMagnitude(interactable.transform.position - transform.position);
			if (dist < closestDistance)
			{
				closestInteractable = interactable;
				closestDistance = dist;
			}
		}

		currentInteractable = closestInteractable;
	}

	private void OnTriggerEnter(Collider other)
	{
		Interactable interactable = other.GetComponent<Interactable>();
		if (interactable == null || !interactable.CanInteract())
			return;
		interactables.Add(interactable);
		UpdateClosestInteractable();
	}

	private void OnTriggerExit(Collider other)
	{
		Interactable interactable = other.GetComponent<Interactable>();
		if (interactable == null)
			return;
		RemoveInteractable(interactable);
	}

	public void RemoveInteractable(Interactable interactable)
	{
		if (interactables.Contains(interactable))
			interactables.Remove(interactable);
		UpdateClosestInteractable();
	}
}
