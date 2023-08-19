using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;



public class SoundManager : MonoBehaviour
{
    private static SoundManager inst = null;
    private void Awake()
    {
        if (null == inst)
        {
            inst = this; 
            DontDestroyOnLoad(inst);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    public static SoundManager Inst
    {
        get
        {
            if (null == inst)
            {
                return null;
            }
            return inst;
        }
    }

    public AudioMixer masterMixer;
    public Slider audioSlider;

    public void AudioControl()
    {
        var sound = audioSlider.value;

        print(sound);
        if (sound == -40f)
        {
            
            masterMixer.SetFloat("BGM", -80);
        }
        else
        {
            masterMixer.SetFloat("BGM", sound);
        }
    }
    
    public void ToggleAudioVolume()
    {
        AudioListener.volume = AudioListener.volume == 0 ? 1 : 0;
    }
}
