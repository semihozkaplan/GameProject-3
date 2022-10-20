using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame3.Abstracts.StateMachines
{

    public interface IState
    {
        void OnEnter();
        void Tick();
        void OnExit();
    }


}

