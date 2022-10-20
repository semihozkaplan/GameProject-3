using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame3.Abstracts.Inputs
{

    public interface IPlayerInput
    {

      float Horizontal { get; }
      float Vertical { get; }
      bool JumpButton{ get; }
      bool AttackButton { get; }


    }


}






