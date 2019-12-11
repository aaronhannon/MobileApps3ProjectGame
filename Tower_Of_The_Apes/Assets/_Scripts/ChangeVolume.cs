using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

//Tutorial FROM : https://www.youtube.com/watch?v=xNHSGMKtlv4
public class ChangeVolume : MonoBehaviour
{
    public AudioMixer mixer;
    private Slider slider;
     public void changeVol(float sliderValue)
    {
        slider = gameObject.GetComponent<Slider>();
        Debug.Log("IN IN IN");
        mixer.SetFloat("MusicVol", Mathf.Log10(slider.value) * 20);
    }


}
