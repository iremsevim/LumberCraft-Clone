using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deneme_2 : MonoBehaviour
{
    private Vector3 target;
    [Range(1,180)]
    public float speed;
    public float maxspeed = 180;
   [Range(0,Mathf.PI*2)]
    public float angle;
    public void Update()
    {
        //Rot();
        Rot2();
    }
    public void Rot()
    {

        angle = (speed / maxspeed) * Mathf.PI;
      float x= Mathf.Cos(angle);
       float y = Mathf.Sin(angle);
       target =transform.position+ new Vector3(x, y, 0);

        Vector3 pos = target- transform.position;
       float posz = Mathf.Atan2(pos.x, pos.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, posz), 0.05f);
    }
  

    public void Rot2()
    {
        

        angle = (speed / maxspeed) * Mathf.PI*2;
        float x = Mathf.Cos(angle);
        float y = Mathf.Sin(angle);
       
        
        float posz = Mathf.Atan2(x,y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, 0, posz), 0.05f);



    }
}
