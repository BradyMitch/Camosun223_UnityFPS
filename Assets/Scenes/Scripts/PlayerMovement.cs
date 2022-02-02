using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    private Rigidbody playerRB;

    private float force = 100f;
    [SerializeField] private float speed = 10f;

    private float hori;
    private float vert;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        hori = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        
        //transform.Translate(new Vector3(hori, 0, vert) * Time.deltaTime * speed);
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(hori, 0, vert) * force * speed * Time.deltaTime;
        //playerRB.AddForce(move);
        //playerRB.MovePosition(playerRB.position + move);
        playerRB.velocity = move;
    }
}
