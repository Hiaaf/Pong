using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Padle : MonoBehaviour
{
	[Serializable]
	private enum ControlType
	{
		Player,
		Bot
	}

	[SerializeField] private ControlType controlType;
	[SerializeField] private float speed = 10;

	private void Update()
	{
		Vector2 velocity = Vector2.zero;

		switch (controlType)
		{
			case ControlType.Player:
				if (Input.GetKey(KeyCode.UpArrow))
				{
					velocity = Vector2.up;
				}
				else if (Input.GetKey(KeyCode.DownArrow))
				{
					velocity = Vector2.down;
				}

				break;

			case ControlType.Bot:
				velocity = new Vector2(0, Random.Range(-1, 1 + 1));
				break;
		}

		transform.position += (Vector3)velocity * speed * Time.deltaTime;
	}
}