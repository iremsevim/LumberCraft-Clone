using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildBase : MonoBehaviour
{
    public Image barAmount;
    public float maxTime;
    public float currentTime;


    public virtual void Update()
    {
        
        if(currentTime<=maxTime)
        {
            currentTime += Time.deltaTime;
            SyncTime();

        }
    }
    public float PercenTime
    {
        get
        {
            return currentTime / maxTime;
        }
    }
   

    public virtual void Interact(object o=null)
    {
        
        currentTime = 0;
        SyncTime();
        
    }
    public  void SyncTime()
    {
        if (barAmount == null) return;
        barAmount.fillAmount = PercenTime;
    }
   
    
}
