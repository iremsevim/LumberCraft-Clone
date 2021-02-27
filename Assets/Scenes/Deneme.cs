using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme : MonoBehaviour
{
    public float speed =0;
    public float maxspeed = 250;
    public Transform center;
 
    public float rotspeed = 3;
  
    public void Update()
    {
        Movement();
    }
    public void Movement()
    {
        speed += Time.deltaTime;
        float x = Mathf.Cos(speed);
        float y = Mathf.Sin(speed);
        transform.position = center.position;
        transform.position-= new Vector3(x, y, 0)*rotspeed;
    }

}
