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

	private void LateUpdate()
	{
		// Se a bola bater nas bordas, muda a direção dela
		Vector2 screenBounds = Camera.main.ScreenToWorldPoint(
			new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		Vector2 objectSize = sprite.transform.GetComponent<SpriteRenderer>().bounds.size;

		Vector3 viewPos = transform.position;
		if (viewPos.y < -screenBounds.y + objectSize.y / 2 || viewPos.y > screenBounds.y - objectSize.y / 2)
		{
			_direction.y *= -1;
		}

		if (viewPos.x < -screenBounds.x + objectSize.x / 2 || viewPos.x > screenBounds.x - objectSize.x / 2)
		{
			_direction.x *= -1;
		}
	}
}
