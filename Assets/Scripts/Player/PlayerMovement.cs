using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private GameInput gameInput;
	[SerializeField] private float moveSpeed = 8f;

	[Header("Movement range")]
	[SerializeField] private float leftBorderPos = -4.8f;
	[SerializeField] private float rightBorderPos = 4.8f;

	private void Awake()
	{
		if (gameInput == null)
			gameInput = FindObjectOfType<GameInput>();
	}

	private void Update()
	{
		HandleMovement();
	}

	private void HandleMovement()
	{
		float moveDirection = gameInput.GetMovementValue();
		float moveDistance = moveSpeed * Time.deltaTime;

		float newXPos = transform.position.x + moveDistance * moveDirection;
		newXPos = Mathf.Clamp(newXPos, leftBorderPos, rightBorderPos);

		transform.position = new Vector3 (newXPos, transform.position.y, transform.position.z);
	}
}
