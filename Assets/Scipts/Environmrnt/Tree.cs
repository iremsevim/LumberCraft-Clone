using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public static List<Tree> alltrees = new List<Tree>();
    public int woodcuttingcount = 4;
    public Transform treebody;
    public Transform leave;
    private float cuttinglong;
    public int cutcount;
    public Transform woodcarrier;

    public void Awake()
    {
        alltrees.Add(this);
        cuttinglong = treebody.localScale.y / woodcuttingcount;
    }
   
    public void OnDestroy()
    {
        alltrees.Remove(this);
    }
    public void Cutting()
    {
        Vector3 scale = treebody.localScale;
        scale.y -= cuttinglong;
        treebody.localScale = scale;
        transform.position -= new Vector3(0, cuttinglong / 2, 0);
        leave.transform.position -= new Vector3(0, cuttinglong / 2, 0);
        GameObject createdwood = Instantiate(GameData.instance.general.woodpaartprefab,woodcarrier.position, Quaternion.identity);
        createdwood.GetComponent<Rigidbody>().AddForce((((Random.Range(0,10)>5?1:-1) *Vector3.right)+Vector3.up)*50);

        cutcount++;
        if (cutcount == woodcuttingcount)
        {
            Destroy(gameObject);
           
        }


    }

}
