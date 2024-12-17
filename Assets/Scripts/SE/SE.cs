using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    [SerializeField]
    private AudioClip sound;

    [SerializeField]
    public AudioSource SESource;

    private void Awake()
    {
        SESource = GetComponent<AudioSource>();
    }

    public void SoundEffct()
    {
        SESource.PlayOneShot(sound);
    }
}
