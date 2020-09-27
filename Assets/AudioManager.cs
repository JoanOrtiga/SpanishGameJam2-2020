﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [System.Serializable]
    public class Sound
    {
        public string name;
        public AudioClip clip;

        [Range(0f, 1f)] public float volume;

        [HideInInspector] public AudioSource source;
        [HideInInspector] public float startVolume;
    }
    public Sound[] sounds;

    private AudioSource music;
    [SerializeField] private AudioClip[] musicClips;
    [Range(0f, 1f)] [SerializeField] private float MusicVolume;
    [Range(0f, 1f)] [SerializeField] private float SFXVolume;
    public static AudioManager AudioInstance;
    private Movement playerMovement;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;
    void Awake()
    {
        musicSlider = GameObject.FindGameObjectWithTag("MusicSlider").GetComponent<Slider>();
        sfxSlider = GameObject.FindGameObjectWithTag("sfxSlider").GetComponent<Slider>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        musicSlider.value = MusicVolume;
        sfxSlider.value = SFXVolume;
        musicSlider.onValueChanged.AddListener(SetVolumeMusic);
        sfxSlider.onValueChanged.AddListener(SetVolumeMusic);
        if (AudioInstance == null)
        {
            AudioInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        music = GetComponent<AudioSource>();
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.startVolume = s.volume;
        }
        MusicSetUp();
        DontDestroyOnLoad(gameObject);
    }
    public void SetVolumeSFX(float value)
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = s.startVolume * value;
        }
    }
    public void SetVolumeMusic(float value)
    {
        music.volume = MusicVolume * value;
    }
    private void MusicSetUp()
    {
        music.volume = MusicVolume;
        music.clip = musicClips[SceneManager.GetActiveScene().buildIndex];
        music.loop = true;
        music.Play();
    }
    private void OnLevelWasLoaded(int level)
    {
        print("a");
        musicSlider = GameObject.FindGameObjectWithTag("MusicSlider").GetComponent<Slider>();
        sfxSlider = GameObject.FindGameObjectWithTag("sfxSlider").GetComponent<Slider>();
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>();
        musicSlider.value = MusicVolume;
        sfxSlider.value = SFXVolume;
        musicSlider.onValueChanged.AddListener(SetVolumeMusic);
        sfxSlider.onValueChanged.AddListener(SetVolumeMusic);
    }
    void Update()
    {
        if (!music.isPlaying)
        {
            print("LEVEL COMPLETED");
        }
        if (playerMovement.isJumping)
        {
            sounds[UnityEngine.Random.Range(0, 3)].source.Play();
        }
        if (playerMovement.dashing && !sounds[3].source.isPlaying)
        {
            sounds[3].source.Play();
        }
    }
}