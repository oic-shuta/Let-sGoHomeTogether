using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoint;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;


    // Update is called once per frame
    void Update()
    {
        //ìÆÇ©Ç∑
        transform.position = Vector2.MoveTowards(transform.position, waypoint[currentWaypointIndex].transform.position, Time.deltaTime * speed);

        //âùïúÇ≥ÇπÇÈ
        if (Vector2.Distance(waypoint[currentWaypointIndex].transform.position,
            transform.position) < .1f)
        {
            currentWaypointIndex = (currentWaypointIndex == 1) ? 0 : 1;
        }
    }
}
