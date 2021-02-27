using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBuild : BuildBase
{
    public int wood;
    public override void Interact(object o = null)
    {
        base.Interact(o);
        (o as System.Action<int>)?.Invoke(wood);
    }
}
