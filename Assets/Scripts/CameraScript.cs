using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform hero;
    [SerializeField] private float turnSpeed;
    private Vector3 rotate;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = hero.position;
        rotate.y = Input.GetAxis("Horizontal");
        transform.Rotate(rotate * turnSpeed * Time.deltaTime);
    }
}
