using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class HospitalBuild : BuildBase
{

    public int health;
    public override void Interact(object o)
    {
        base.Interact(o);
        (o as System.Action<int>)?.Invoke(health);
      

         

    }
}
