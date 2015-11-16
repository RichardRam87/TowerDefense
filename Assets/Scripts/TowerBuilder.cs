using UnityEngine;
using System.Collections;

public class TowerBuilder : MonoBehaviour 
{
	private int _layerMask;
	private GameObject _towersObject;

	void Start()
	{
		_layerMask = LayerMask.GetMask ("World");
		_towersObject = new GameObject ("Towers");
	}

	public void BuildTower(GameObject obj)
	{
		StopCoroutine("Build");
		StartCoroutine("Build", obj);
	}

	private IEnumerator Build(GameObject obj)
	{
		bool isBuilding = true;
	
		GameObject tower = Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
		tower.transform.SetParent (_towersObject.transform);

		TowerInputController towerInputController = tower.GetComponent<TowerInputController>();
		TowerShoot towerShoot = tower.GetComponent<TowerShoot>();
		TowerTarget towerTarget = tower.GetComponent<TowerTarget>();
		BoxCollider2D collider = tower.GetComponent<BoxCollider2D>();
		SpriteRenderer renderer = tower.GetComponent<SpriteRenderer>();
		Color defaultColor = renderer.color;

		collider.isTrigger = true;
		towerInputController.enabled = false;
		towerShoot.enabled = false;
		towerTarget.enabled = false;

		while (isBuilding)
		{
			Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector2 roundedPosition = new Vector2(Mathf.RoundToInt(mouseWorldPosition.x),
			                                      Mathf.RoundToInt(mouseWorldPosition.y));

			tower.transform.position = roundedPosition;

			RaycastHit2D[] hitInfo = Physics2D.RaycastAll(mouseWorldPosition, Vector2.zero, Mathf.Infinity, _layerMask);
			bool isPlaceAbleTile = CheckForPlaceablePosition(hitInfo);

			if (isPlaceAbleTile)
				renderer.color = Color.green;
			else
				renderer.color = Color.red;
		

			if (Input.GetMouseButtonDown(0) && isPlaceAbleTile)
				isBuilding = false;

			yield return new WaitForSeconds(0f);
		}

		towerInputController.enabled = true;
		towerShoot.enabled = true;
		towerTarget.enabled = true;
		renderer.color = defaultColor;
	}

	private bool CheckForPlaceablePosition(RaycastHit2D[] hitInfo)
	{
		foreach (RaycastHit2D hit in hitInfo) 
		{
			if (hit.transform.tag == "PathTile")
				return false;	
		}
		return true;
	}
}
