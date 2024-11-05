using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTracking : MonoBehaviour
{
    [SerializeField]
    private PlayerController playerController;

    [SerializeField]
    private GameObject trackingPlayer;

    [SerializeField]
    private GameObject PlayerChibiyowa;

    [SerializeField]
    private GameObject PlayerDekatuyo;

    [SerializeField]
    private GameObject trackingLeft;

    [SerializeField]
    private GameObject trackingRight;

    [SerializeField]
    public bool trackingFlg = false;

    private void Update()
    {
        TrackigPlayer();

        TrackingPos();
    }
    private void TrackigPlayer()
    {
        if (Input.GetKeyDown("t"))
        {
            trackingFlg = !trackingFlg;
        }
        if (trackingFlg)
        {
            if (playerController.playerDekatuyo)
            {
                trackingPlayer = PlayerChibiyowa;
            }
            else if (!playerController.playerDekatuyo)
            {
                trackingPlayer = PlayerDekatuyo;
            }
        }
        else if (!trackingFlg)
        {
            trackingPlayer = null;
        }
    }

    private void TrackingPos()
    {
        if (trackingFlg){
               trackingPlayer.transform.position = this.transform.position;
        }
    }
}
