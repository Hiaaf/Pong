using UnityEngine;

public class KeepInBounds : MonoBehaviour
{
	[SerializeField] private GameObject sprite;
	private Vector2 _screenBounds;
	private Vector2 _objectSize;

	private void Start()
	{
		_screenBounds = Camera.main.ScreenToWorldPoint(
			new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		_objectSize = sprite.transform.GetComponent<SpriteRenderer>().bounds.size;
	}

	private void LateUpdate()
	{
		Vector3 viewPos = transform.position;
		viewPos.x = Mathf.Clamp(
			viewPos.x, -1 * _screenBounds.x + _objectSize.x / 2, _screenBounds.x - _objectSize.x / 2);
		viewPos.y = Mathf.Clamp(
			viewPos.y, -1 * _screenBounds.y + _objectSize.y / 2, _screenBounds.y - _objectSize.y / 2);
		transform.position = viewPos;
	}
}