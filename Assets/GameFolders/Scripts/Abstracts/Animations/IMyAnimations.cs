using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame3.Abstracts.Animations
{

    public interface IMyAnimations
    {
        
        void MoveAnimation(float moveSpeed);
        void JumpAnimation(bool isJump);
        void AttackAnimation();
        void TakeHitAnimation();
        void DeadAnimation();

    }

}


