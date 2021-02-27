using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    public static GameData instance;
    public General general;

    public void Awake()
    {
        instance = this;

    }
    [System.Serializable]
    public class General
    {
        public GameObject woodpaartprefab;
        public List<BuildData> buildDatas;
        public GameObject buildparticle;
        public List<TeleportProfil> allteleports;
        public GameObject charackter;
       
      
        [System.Serializable]
        public class BuildData
        {
            public string ID;
            public GameObject buildprefab;
            
          
        }
        [System.Serializable]
        public class TeleportProfil
        {
            public string ID;
            public GameObject teleportenter;
            public GameObject teleportexit;
            
        }
    }
}
