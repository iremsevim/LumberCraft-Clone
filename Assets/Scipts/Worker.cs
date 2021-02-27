using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class Worker
{


  
}
public static class Utility
{
    public static void AimAngledCircleOverlap(this Transform transform, float radius, LayerMask mask, System.Action<Transform> OnTouched, float anglelimit)
    {
        Collider[] allhitted = Physics.OverlapSphere(transform.position, radius, mask);
        var hittedlist = allhitted.ToList().ConvertAll(x => x.transform);
        hittedlist= hittedlist.FindAll(x => 
        {
            bool result = false;
            Vector3 dir = x.position - transform.position;
            dir.y = transform.forward.y;
            float angle = Vector3.Angle(dir, transform.forward);
            return angle <= anglelimit;
        });
        foreach (var item in hittedlist)
        {
            OnTouched?.Invoke(item);
        }
    }
}

