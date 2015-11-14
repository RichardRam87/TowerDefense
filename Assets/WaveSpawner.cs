using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Wave
{
	[SerializeField] private float timeBetweenSpawns;
	[SerializeField] private GameObject[] enemies;

	public GameObject[] GetEnemies()
	{
		return enemies;
	}

	public float GetTimeBetweenSpawns()
	{
		return timeBetweenSpawns;
	}
}

public class WaveSpawner : MonoBehaviour 
{
	[SerializeField] GameObject controlPanel;
	[SerializeField] Transform spawnPosition;
	[SerializeField] Wave[] waves;

	private List<GameObject> _activeEnemies;
	private int _currentWave;
	private bool isWaveActive;

	void Start()
	{
		_activeEnemies = new List<GameObject> ();
		_currentWave = 0;
		isWaveActive = false;
	}

	void Update()
	{
		if (isWaveActive) 
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
					controlPanel.SetActive(true);
					isWaveActive = false;
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
		GameObject[] enemyWave = waves [_currentWave].GetEnemies ();
		int waveLength = enemyWave.Length;
		float spawnDelay = waves [_currentWave].GetTimeBetweenSpawns ();
		int counter = 0;
		isWaveActive = true;

		while (counter < waveLength) 
		{
			GameObject enemy = Instantiate(enemyWave[counter], spawnPosition.position, Quaternion.identity) as GameObject;
			enemy.transform.SetParent(this.transform);
			_activeEnemies.Add(enemy);
			counter++;
			yield return new WaitForSeconds(spawnDelay);
		}
		_currentWave++;
		if (_currentWave >= waves.Length)
			_currentWave = waves.Length - 1;
	}
}
