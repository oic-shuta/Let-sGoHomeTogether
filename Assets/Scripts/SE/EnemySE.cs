using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySE : MonoBehaviour
{
    private AudioSource m_AudioSource;

    [SerializeField]
    private AudioClip WolfwalkSE;

    [SerializeField]
    private AudioClip WolfdownSE;

    [SerializeField]
    private AudioClip GhostdownSE;

    // Start is called before the first frame update
    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Wolfwalk()
    {
        m_AudioSource.PlayOneShot(WolfwalkSE);
    }

    public void Wolfdown()
    {
        m_AudioSource.PlayOneShot(WolfdownSE);
    }
    public void Ghostdown()
    {
        m_AudioSource.PlayOneShot(GhostdownSE);
    }

    public void Soundstop()
    {
        m_AudioSource.Stop();
    }
}
