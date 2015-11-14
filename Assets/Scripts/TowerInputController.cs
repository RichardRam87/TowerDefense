using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TowerInputController : MonoBehaviour, IPointerClickHandler
{
	[SerializeField] private GameObject towerPanelUI;
	private bool _isSelected;

	void Start()
	{
		_isSelected = false;
		towerPanelUI.SetActive (_isSelected);
	}

	public void OnPointerClick (PointerEventData eventData)
	{
		_isSelected = _isSelected ? false : true;
		towerPanelUI.SetActive (_isSelected);
		// Debug.Log(_isSelected);
	}
}
