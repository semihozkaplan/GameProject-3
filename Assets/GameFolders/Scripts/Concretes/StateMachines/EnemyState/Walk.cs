using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.StateMachines;
using ProjectGame3.Abstracts.Movements;
using ProjectGame3.Abstracts.Animations;
using ProjectGame3.Abstracts.Controller;

namespace ProjectGame3.StateMachines.EnemyState
{
 
    public class Walk : IState
    {

        IMover _mover;
        IMyAnimations _animations;
        IEntityController _entityController;
        IFlip _flip;

        float _direction;

        int _patrolIndex = 0;
        Transform[] _patrols;
        Transform _currentPatrol;

        public bool IsWalking { get; private set; }

        public Walk(IEntityController entityController, IMover mover, IMyAnimations animation, IFlip flip, params Transform[] patrols) //params keywordu bir veya birden fazla obje alabilir demektir. Yani saysını bilmiyorsak bu keywordu kullanabiliriz.
        {

            _mover = mover;
            _animations = animation;
            _patrols = patrols;
            _entityController = entityController;
            _flip = flip;

        }

        public void OnEnter()
        {

            if(_patrols.Length < 1) return;

                _currentPatrol = _patrols[_patrolIndex];

                Vector3 leftOrRight = _currentPatrol.transform.position - _entityController.transform.position;

                if (leftOrRight.x > 0f)
                {

                    _flip.FlipAction(1f);

                }

                else
                {

                    _flip.FlipAction(-1f);

                }

            _direction = _entityController.transform.localScale.x;

            _animations.MoveAnimation(1f);
            IsWalking = true;

        }

        public void Tick()
        {

            if (_currentPatrol == null) return;

            if (Vector2.Distance(_entityController.transform.position, _currentPatrol.transform.position) <= 0.2f)
            {

                IsWalking = false;
                return;

            }


            _mover.Tick(_direction);

            Debug.Log("Walk Tick");

        }

        public void OnExit()
        {

            _animations.MoveAnimation(0f);

            _patrolIndex++;

            if (_patrolIndex >= _patrols.Length)
            {

                _patrolIndex = 0;

            }


        }


    }

}

