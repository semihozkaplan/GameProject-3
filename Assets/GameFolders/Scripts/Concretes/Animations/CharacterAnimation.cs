using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Controllers;
using ProjectGame3.Abstracts.Animations;

namespace ProjectGame3.Animations
{
    public class CharacterAnimation : IMyAnimations
    {

        Animator _animator;

        public CharacterAnimation(Animator animator)
        {

            _animator = animator;

        }

        public void MoveAnimation(float moveSpeed)
        {

            float mathValue = Mathf.Abs(moveSpeed);

            if (_animator.GetFloat("moveSpeed") == mathValue) return;

            _animator.SetFloat("moveSpeed", mathValue);

        }

        public void JumpAnimation(bool isJump)
        {

            if (_animator.GetBool("isJump") == isJump) return;

            _animator.SetBool("isJump", isJump);

        }

        public void AttackAnimation()
        {

            _animator.SetTrigger("attack");

        }

        public void TakeHitAnimation()
        {

            _animator.SetTrigger("takeHit");

        }

        public void DeadAnimation()
        {

            _animator.SetTrigger("dead");

        }

    }

}


