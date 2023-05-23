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
		transform.position = new Vector3(transform.position.x + moveDelta.x, transform.position.y + moveDelta.y, transform.position.z);
	}

	private void OnCollisionEnter(Collision collision)
	{
		Vector3 normal = collision.contacts[0].normal;
		direction = Vector3.Reflect(direction, normal);
	}
}
