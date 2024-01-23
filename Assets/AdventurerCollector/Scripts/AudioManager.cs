using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] List<AudioClip> audios;
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        
    }
    void Start()
    {
    }

    void Update()
    {
        
    }
    public void PlayAudioClip(int indexList)
    {
        _audioSource.clip = audios[indexList];
        _audioSource.Play();
    }

}