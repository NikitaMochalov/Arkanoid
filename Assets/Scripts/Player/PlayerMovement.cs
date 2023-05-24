using UnityEngine;

[RequireComponent(typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
	[SerializeField] private GameInput gameInput;
	[SerializeField] private float moveSpeed = 8f;

	[Header("Movement range")]
	[SerializeField] private float leftBorderPos = -5.8f;
	[SerializeField] private float rightBorderPos = 5.8f;

	private Player player;

	private void Awake()
	{
		if (player == null)
			player = GetComponent<Player>();
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
		newXPos = Mathf.Clamp(newXPos, leftBorderPos + player.width / 2, rightBorderPos - player.width / 2);

		transform.position = new Vector3 (newXPos, transform.position.y, transform.position.z);
	}
}
