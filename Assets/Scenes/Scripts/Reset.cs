using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    [SerializeField] private Rigidbody player;
    [SerializeField] private Rigidbody ball;

    // Start is called before the first frame update
    public void ResetGame()
    {
        ball.Sleep();
        ball.MovePosition(new Vector3(13,1,-18));
        player.MovePosition(new Vector3(18,1.1f,-18));
    }
}
