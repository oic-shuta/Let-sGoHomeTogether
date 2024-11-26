using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPos : MonoBehaviour
{
    [SerializeField]
    private Collider2D coll2D;

    [SerializeField]
    private PlayerAttack attack;

    [SerializeField]
    private Vector3 ofSet = Vector3.zero;

    [SerializeField]
    public bool movePos = false;


    private void Start()
    {
        coll2D = GetComponent<Collider2D>();

        ofSet = coll2D.offset;
    }
    private void Update()
    {
        if (attack.attackPlayer)
        {

        }
    }
}
