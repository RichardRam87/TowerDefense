using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	[SerializeField] private int _maxLives = 3;
	private int _currentLives;

	public enum GameState
	{
		GameStartup,
		BuildState,
		FightState
	}
	
	private GameState gameState;

	void Start()
	{
		ChangeGameState (GameState.BuildState);
	}

	public void ChangeGameState(GameState state)
	{
		gameState = state;

		switch (gameState)
		{
			case GameState.GameStartup:
				OnGameStartUp();
				break;
			case GameState.BuildState:
				break;

			case GameState.FightState:
				OnFightState();
				break;
		}
	}

	private void OnGameStartUp()
	{
		_currentLives = _maxLives;
		ChangeGameState(GameState.BuildState);
	}

	private void OnFightState()
	{
		// check if still fighting & player is alive..
		// if not, go to gameover
		// if fighting is over, back to build state
	}
}
