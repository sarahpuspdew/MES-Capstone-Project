using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BadgeUI : MonoBehaviour
{
    [SerializeField] float neededbadge;
    [SerializeField] TextMeshProUGUI badgeCount;
    float totalBadge;

    void Start()
    {
        badgeCount = GetComponent<TextMeshProUGUI>();
        totalBadge = neededbadge;
        badgeCount.text = "0/" + totalBadge;
    }

    public void UpdateBadgeText(PlayerInventory playerInventory)
    {
        badgeCount.text = playerInventory.collectibleItems.ToString() + "/" + neededbadge;
    }
}
