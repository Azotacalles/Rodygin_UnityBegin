using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform hero;
    [SerializeField] private float turnSpeed;
    private Vector3 rotate;
   

    void Update()
    {
        transform.position = new Vector3(hero.position.x, 0f, hero.transform.position.z);
        rotate.y = Input.GetAxis("Horizontal");
        transform.Rotate(rotate * turnSpeed * Time.deltaTime);
    }
}
