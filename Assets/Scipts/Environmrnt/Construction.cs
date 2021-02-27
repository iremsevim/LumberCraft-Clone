using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Construction : MonoBehaviour
{
    public int requirementWood;
    public string buildID;
    public Image fillımage;
    public int maxRequirementWood;

    public Transform builpoint;
    public Text buildwoodtxt;





    public void Start()
    {
        fillımage.fillAmount = PercentWood;
        buildwoodtxt.text = requirementWood.ToString();
    }
    public float PercentWood
    {
        get
        {
            return (float)requirementWood / (float)maxRequirementWood;
        }
    }
    public void BuildConstruction()
    {
        
        requirementWood--;
        buildwoodtxt.text = requirementWood.ToString();

        fillımage.fillAmount = PercentWood;
        if (requirementWood <= 0)
        {
            GameData.General.BuildData findedbuild = GameData.instance.general.buildDatas.Find(x => x.ID == buildID);
            GameObject create = Instantiate(findedbuild.buildprefab, builpoint.position, Quaternion.identity);
            GameData.instance.StartCoroutine(ShowBuilParticle(builpoint.position));
            Destroy(gameObject);
        }
    }
    public IEnumerator ShowBuilParticle(Vector3 pos)
    {
        yield return new WaitForSeconds(1f);
        GameObject crated = Instantiate(GameData.instance.general.buildparticle,pos, Quaternion.identity);
        Destroy(crated.gameObject, 2f);

    }
  
}
