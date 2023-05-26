using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BricksManager : MonoBehaviour
{
	private int bricksCount = 0;
	public UnityEvent OnAllBricksDestroyed;

	private void Awake()
	{
		SetBricksOnDestructEvents();
	}

	private void SetBricksOnDestructEvents()
	{
		var bricks = FindObjectsOfType(typeof(Brick));
		bricksCount = bricks.Length;

		foreach (Brick brick in bricks)
			brick.OnDestruct.AddListener(OnBrickDestruct);
	}

	private void OnBrickDestruct()
	{
		if (--bricksCount == 0)
		{
			OnAllBricksDestroyed?.Invoke();
			Debug.Log($"bricksCount = {bricksCount}, all bricks destroyed");
		}
	}
}
