using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSE : MonoBehaviour
{
    private AudioSource Source;

    [SerializeField]
    private AudioClip walkSE;

    [SerializeField]
    private AudioClip attackSE;

    [SerializeField]
    private AudioClip jumpSE;


    private void Start()
    {
        Source = GetComponent<AudioSource>();   
    }

    public void WalkSound()
    {
        Source.PlayOneShot(walkSE);
    }
    public void AttackSound()
    {
        Source.PlayOneShot(attackSE);
    }
    public void JumpSound()
    {
        Source.PlayOneShot(jumpSE);
    }

    public void SoundStop()
    {
        Source.Stop();
    }
}
