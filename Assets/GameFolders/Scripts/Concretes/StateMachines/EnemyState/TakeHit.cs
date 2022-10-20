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

    public class TakeHit : IState
    {

        IMyAnimations _animation;
        IHealth _health;

        float _maxDelayTime = 0.2f;
        float _currentDelayTime = 0f;

        public bool IsTakeHit { get; private set; }

        public TakeHit(IHealth health, IMyAnimations animation)
        {
            health.OnHealthChanged += (currentHealth, maxHealth) => OnEnter(); // Burayı anonim method yapmamaızın sebebi event içerisinde bulunan parametreler burada hata fırlatmasın diyedir.
            _animation = animation;                                            // Yani aslında yukardaki işlem bir ananonim methodun içerisinde bir method çalışması mantığıdır.
        }

        public void OnEnter()  //Buradaki parametrelerin hiçbir vasfı yoktur sadece event hata vermesin diye yazmak zorunda kaldık.
        {

            IsTakeHit = true;

        }


        public void Tick()
        {

             _currentDelayTime += Time.deltaTime;

            if (_currentDelayTime > _maxDelayTime && IsTakeHit)
            {
                
                _animation.TakeHitAnimation();
                IsTakeHit = false;

            }


            Debug.Log("TakeHit Tick");

        }


        public void OnExit()
        {

           _currentDelayTime = 0f;

        }


    }


}
