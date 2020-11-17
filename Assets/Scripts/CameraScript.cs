using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform Hero = null;
    private Vector3 startPosition = Vector3.zero;

    void Start()
    {
        startPosition = transform.position - Hero.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Hero.position + startPosition;
    }
}
