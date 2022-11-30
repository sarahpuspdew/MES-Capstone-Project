using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badge : MonoBehaviour
{
    float speed = 50.0f;
    public PromptTrigger promptTrigger;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null) {
            playerInventory.BadgeCollected();
            promptTrigger.TriggerPrompt();
            gameObject.SetActive(false);
        }
    }
}