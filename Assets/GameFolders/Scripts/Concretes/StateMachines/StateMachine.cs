using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.StateMachines;
using System;

namespace ProjectGame3.StateMachines
{

    public class StateMachine
    {

        List<StateTransition> _stateTransitions = new List<StateTransition>();
        List<StateTransition> _anyStateTransition = new List<StateTransition>(); // Bir durumdan herhangi bir duruma geçebilsin diye oluşturduğumuz List.

        IState _currentState; //Diyelim ki burası Idle state durumunda olsun

        public void SetState(IState state) //Burasıda Walk state olsun
        {

            if (state == _currentState) return; //Eğer currentState ile parametre olan state eşit değilse currentState durumundan çıksın yani OnExit methodu çalışsın.

            _currentState?.OnExit();

            _currentState = state;  //OnExit methodu ile currentSatate yeni State e atansın yani yeni durumu olsun.

            _currentState.OnEnter(); //Sonra o yeni durum OnEnter methodu ile giriş yapsın.

        }

        public void Tick() //Her bir framede çalışacak method.
        {

            StateTransition stateTransition = CheckForTransition();

            if (stateTransition != null)
            {

                SetState(stateTransition.To);

            }

            _currentState.Tick(); //IState interfacesinin içerisindeki Tick çalışacak.

        }

        private StateTransition CheckForTransition()
        {

            foreach (StateTransition anyStateTransition in _anyStateTransition)
            {

                if (anyStateTransition.Condition.Invoke()) // Aşağıdaki Condition propunun farklı yazımı.
                {

                    return anyStateTransition;

                }

            }

            foreach (StateTransition stateTransitions in _stateTransitions)
            {

                if (stateTransitions.Condition() && stateTransitions.From == _currentState)
                {

                    return stateTransitions;

                }

            }

            return null;

        }

        public void AddTransition(IState from, IState to, Func<bool> condition)
        {

            StateTransition stateTransition = new StateTransition(from, to, condition); //StateTransitionda açtığımız constructor newlediğimiz için burada bir kere çalışır.
            _stateTransitions.Add(stateTransition);                                     //Eğer StateTransition classının içinde ctor açmasaydık propları kullanamzdık.(From, To, Condition)

        }

        public void AddAnyState(IState to, Func<bool> condition) //Bir durumdan herhangi bir duruma gidebilsin.
        {

            StateTransition anyStateTransition = new StateTransition(null, to, condition);
            _anyStateTransition.Add(anyStateTransition);

        }

    }

}


