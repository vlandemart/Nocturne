using UnityEngine;

public class Weapon : MonoBehaviour
{
	protected virtual bool CanShoot()
	{
		return false;
	}

	public bool TryShoot()
	{
		if (!CanShoot())
			return false;
		Shoot();
		return true;
	}

	protected virtual void Shoot()
	{
		
	}
}
