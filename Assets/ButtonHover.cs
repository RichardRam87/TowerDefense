using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public void OnPointerEnter (PointerEventData eventData)
	{
		Debug.Log("Pointer enter");
	}

	public void OnPointerExit (PointerEventData eventData)
	{
		Debug.Log("Pointer exit");
	}
}
