using Microsoft.Win32.SafeHandles;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int foodGiven;
    private Rigidbody rb;
    public bool foodtaken;
    [SerializeField] string food;
    void Start()
    {
        foodGiven = 5;
        rb = GetComponent<Rigidbody>();
        //rb.freezeRotation = true;
    }

    void OnTriggerEnter(Collider collision)          
    {

        if (collision.gameObject.tag == "chicken")
        {
            food = "chicken";
            foodGiven = 0;
        }

        if (collision.gameObject.tag == "beer")
        {
            food = "beer";
            foodGiven = 1;
        }

        if (collision.gameObject.tag == "drumstick")
        {                                                          //fýrýnlara girince yemeði seçiyor
            food = "drumstick";
            foodGiven = 2;
        }

        if (collision.gameObject.tag == "wine")
        {
            food = "wine";
            foodGiven = 3;
        }

        if (collision.gameObject.tag == "beer")
        {
            food = "beef";
            foodGiven = 4;
        }
    }
}




   
    


