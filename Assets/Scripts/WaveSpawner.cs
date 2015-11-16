using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Wave
{
	[SerializeField] private float _timeBetweenSpawns;
	[SerializeField] private GameObject[] _enemies;

	public GameObject[] GetEnemies()
	{
		return _enemies;
	}

	public float GetTimeBetweenSpawns()
	{
		return _timeBetweenSpawns;
	}
}

public class WaveSpawner : MonoBehaviour 
{
	[SerializeField] GameObject _controlPanel;
	[SerializeField] Transform _spawnPosition;
	[SerializeField] Wave[] _waves;

	private List<GameObject> _activeEnemies;
	private int _currentWave;
	private bool _isWaveActive;

	void Start()
	{
		_activeEnemies = new List<GameObject> ();
		_currentWave = 0;
		_isWaveActive = false;
	}

	void Update()
	{
		if (_isWaveActive) 
		{
			if (_activeEnemies.Contains (null)) 
			{
				for (int i = 0; i < _activeEnemies.Count; i++) 
				{
					if (_activeEnemies[i] == null)
						_activeEnemies.RemoveAt (i);
				}

				if (_activeEnemies.Count == 0)
				{
					_controlPanel.SetActive(true);
					_isWaveActive = false;
				}
			}
		}
	}

	public void SpawnNextWave()
	{
		StopCoroutine ("SpawnEnemies");
		StartCoroutine ("SpawnEnemies");
	}

	private IEnumerator SpawnEnemies()
	{
		GameObject[] enemyWave = _waves [_currentWave].GetEnemies ();
		int waveLength = enemyWave.Length;
		float spawnDelay = _waves [_currentWave].GetTimeBetweenSpawns ();
		int counter = 0;
		_isWaveActive = true;

		while (counter < waveLength) 
		{
			GameObject enemy = Instantiate(enemyWave[counter], _spawnPosition.position, Quaternion.identity) as GameObject;
			enemy.transform.SetParent(this.transform);
			_activeEnemies.Add(enemy);
			counter++;
			yield return new WaitForSeconds(spawnDelay);
		}
		_currentWave++;
		if (_currentWave >= _waves.Length)
			_currentWave = _waves.Length - 1;
	}
}
