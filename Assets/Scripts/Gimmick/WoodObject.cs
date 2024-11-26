using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodObject : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rig2D;

    [SerializeField]
<<<<<<< Updated upstream
    private GameObject wood;
=======
    private GameObject coll;
>>>>>>> Stashed changes

    [SerializeField]
    private GameObject downWood;

    [SerializeField]
    private bool down = false;

<<<<<<< Updated upstream
=======
    [SerializeField]
    private bool change = false;

    [SerializeField]
    private GameObject woodPos;

>>>>>>> Stashed changes
    private void Start()
    {
        rig2D = GetComponent<Rigidbody2D>();

<<<<<<< Updated upstream
        wood = this.gameObject;
=======
        rig2D.bodyType = RigidbodyType2D.Kinematic;
>>>>>>> Stashed changes
    }

    private void Update()
    {
        TEST();
    }

    private void TEST()
    {
        if(down)
        {
<<<<<<< Updated upstream
            return;
=======
            rig2D.bodyType = RigidbodyType2D.Dynamic;
            down = false;
            this.gameObject.transform.position = woodPos.transform.position;
        }

        if (change)
        {
            coll.SetActive(false);

            downWood.SetActive(true);

            this.gameObject.SetActive(false);
>>>>>>> Stashed changes
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("WeaponAttack"))
        {
            down = true;

            rig2D.bodyType = RigidbodyType2D.Dynamic;
        }
    }


}
