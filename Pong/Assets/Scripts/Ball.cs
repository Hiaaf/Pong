using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	[SerializeField] private GameObject sprite;
	[SerializeField] private float speed = 5;
	private Vector2 _direction = new(-1, 1); // Starts to up left
	
	private void Update()
	{
		transform.position += (Vector3)_direction.normalized * speed * Time.deltaTime;
	}
}
