using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.StateMachines;
using ProjectGame3.Abstracts.Movements;
using ProjectGame3.Abstracts.Animations;
using ProjectGame3.Abstracts.Controller;

namespace ProjectGame3.StateMachines.EnemyState
{

    public class Idle : IState
    {

        IMover _mover;
        IMyAnimations _animation;
        

        float _maxWaitTime;
        float _currentWaitTime = 0f;

        public bool IsIdle { get; private set; }

        public Idle(IMover mover, IMyAnimations animation)
        {

            _mover = mover;
            _animation = animation;

        }

        public void OnEnter()
        {

            IsIdle = true;
            _animation.MoveAnimation(0f);

            _maxWaitTime = Random.Range(4f, 10f);


        }

        public void Tick()
        {

            _mover.Tick(0f); 

            _currentWaitTime += Time.deltaTime;

            if (_currentWaitTime > _maxWaitTime) //Idle durumundayken random olarak belirtilen süre aralığında bir süre beklesin sonra diğer duruma geçsin.
            {

                IsIdle = false;

            }

            Debug.Log("Idle Tick");

        }

        public void OnExit()
        {

            _currentWaitTime = 0f;
             
        }

    }

}


