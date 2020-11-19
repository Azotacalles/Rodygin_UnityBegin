using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private int amountKey;
    private bool[] keys;

    public bool[] Keys
    {
        get { return keys; }
        set { keys = value; }
    }

    void Start()
    {
        keys = new bool[amountKey];
    }
}
