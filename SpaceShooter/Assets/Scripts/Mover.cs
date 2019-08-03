using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{
     public static float speed = -5;
     public bool firstTime = true;

     private Rigidbody rb;

     void Start()
     {
 
          rb = GetComponent<Rigidbody>();
          rb.velocity = transform.forward * speed;
     }   
     void Update()
     {
         if (Input.GetKey (KeyCode.H) && firstTime)
           {
               firstTime = false;
           }
           if (firstTime == false)
           {
                speed = -10;
           }
     }

}