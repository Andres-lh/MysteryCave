using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;
    // Start is called before the first frame update
    void Start()
    {
        LoadValues();
    }

    public void VolumeSlide(float volume)
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("Volume", volumeValue);
        LoadValues();
    }

    private void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("Volume");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue; 
    }
}
