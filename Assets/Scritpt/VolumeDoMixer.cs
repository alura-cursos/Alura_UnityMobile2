using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeDoMixer : MonoBehaviour {
    [SerializeField]
    private AudioMixer mixer;
    [SerializeField]
    private string parametroDoMixer;

    private void Start()
    {
        if (PlayerPrefs.HasKey(this.parametroDoMixer))
        {
            this.mixer.SetFloat(this.parametroDoMixer, PlayerPrefs.GetFloat(this.parametroDoMixer));
        }
        else
        {
            this.mixer.SetFloat(this.parametroDoMixer, 0);
        }
    }
    public void MudarVolume(float volume)
    {
        this.mixer.SetFloat(this.parametroDoMixer, volume);
        PlayerPrefs.SetFloat(this.parametroDoMixer, volume);
    }
}
