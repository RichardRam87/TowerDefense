using UnityEngine;
using System.Collections;

[RequireComponent (typeof(TowerTarget))]
public class TowerShoot : MonoBehaviour 
{
	[SerializeField] private float _damage;
	[SerializeField] private float _cooldown;
	[SerializeField] private float _effectTimer;
	[SerializeField] private Transform _shootPosition;

	private TowerTarget _towerTarget;
	private LineRenderer _lineRenderer;
	private float _shootTimer;

	void Awake()
	{
		_towerTarget = GetComponent<TowerTarget> ();
		_lineRenderer = GetComponent<LineRenderer> ();
		_lineRenderer.sortingLayerName = "Projectiles";
	}

	void Start()
	{
		_lineRenderer.enabled = false;
	}
	void Update()
	{
		if (_towerTarget.GetTarget ()) 
		{
			if (_shootTimer >= _cooldown)
				Shoot();
		}
		_shootTimer += Time.deltaTime;  
	}

	void Shoot()
	{
		_lineRenderer.SetPosition (0, _shootPosition.position);
		_lineRenderer.SetPosition (1, _towerTarget.GetTarget ().transform.position);
		_lineRenderer.enabled = true;

		_towerTarget.GetTargetHealth().TakeDamage (_damage);
		_shootTimer = 0;

		Invoke ("DisableEffects", _effectTimer);
	}

	private void DisableEffects()
	{
		_lineRenderer.enabled = false;
	}
}
