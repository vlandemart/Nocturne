using UnityEngine;

public class LivingEntity : MonoBehaviour
{
	[SerializeField]
	private float maxHp = 1;
	private float hp;
	public float Hp => hp;
	private bool dead;
	public bool IsDead => dead;

	public virtual void SetUp()
	{
		hp = maxHp;
		dead = false;
	}

	public virtual void TakeDamage()
	{
		if (hp < 0 || dead)
			return;
		if (hp <= 0)
			Die();
	}

	protected virtual void Die()
	{
		dead = true;
	}
}
