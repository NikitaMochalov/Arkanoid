using UnityEngine;

[RequireComponent(typeof(Platform))]
public class PlatformMovement : MonoBehaviour
{
	[SerializeField] private GameInput gameInput;
	[SerializeField] private float moveSpeed = 8f;

	[Header("Movement range")]
	[SerializeField] private float leftBorderPos = -5.8f;
	[SerializeField] private float rightBorderPos = 5.8f;

	private Platform platform;

	private void Awake()
	{
		if (platform == null)
			platform = GetComponent<Platform>();
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
		newXPos = Mathf.Clamp(newXPos, leftBorderPos + platform.width / 2, rightBorderPos - platform.width / 2);

		transform.position = new Vector3 (newXPos, transform.position.y, transform.position.z);
	}
}
