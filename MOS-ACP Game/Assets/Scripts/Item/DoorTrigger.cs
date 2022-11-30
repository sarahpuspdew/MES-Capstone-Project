using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] GameObject door;
    int count = 0;

    bool isOpened = false;

    private void OnTriggerEnter(Collider other) {
        if (!isOpened) {
            door.GetComponent<Door>().Open();
            isOpened = true;
        }
        
        count++;
    }

    private void OnTriggerExit(Collider other) {
        count--;
        
        if (count<=0) {
           door.GetComponent<Door>().Close();
            isOpened = false; 
        }
    }
}
