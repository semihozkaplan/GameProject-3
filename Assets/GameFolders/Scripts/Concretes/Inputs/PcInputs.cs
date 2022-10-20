using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.Inputs;

namespace ProjectGame3.Inputs
{

    public class PcInputs : IPlayerInput
    {
        public float Horizontal => Input.GetAxis("Horizontal");

        public float Vertical => Input.GetAxis("Vertical");

        public bool JumpButton => Input.GetButtonDown("Jump");
        
        public bool AttackButton => Input.GetButtonDown("Fire1");
    }

}


