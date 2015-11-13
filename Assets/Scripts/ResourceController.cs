using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ResourceController : MonoBehaviour 
{
	[SerializeField] private Text _resourceText;
	[SerializeField] private float _startValue;

	private float _resource;

	public static ResourceController instance;

	void Awake()
	{
		if (instance == null)
			instance = this;
		else
			instance = null;
	}

	void Start()
	{
		SetResource (_startValue);
	}

	public void SetResource(float value)
	{
		_resource = value;
		UpdateUI ();
	}

	public void AddResource (float value)
	{
		_resource += value;
		UpdateUI ();
	}

	private void UpdateUI()
	{
		_resourceText.text = "Resource: " + _resource.ToString ();
	}
}
