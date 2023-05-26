using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int health;
    [SerializeField] private int maxHealth;

	public UnityEvent<int> OnHealthChanged;
	public UnityEvent OnHealthDepleated;

	public void TakeDamage(int damage)
	{
		health = Mathf.Clamp(health - damage, 0, maxHealth);

		if (health <= 0)
			OnHealthDepleated?.Invoke();
		else
			OnHealthChanged?.Invoke(health);
	}

}
