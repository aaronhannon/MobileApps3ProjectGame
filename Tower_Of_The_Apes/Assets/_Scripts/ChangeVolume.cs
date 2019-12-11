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

    //Gets the value of the slider and sets the mixer to that value. As the Mixer volume and the slider
    // Values are NOT 1:1 / directly proportional you must do this "Mathf.Log10(slider.value) * 20"
    public void changeVol(float sliderValue)
    {
        slider = gameObject.GetComponent<Slider>();
        mixer.SetFloat("MusicVol", Mathf.Log10(slider.value) * 20);
    }


}
