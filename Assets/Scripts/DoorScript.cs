using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] private int numberKey;
    private bool open = false;
    private AudioSource audioSource;
    //private Vector3 beginPosition;
    //private Vector3 currentPosition;
    //private float angle;
    private Animation animationDoor;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        animationDoor = GetComponent<Animation>();
        //beginPosition = transform.position;
        //currentPosition = transform.position;
        //angle = Mathf.Round(transform.rotation.eulerAngles.y);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerInventory>().Keys[numberKey] && !open)
            {
                animationDoor.Play();
                print($"Open {numberKey} Door");
                open = true;
                audioSource.Play();
            }
        }
    }

    //private void Update()
    //{      
    //    //if (open)
    //    //{
    //    //    float dis = Vector3.Distance(beginPosition, currentPosition);
    //    //    if (dis < 2)
    //    //    {
    //    //        if (angle == 90 || angle == 270) transform.position += Vector3.forward * Time.deltaTime;
    //    //        else transform.position += Vector3.right * Time.deltaTime;
    //    //        currentPosition = transform.position;
    //    //    }
    //    //    else enabled = false;
    //    //}
    //}
}
