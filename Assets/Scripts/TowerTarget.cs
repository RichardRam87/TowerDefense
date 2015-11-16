using UnityEngine;
using System.Collections;

public class TowerTarget : MonoBehaviour 
{
	private GameObject _target;
	private EnemyHealth _targetHealth;
	[SerializeField] private float _targettingRadius;

	private int _layerMask;

	void Start()
	{
		_layerMask = LayerMask.GetMask ("Enemy");
	}

	void Update () 
	{
		Collider2D[] colliders = Physics2D.OverlapCircleAll (this.transform.position, 
		                                          _targettingRadius, 
		                                          _layerMask);
		if (colliders.Length != 0) 
		{

			_target = FindClosestTarget(colliders);
			_targetHealth = _target.GetComponent<EnemyHealth> ();
		} else 
			_target = null;

	}

	private GameObject FindClosestTarget(Collider2D[] colliders)
	{
		GameObject closestTarget = null;
		float shortestDistance = float.MaxValue;
		int length = colliders.Length;

		for (int i = 0; i < length; i++) 
		{
			float distance = Vector2.Distance(this.transform.position, colliders[i].transform.position);

			if (distance < shortestDistance)
			{
				closestTarget = colliders[i].gameObject;
				shortestDistance = distance;
			}
		}
		return closestTarget;
	}


	public void SetRadius(float amount)
	{
		_targettingRadius = amount;
	}

	public GameObject GetTarget()
	{
		if (_target != null)
			return _target;
		else
			return null;
	}

	public EnemyHealth GetTargetHealth()
	{
		if (_targetHealth != null)
			return _targetHealth;
		else
			return null;
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere (this.transform.position, _targettingRadius);
	}
}
