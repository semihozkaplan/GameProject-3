using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace ProjectGame3.Animations
{

    public class AnimationImpactWatcher : MonoBehaviour
    {

        public event Action OnImpact;

        public void Impact(){

            OnImpact?.Invoke();

        }
    }


}

