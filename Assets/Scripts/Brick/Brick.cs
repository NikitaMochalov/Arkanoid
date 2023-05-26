using UnityEngine;

[RequireComponent(typeof(Health))]
public class Brick : MonoBehaviour
{
	[SerializeField] private Health health;

	private void Awake()
	{
		if (health == null)
			health = GetComponent<Health>();

		health.OnHealthDepleated.AddListener(Destruct);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.TryGetComponent(out BallMovement ball))
			health.TakeDamage(1);
	}

	void Destruct()
	{
		Destroy(gameObject);
	}
}
