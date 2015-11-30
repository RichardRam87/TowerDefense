using UnityEngine;
using System.Collections;

public class PathData : MonoBehaviour 
{
	public Transform[] waypoints;
	public bool isLoopable;

	private void OnDrawGizmos()
	{
		Gizmos.color = Color.blue;
		for (int i = 0; i < waypoints.Length; i++)
		{
			if (i > 0)
			{
				Vector3 from = waypoints[i-1].position;
				Vector3 to = waypoints[i].position;
				Gizmos.DrawLine(from, to);

				if (isLoopable && i == waypoints.Length - 1)
				{
					Vector3 lastFrom = waypoints[i].position;
					Vector3 lastTo = waypoints[0].position;
					Gizmos.DrawLine(lastFrom, lastTo);
				}
			}
		}
	}
}
