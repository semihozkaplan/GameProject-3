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

    public class Dead : IState
    {   

        IMyAnimations _animation;
        IEntityController _entityController;
        System.Action _deadCallBack;

        float _currentTime = 0f;
        float _maxDestroyTime = 5f;

        public Dead(IEntityController entityController,IMyAnimations animation, System.Action deadCallBack)
        {
            
            _entityController = entityController;
            _animation = animation;
            _deadCallBack = deadCallBack;

        }

        public void OnEnter()
        {

           _animation.DeadAnimation();
           _deadCallBack?.Invoke();

        }


        public void Tick()
        {

            _currentTime += Time.deltaTime;

            if (_currentTime > _maxDestroyTime)
            {
                Object.Destroy(_entityController.transform.gameObject); // entityController transformundaki objeyi bul ve yok et.
            }

            Debug.Log("Dead Tick");
            
        }


        public void OnExit()
        {

            _currentTime = 0f;

        }


    }


}


