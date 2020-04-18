using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioClip click;
    [SerializeField] private AudioClip falseClick;
    [SerializeField] private AudioClip questClick;
    [SerializeField] private AudioClip timeOut;

    private AudioSource audioSource;

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();
    }

    public void Click()
    {
        audioSource.clip = click;
        audioSource.Play();
    }
    public void FalseClick()
    {
        audioSource.clip = falseClick;
        audioSource.Play();
    }
    public void QuestClick()
    {
        audioSource.clip = questClick;
        audioSource.Play();
    }
    public void TimeOut()
    {
        audioSource.clip = timeOut;
        audioSource.Play();
    }
}

