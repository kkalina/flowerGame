﻿using UnityEngine;
using System.Collections;

public class bulletShoot : MonoBehaviour
{

    public GameObject bullet;

    public float frequency = 1f;
    private float lastOccruance = 0f;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time > lastOccruance + frequency)
            {
                GameObject bulletInstance = Instantiate(bullet);
                bulletInstance.transform.position = this.transform.position;
                bulletInstance.transform.rotation = this.transform.rotation;
                //bulletInstance.GetComponent<Rigidbody>().velocity = this.transform.
                //muzzleLight.GetComponent<Light>().enabled = true;
                lastOccruance = Time.time;
            }
        }
    }
}