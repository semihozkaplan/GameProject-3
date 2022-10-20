using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.StateMachines;
using ProjectGame3.Abstracts.Movements;
using ProjectGame3.Abstracts.Animations;
using ProjectGame3.Abstracts.Controller;
using ProjectGame3.Abstracts.Combats;

namespace ProjectGame3.StateMachines.EnemyState
{

    public class Attack : IState
    {

        IMyAnimations _animations;
        IAttacker _attacker;
        IHealth _playerHealth;
        IFlip _flip;
        System.Func<bool> _isRightSide;

        float _currentAttackTime;
        float _maxAttackTime;

        public Attack(IHealth playerHealth, IFlip flip, IMyAnimations animations, IAttacker attacker, float maxAttackTime, System.Func<bool> isRightSide)
        {

            _animations = animations;
            _attacker = attacker;
            _playerHealth = playerHealth;
            _maxAttackTime = maxAttackTime;
            _flip = flip;
            _isRightSide = isRightSide;

        }

        public void OnEnter()
        {

            _currentAttackTime = 0f;

        }

        public void Tick()
        {

            _currentAttackTime += Time.deltaTime;

            if (_currentAttackTime > _maxAttackTime)
            {

                if (_isRightSide.Invoke())
                {

                    _flip.FlipAction(1f);

                }

                else
                {

                    _flip.FlipAction(-1f);

                }

                _animations.AttackAnimation();
                _attacker.Attack(_playerHealth);
                _currentAttackTime = 0f;

            }

            Debug.Log("Attack Tick");
        }

        public void OnExit()
        {


        }


    }

}


