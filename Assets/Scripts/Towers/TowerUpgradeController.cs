﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class TowerUpgrade
{
	public float upgradeCost;
	public Sprite newSprite;
	public float newRadius;
	public float newDamage;
	public float newCooldown;
}

public class TowerUpgradeController : MonoBehaviour 
{
	[SerializeField] TowerUpgrade[] upgrades;

	private TowerTarget _towerTarget;
	private TowerShoot _towerShoot;
	private SpriteRenderer _renderer;
	private int currentUpgrade;
	private int maxAmountOfUpgrades;

	void Awake()
	{
		_towerTarget = GetComponent<TowerTarget> ();
		_towerShoot = GetComponent<TowerShoot> ();
		_renderer = GetComponent<SpriteRenderer> ();

		currentUpgrade = 0;
		maxAmountOfUpgrades = upgrades.Length;
	}

	public void UpgradeTower()
	{
		if (currentUpgrade != maxAmountOfUpgrades) 
		{
			float cost = upgrades [currentUpgrade].upgradeCost;
			if (ResourceController.instance.CanAffortAmount(cost))
			{
				ResourceController.instance.AddResource(-cost);
				_renderer.sprite = upgrades [currentUpgrade].newSprite;
				_towerTarget.SetRadius (upgrades [currentUpgrade].newRadius);
				_towerShoot.SetDamage (upgrades [currentUpgrade].newDamage);
				_towerShoot.SetCooldown (upgrades [currentUpgrade].newCooldown);
				
				currentUpgrade++;
				if (currentUpgrade >= maxAmountOfUpgrades)
				{
					currentUpgrade = maxAmountOfUpgrades;
					// update tower UI (remove update option)
				}
			}
			else
				Debug.Log("not enough money");
		}
		else
			Debug.Log("Already max upgraded");
	}
}
