using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour 
{
	[SerializeField] private float _deathValue;
	[SerializeField] private Slider healthbarSlider;
	[SerializeField] private Image fillImage; 

	[SerializeField] Color _zeroHealthColor;
	[SerializeField] Color _fullHealthColor;

	private float _maxHealth = 100;
	private float _currentHealth;

	void Start()
	{
		_currentHealth = _maxHealth;
		UpdateUI ();
	}

	public void TakeDamage(float amount)
	{
		_currentHealth -= amount;
		UpdateUI ();

		if (_currentHealth <= 0)
			Kill ();
	}

	private void Kill()
	{
		ResourceController.instance.AddResource (_deathValue);
		Destroy (this.gameObject);
	}

	private void UpdateUI()
	{
		healthbarSlider.value = _currentHealth / _maxHealth;

		fillImage.color = Color.Lerp (_zeroHealthColor, _fullHealthColor, _currentHealth / _maxHealth);
	}
}
