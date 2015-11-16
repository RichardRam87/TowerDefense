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
		Collider2D col = Physics2D.OverlapCircle (this.transform.position, 
		                                          _targettingRadius, 
		                                          _layerMask);
		if (col) 
		{
			_target = col.gameObject;
			_targetHealth = _target.GetComponent<EnemyHealth>();
		}
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
