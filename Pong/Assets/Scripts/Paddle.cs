using System;
using Unity.VisualScripting;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private string axis;
    [SerializeField] private PlayerType playerType;
    [SerializeField] private GameObject target;
    
    private void Update()
    {
        switch (playerType)
        {
            case PlayerType.Player:
                float verticalP = Input.GetAxisRaw(axis);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, verticalP) * speed;
                break;
            case PlayerType.Bot:
                float verticalB = target.transform.position.y - transform.position.y;
                float verticalBSign = Mathf.Sign(verticalB);
                verticalB = Mathf.Clamp(Mathf.Abs(verticalB), 0, speed);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, verticalB * verticalBSign) * speed;
                break;
        }
    }
    
    [Serializable]
    private enum PlayerType
    {
        Player,
        Bot
    }
}
