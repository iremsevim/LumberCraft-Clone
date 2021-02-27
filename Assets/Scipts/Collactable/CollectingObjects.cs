using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CollectingObjects : MonoBehaviour
{
    public bool IsActive=true;
    public Collider col;

    public void MagnetToPoint(System.Action onFinishedMagnetic,Vector3 magnetpoint)
    {
        if (!IsActive) return;
        IsActive = false;
        col.enabled = false;
        transform.DOMove(magnetpoint, 0.5f).OnComplete(() =>
        { onFinishedMagnetic?.Invoke(); });

    }
}
