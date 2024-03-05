using UnityEngine;

public class Ball : MonoBehaviour
{
  [SerializeField] private GameObject sprite;
  [SerializeField] private float speed = 5;
  private Vector2 _direction = new(-1, 1); // Starts to up left
  private Vector2Int _hitBorder = Vector2Int.zero;
  private Vector2 _objectSize;
  private Vector2 _screenBounds;

  private void Start()
  {
    _screenBounds = Camera.main.ScreenToWorldPoint(
      new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    _objectSize = sprite.transform.GetComponent<SpriteRenderer>().bounds.size;
  }

  private void Update()
  {
    transform.position += (Vector3)_direction.normalized * speed * Time.deltaTime;
  }

  private void LateUpdate()
  {
    Vector3 pos = transform.position;
    if (pos.x - _objectSize.x / 2 <= -_screenBounds.x || pos.x + _objectSize.x / 2 >= _screenBounds.x)
    {
      if (_hitBorder.x == 1) return;
      _hitBorder.x = 1;
      _direction.x *= -1;
    }
    else
    {
      _hitBorder.x = 0;
    }

    if (pos.y - _objectSize.y / 2 <= -_screenBounds.y || pos.y + _objectSize.y / 2 >= _screenBounds.y)
    {
      if (_hitBorder.y == 1) return;
      _hitBorder.y = 1;
      _direction.y *= -1;
    }
    else
    {
      _hitBorder.y = 0;
    }
  }
}
