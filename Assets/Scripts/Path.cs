using UnityEngine;
using System.Collections;

public class Path 
{
	private Transform[] _waypoints;
	private Vector2[] _waypointPositions;
	private int _currentWaypointIndex;

	public bool _isPathFinished;
	private bool _isPathLooped;

	public Path(Transform[] waypoints, bool isPathLoopable)
	{
		_waypoints = waypoints;
		_isPathLooped = isPathLoopable;

		_waypointPositions = new Vector2[waypoints.Length];
		_isPathFinished = false;
		_currentWaypointIndex = 0;

		for (int i = 0; i < waypoints.Length; i++) 
		{
			Vector2 position = new Vector2(waypoints[i].position.x, waypoints[i].position.y);
			_waypointPositions[i] = position;
		}
	}

	public Vector2 GetCurrentWaypoint()
	{
		return _waypointPositions [_currentWaypointIndex];
	}

	public void SetNextWaypoint()
	{
		_currentWaypointIndex++;

		if (_currentWaypointIndex >= _waypoints.Length)
		{
			if (_isPathLooped)
				_currentWaypointIndex = 0;
			else
			{
				_currentWaypointIndex = _waypoints.Length;
				_isPathFinished = true;
			}
		}
	}
}
