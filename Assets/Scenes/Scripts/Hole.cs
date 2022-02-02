using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{

    public GameObject winTextObject;

    private void Start()
    {
        winTextObject.SetActive(false);
    }

    // Start is called before the first frame update
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            collision.gameObject.SetActive(false);
            winTextObject.SetActive(true);
        }
    }
}
