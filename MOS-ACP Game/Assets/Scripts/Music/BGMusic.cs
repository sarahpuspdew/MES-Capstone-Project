using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class BGMusic : MonoBehaviour
{
    public static BGMusic instance;
    [SerializeField] Slider volumeSlider;
 
    void Awake()
    {
        if (instance != null) {
            Destroy(gameObject);
        }
        else {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}