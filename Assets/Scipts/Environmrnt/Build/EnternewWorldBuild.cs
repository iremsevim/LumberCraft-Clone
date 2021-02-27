using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnternewWorldBuild : BuildBase
{
    public override void Interact(object o = null)
    {
        base.Interact(o);
        Debug.Log("New Dünya");
    }
}
