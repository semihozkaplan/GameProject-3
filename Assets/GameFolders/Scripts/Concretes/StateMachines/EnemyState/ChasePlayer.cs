using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.StateMachines;
using ProjectGame3.Abstracts.Movements;
using ProjectGame3.Abstracts.Animations;
using ProjectGame3.Abstracts.Controller;

namespace ProjectGame3.StateMachines.EnemyState
{

    public class ChasePlayer : IState
    {


        IMover _mover;
        IFlip _flip;
        IMyAnimations _animation;
        System.Func<bool> _isRightSide;
        IStopEdge _stopEdge;


        public ChasePlayer(IMover mover, IFlip flip, IMyAnimations animation, IStopEdge stopEdge ,System.Func<bool> isRightSide)
        {


            _mover = mover;
            _flip = flip;
            _animation = animation;
            _isRightSide = isRightSide;
            _stopEdge = stopEdge;

        }


        public void OnEnter()
        {

            _animation.MoveAnimation(1f);

        }


        public void Tick()
        {

            if (_stopEdge.ReachedEdge())
            {
                
                _animation.MoveAnimation(0f);
                return;

            }

            if (_isRightSide.Invoke())
            {

                _mover.Tick(1.5f);
                _flip.FlipAction(1f);

            }

            else 
            {

                _mover.Tick(-1.5f);
                _flip.FlipAction(-1f);

            }

            Debug.Log("Chase Tick");

        }


        public void OnExit()
        {

            _animation.MoveAnimation(0f);

        }


    }


}

