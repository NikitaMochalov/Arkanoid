using System;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Health health;
	public event Action OnLost; 
	public event Action OnHealthChanged;

	public List<GameObject> balls;

	private void Awake()
	{
		if (health == null)
			health = GetComponent<Health>();

		health.OnHealthChanged.AddListener(ChangeHealth);
		health.OnHealthDepleated.AddListener(Lose);

		//balls.Add(FindObjectOfType<BallMovement>().gameObject);
		foreach (var ballMovement in FindObjectsOfType<BallMovement>())
			balls.Add(ballMovement.gameObject);
	}

	public void TakeDamage(int amount)
	{
		Debug.Log("Player took damage");
		health.TakeDamage(amount);
	}

	private void Lose()
	{
		GameManager.Instance.UpdateGameState(GameState.Lose);

		OnLost?.Invoke();
	}

	private void ChangeHealth(int changedAmount)
	{
		// TODO: change health UI

		OnHealthChanged?.Invoke();
	}

	private void OnDestroy()
	{
		health.OnHealthChanged.RemoveListener(ChangeHealth);
		health.OnHealthDepleated.RemoveListener(Lose);
	}
}
