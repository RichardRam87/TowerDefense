using UnityEngine;
using System.Collections;

public class TowerBuilder : MonoBehaviour 
{
	public void BuildTower(GameObject obj)
	{
		StopCoroutine("Build");
		StartCoroutine("Build", obj);
	}

	private IEnumerator Build(GameObject obj)
	{
		bool isBuilding = true;
	
		// RaycastHit spawnPosition = Camera.main.ScreenPointToRay(Input.mousePosition);
		GameObject tower = Instantiate(obj, Vector3.zero, Quaternion.identity) as GameObject;
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
			/*
			RaycastHit2D hitInfo = Physics2D.Linecast(mouseWorldPosition, Vector2.zero);
			Debug.Log(hitInfo);
			if (hitInfo != null && hitInfo.transform.gameObject != tower)
			{
				Debug.Log(hitInfo.transform.gameObject);
				if (hitInfo.transform.tag != "Background")
					renderer.color = Color.red;
				else
					renderer.color = Color.green;
			}
			*/
			if (Input.GetMouseButtonDown(0) && hitInfo != null)
				isBuilding = false;

			yield return new WaitForSeconds(0.01f);
		}

		towerInputController.enabled = true;
		towerShoot.enabled = true;
		towerTarget.enabled = true;
		renderer.color = defaultColor;
	}
}
