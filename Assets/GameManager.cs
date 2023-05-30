using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

	private void Awake()
	{
		Instance = this;
	}

	// Events
	public static event Action<GameState> OnGameStateChanged;

	public GameState gameState;

	public void UpdateGameState(GameState newState)
	{
		gameState = newState;

		switch (newState)
		{
			case GameState.Pause:
				HandlePause();
				break;
			case GameState.Playing:
				HandlePlaying();
				break;
			case GameState.Victory:
				HandleVictory();
				break;
			case GameState.Lose:
				HandleLose();
				break;
			default:
				break;
		}
		Debug.Log($"Game state changed to {newState} state");
		OnGameStateChanged?.Invoke(newState);
	}

	private void HandleVictory()
	{
	}

	private void HandlePause()
	{
	}

	private void HandlePlaying()
	{
	}

	private void HandleLose()
	{
	}

	private void Start()
	{
		UpdateGameState(GameState.Playing);
	}
}

public enum GameState
{
	MainMenu,
	Pause,
	Playing,
	Lose,
	Victory
}
