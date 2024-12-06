using JetBrains.Annotations;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance { get; private set; }
    private AudioSource source;
    private AudioSource musicSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        musicSource =transform.GetChild(0).GetComponent<AudioSource>();
        //keep object even if we change scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }   
        else if(instance != this && instance != this) 
            Destroy(gameObject);
        
        ChangeMusicVolume(0);
        ChangeSoundVolume(0);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(AudioClip _Sound)
    {
        source.PlayOneShot(_Sound);
    }

  public void ChangeSoundVolume(float _change)
    {
       ChangeSourceVolume(1, "soundVolume", _change, source);
    }
    public void ChangeMusicVolume(float _change)
    {

        ChangeSourceVolume(0.3f, "music_Volume", _change, musicSource);
    }
    private void ChangeSourceVolume(float baseVolume, string volumeName, float change, AudioSource source1)
    {
        float currentVolume = PlayerPrefs.GetFloat(volumeName, 1);
        currentVolume += change;
        if (currentVolume > 1)
            currentVolume = 0;
        else if (currentVolume < 0)
            currentVolume = 1;
        float finalVolume = currentVolume * baseVolume;
        source1.volume = finalVolume;
        PlayerPrefs.SetFloat(volumeName, currentVolume);
    }
}
