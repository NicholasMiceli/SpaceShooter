using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltMover : MonoBehaviour
{
    public float speed;


     private Rigidbody rb;

     void Start()
     {
          speed = 20;
          rb = GetComponent<Rigidbody>();
          rb.velocity = transform.forward * speed;
     }   
}
