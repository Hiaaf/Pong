using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;

    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
    }

    private static float HitFactor(Vector2 ballPos, Vector2 padlePos, float padleSize) =>
        (ballPos.y - padlePos.y) / padleSize;
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.name.StartsWith("Paddle")) return;
        
        float y = HitFactor(transform.position, other.transform.position,
            other.collider.bounds.size.y);
        direction = new Vector2(-direction.x, y);

        GetComponent<Rigidbody2D>().velocity = direction.normalized * speed;
    }
}
