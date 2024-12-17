using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodSE : MonoBehaviour
{
    [SerializeField]
    private AudioSource Source;

    [SerializeField]
    private AudioClip woodDamage;

    [SerializeField]
    private AudioClip woodDown;

    [SerializeField]
    private AudioClip woodBreak;

    private void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    public void DamageWood()
    {
        Source.PlayOneShot(woodDamage);
    }
    public void DownWood()
    {
        Source.PlayOneShot(woodDown);
    }
    public void BreakWood()
    {
        Source.PlayOneShot(woodBreak);
    }
}
