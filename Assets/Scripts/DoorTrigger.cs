using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{

    [SerializeField] private SlidingDoor doorControl;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" ){
            doorControl.Operate();
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" ){
            doorControl.Operate();
        }
    }
}
