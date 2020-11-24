using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] waypoints;
    private int m_CurrentWaypointIndex;
    public HuntScript huntScript;

    Quaternion start;
    Quaternion end;
    bool init = false;

    void Start ()
    {
        navMeshAgent.SetDestination (waypoints[0].position);
    }

    void Update ()
    {
        if(navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance)
        {
            if (!huntScript.Hunt)
            {
                m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                navMeshAgent.SetDestination(waypoints[m_CurrentWaypointIndex].position);
            }
            else
            {
                if (!init)
                {
                    start = transform.rotation;
                    end = Quaternion.Euler(0, 90, 0);
                    init = true;
                }
                transform.rotation = Quaternion.Lerp(start, end, Mathf.PingPong(Time.time * 0.5f, 1f));
                if(transform.rotation.y >= end.y - 0.1)
                {
                    start = Quaternion.Euler(0, -90, 0);
                }
                StartCoroutine(BackOnTrack());
            }
        }   
    }

    IEnumerator BackOnTrack()
    {
        yield return new WaitForSeconds(5f);
        huntScript.Hunt = false;
        init = false;
    }
}
