﻿using UnityEngine;
using System.Collections;

public class DeactivateOnStart : MonoBehaviour 
{
	void Start()
	{
		this.gameObject.SetActive (false);
	}
}
