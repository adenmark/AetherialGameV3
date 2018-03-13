using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioVolumeSlider: MonoBehaviour
{
    public Slider VolumeSlider;

    public void onvaluechanged()
    {
        Debug.Log(VolumeSlider.value);
        AudioListener.volume = VolumeSlider.value;
    }
}


