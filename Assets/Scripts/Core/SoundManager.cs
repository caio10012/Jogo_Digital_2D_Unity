using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public static SoundManager instance { get; private set; }
    private AudioSource source;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
        source = GetComponent<AudioSource>();
        //keep object even if we change scene
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }   
        else if(instance != this && instance != this) 
            Destroy(gameObject);
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlaySound(AudioClip _Sound)
    {
        source.PlayOneShot(_Sound);
    }
}
