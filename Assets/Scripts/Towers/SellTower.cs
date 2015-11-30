using UnityEngine;
using System.Collections;

public class SellTower : MonoBehaviour 
{
	[SerializeField] private float sellAmount;

	public void Sell()
	{
		ResourceController.instance.AddResource (sellAmount);

		Destroy (this.gameObject);
	}
}
