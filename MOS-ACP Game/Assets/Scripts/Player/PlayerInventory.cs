using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public int collectibleItems { get; private set;}

    public void BadgeCollected()
    {
        collectibleItems++;
    }
}