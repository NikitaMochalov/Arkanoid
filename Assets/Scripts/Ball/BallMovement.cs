using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    
	private Vector2 direction;

    public void StartMovement(Vector2 direction) => this.direction = direction;

	private void Update()
	{
		HandleMovement();
	}

	private void HandleMovement()
	{
		if (direction == null || direction == Vector2.zero)
			return;

		Vector2 moveDelta = direction * speed * Time.deltaTime;
		float newPosX = transform.position.x + moveDelta.x;
		float newPosY = transform.position.y + moveDelta.y;
		transform.position = new Vector3(newPosX, newPosY, transform.position.z);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.TryGetComponent(out Platform platform))
			ReflectDirectionFromPlatform(platform);
		else
			ReflectDirection(collision.contacts[0].normal);

	}

	private void ReflectDirectionFromPlatform(Platform platform)
	{
		float dX = platform.transform.position.x - transform.position.x;
		float reflectionArea = platform.width * 1.5f;
		float angle = dX / reflectionArea * Mathf.PI;
		direction = new Vector3(Mathf.Sin(-angle), Mathf.Cos(angle));
	}

	private void ReflectDirection(Vector3 normal)
	{
		direction = Vector3.Reflect(direction, normal);
	}
}
