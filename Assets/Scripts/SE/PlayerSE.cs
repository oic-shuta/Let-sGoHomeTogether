using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

    [SerializeField]
    private AudioClip carryOn;

    [SerializeField]
    private AudioClip carryOff;


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
    public void CarrySound()
    {
        Source.PlayOneShot(carryOn);
    }
    public void CarryOutSound()
    {
        Source.PlayOneShot(carryOff);
    }

    public void SoundStop()
    {
        Source.Stop();
    }
}
