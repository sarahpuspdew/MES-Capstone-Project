using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Badge : MonoBehaviour
{
    [SerializeField] AudioClip badgePickUpSound;
    float speed = 50.0f;
    public InfoTrigger infoTrigger;

    private void FixedUpdate()
    {
        transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();

        if (playerInventory != null) {
            AudioSource.PlayClipAtPoint(badgePickUpSound, -transform.position, 0.5f);
            playerInventory.BadgeCollected();
            infoTrigger.TriggerInfo();
            gameObject.SetActive(false);
        }
    }
}