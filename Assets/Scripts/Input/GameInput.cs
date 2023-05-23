using UnityEngine;

public class GameInput : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

	private void Awake()
	{
		playerInputActions = new PlayerInputActions();
		playerInputActions.Player.Enable();
	}

	public float GetMovementValue() => playerInputActions.Player.Move.ReadValue<float>();
}
