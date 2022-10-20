using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.Inputs;
using UnityStandardAssets.CrossPlatformInput;

namespace ProjectGame3.Inputs
{
    public class MobileInputs : IPlayerInput
    {
        
        float IPlayerInput.Horizontal => CrossPlatformInputManager.GetAxis("Horizontal");

        float IPlayerInput.Vertical => CrossPlatformInputManager.GetAxis("Vertical");

        bool IPlayerInput.JumpButton => CrossPlatformInputManager.GetButtonDown("Jump");

        bool IPlayerInput.AttackButton => CrossPlatformInputManager.GetButtonDown("Fire1");
    }

}


