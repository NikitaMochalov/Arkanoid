using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class FallArea : MonoBehaviour
{
	[SerializeField] private Player player;

	private void Awake()
	{
		if (player == null)
			player = FindObjectOfType<Player>();
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.TryGetComponent(out BallMovement ballMovement))
		{
			Debug.Log("Ball went through");

			player.balls.Remove(other.gameObject);
			Destroy(other.gameObject);

			if(player.balls.Count == 0)
				player?.TakeDamage(1);
		}
	}
}
