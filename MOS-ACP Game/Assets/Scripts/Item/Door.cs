using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    public enum Direction
    {
        x,
        y,
        z,
        xz
    }

    [SerializeField] float targetPos;
    [SerializeField] float originalPos;
    [SerializeField] float duration;

    public Direction dir;

    private void Start()
    {      
        SetOriginPos();
    }

    public void Open()
    {
        switch (dir) {
            case Direction.x :
                this.transform.DOMoveX(targetPos, duration).SetEase(Ease.Linear);
                break;
            case Direction.y :
                this.transform.DOMoveY(targetPos, duration).SetEase(Ease.Linear);
                break;
            case Direction.z :
                this.transform.DOMoveZ(targetPos, duration).SetEase(Ease.Linear);
                break;
            case Direction.xz :
                this.transform.DOMoveZ(targetPos, duration).SetEase(Ease.Linear);
                this.transform.DOMoveX(targetPos, duration).SetEase(Ease.Linear);
                break;
        }
    }

    public void Close()
    {
        switch (dir) {
            case Direction.x :
                this.transform.DOMoveX(originalPos, duration).SetEase(Ease.Linear);
                break;
            case Direction.y :
                this.transform.DOMoveY(originalPos, duration).SetEase(Ease.Linear);
                break;
            case Direction.z :
                this.transform.DOMoveZ(originalPos, duration).SetEase(Ease.Linear);
                break;
            case Direction.xz :
                this.transform.DOMoveZ(targetPos, duration).SetEase(Ease.Linear);
                this.transform.DOMoveX(targetPos, duration).SetEase(Ease.Linear);
                break;
        }
    }

    void SetOriginPos()
    {
        if (dir == Direction.x) {
            originalPos = transform.position.x;
        }
        if (dir == Direction.y) {
            originalPos = transform.position.y;
        }
        if (dir == Direction.z) {
            originalPos = transform.position.z;
        }
        if (dir == Direction.xz) {
            originalPos = transform.position.x;
            originalPos = transform.position.z;
        }
    }
}
