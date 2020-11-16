using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private bool open;
    private AudioSource audioSource;
    private int interpolationFramesCount = 45; // Number of frames to completely interpolate between the 2 positions
    private int elapsedFrames = 0;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Stop();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<PlayerInventory>().Keys[0])
            {
                print("Open");
                open = true;
                audioSource.Play();
            }
        }
    }

    private void Update()
    {
        if(open)
        {
            if (transform.position.z > 49)
            {
                float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

                transform.position = Vector3.Lerp(transform.position,
                    new Vector3(transform.position.x, 0, transform.position.z - 0.25f),
                    interpolationRatio);

                elapsedFrames++;
            }
            else { open = false; audioSource.Stop(); }
        }
    }
}
