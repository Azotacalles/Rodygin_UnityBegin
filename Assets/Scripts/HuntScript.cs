using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HuntScript : MonoBehaviour
{
    public string targetTag = "Player";
    public int rays = 4;
    public int distance = 10;
    public float angle = 5;
    public Vector3 offset;
    private Transform target;
    public NavMeshAgent navMeshAgent;
    private bool hunt = false;

    public bool Hunt
    {
        get { return hunt; }
        set { hunt = value; }
    }

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform; 
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) < distance)
        {
            if (RayToScan())
            {
                print("Hunt");
                hunt = true;
                navMeshAgent.SetDestination(target.transform.position);
            }
            else
            {
                print("Find");
            }
        }
    }

    bool GetRaycast(Vector3 dir)
    {
        bool result = false;
        RaycastHit hit = new RaycastHit();
        Vector3 pos = transform.position + offset;
        if (Physics.Raycast(pos, dir, out hit, distance))
        {
            if (hit.transform == target)
            {
                result = true;
                Debug.DrawLine(pos, hit.point, Color.green);
            }
            else
            {
                Debug.DrawLine(pos, hit.point, Color.blue);
            }
        }
        else
        {
            Debug.DrawRay(pos, dir * distance, Color.red);
        }
        return result;
    }

    bool RayToScan()
    {
        bool result = false;
        bool a = false;
        bool b = false;
        float j = 0;
        for (int i = 0; i < rays; i++)
        {
            var sin = Mathf.Sin(j);
            var cos = Mathf.Cos(j);

            j += angle * Mathf.Deg2Rad;
            
            Vector3 dir = transform.TransformDirection(new Vector3(sin, 0, cos));
            if (GetRaycast(dir)) a = true;

            if (sin != 0)
            {
                dir = transform.TransformDirection(new Vector3(-sin, 0, cos));
                if (GetRaycast(dir)) b = true;
            }
        }

        if (a || b) result = true;
        return result;
    }
}
