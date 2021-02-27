using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CharackterShoulderInventory : MonoBehaviour
{
    public List<GameObject> AllShoulderObjects;
    public GameObject woodPrefab;

    private void Start()
    {
        AllShoulderObjects.ForEach(x => x.SetActive(false));
    }

    public void SyncItem(int woodcount)
    {
        if (woodcount == 0)
        {
            AllShoulderObjects.ForEach(x => x.SetActive(false));
            return;
        }

        AllShoulderObjects.ForEach(x => x.SetActive(false));
        for (int i = 0; i < AllShoulderObjects.Count; i++)
        {
            AllShoulderObjects[i].SetActive(true);
            if (i == woodcount) break;
        }
    }
    public void ThrowWood(Vector3 targetpos)
    {
        GameObject created = Instantiate(woodPrefab,transform.position, Quaternion.identity);
        created.transform.DOMove(targetpos, 0.33f).OnComplete(()=>Destroy(created.gameObject));
        
    }
}
