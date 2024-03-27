using System;
using System.Collections;
using System.Collections.Generic;
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
                float vertical = Input.GetAxisRaw(axis);
                GetComponent<Rigidbody2D>().velocity = new Vector2(0, vertical) * speed;
                break;
            case PlayerType.Bot:
                transform.position = Vector2.MoveTowards(
                    transform.position,
                    new Vector2(transform.position.x, target.transform.position.y),
                    speed);
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
