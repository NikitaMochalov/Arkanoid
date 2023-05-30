using UnityEngine;

public class DebugBallSender : MonoBehaviour
{
	Vector2 direction;

	private void Start()
	{
		//direction = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
		direction = new Vector2(0, -1);
		foreach (var ballMovement in FindObjectsOfType<BallMovement>())
			ballMovement.StartMovement(direction);
	}
}
