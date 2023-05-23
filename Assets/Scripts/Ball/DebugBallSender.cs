using UnityEngine;

public class DebugBallSender : MonoBehaviour
{
	Vector2 direction;

	private void Start()
	{
		direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
		FindObjectOfType<BallMovement>().StartMovement(direction);
	}
}
