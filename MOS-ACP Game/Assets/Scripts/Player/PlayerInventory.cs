using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int collectibleItems { get; private set;}

    public UnityEvent<PlayerInventory> onBadgeCollected;

    public void BadgeCollected()
    {
        collectibleItems++;
        onBadgeCollected.Invoke(this);
    }
}