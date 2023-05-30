using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FallArea : MonoBehaviour
{
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.TryGetComponent(out BallMovement ballMovement))
		{
			Debug.Log("Ball went through");
			Destroy(other.gameObject);

			// TODO: Check if there is other balls

			// TODO: invoke event after losing the ball
		}
	}
}
