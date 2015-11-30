using UnityEngine;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour 
{
	[SerializeField] private float _movementSpeed;
	[SerializeField] private float _waypointRadius;

	private Path path;
	private Rigidbody2D _rb2d;

	void Awake()
	{
		_rb2d = GetComponent<Rigidbody2D> ();
		PathData waypoints = GameObject.FindGameObjectWithTag (Tags.path).GetComponent<PathData> ();
		path = new Path (waypoints.waypoints, waypoints.isLoopable);
	}

	void Update()
	{
		if (!path._isPathFinished) 
			MoveToWaypoint ();
		else
			Destroy (this.gameObject); //ugly fix, needs a revision
	}

	private void MoveToWaypoint()
	{
		Vector2 waypoint = path.GetCurrentWaypoint ();
		Vector2 moveDirection = waypoint - _rb2d.position;
		float angle = Mathf.Atan2 (moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

		_rb2d.position = Vector2.MoveTowards (_rb2d.position, waypoint, _movementSpeed * Time.deltaTime);
		_rb2d.MoveRotation (angle);

		if (moveDirection.magnitude <= _waypointRadius) 
			path.SetNextWaypoint();
	}
}
