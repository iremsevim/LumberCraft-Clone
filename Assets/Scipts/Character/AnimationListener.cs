using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationListener : MonoBehaviour
{

    public List<Animationprofil> allAnims;

    public void PlayAnim(AnimType animType)
    {
      Animationprofil findedanim=allAnims.Find(x => x.animType == animType);
        findedanim?.action?.Invoke();
    }

    [System.Serializable]
    public class Animationprofil
    {
        public AnimType animType;
        public System.Action action;
        
        public Animationprofil(AnimType _type,System.Action _action)
        {
            animType = _type;
            action = _action;
        }
    }
    public enum AnimType
    {
        attacking=0,attackend=1,walkingstart=2,walkingend=3
    }
}
