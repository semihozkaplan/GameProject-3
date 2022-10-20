using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.Combats;
using ProjectGame3.Animations;
using System;

namespace ProjectGame3.Combats
{

    public class PlayerAttacker : Attacker
    {

        [SerializeField] Transform attackDirection;
        [SerializeField] float attackRadius = 1f;

        Collider2D[] _attackResults;

        private void Awake()
        {

            _attackResults = new Collider2D[10];

        }


        private void OnEnable()
        {
            GetComponent<AnimationImpactWatcher>().OnImpact += HandleImpact;
        }


        private void OnDisable()
        {
            GetComponent<AnimationImpactWatcher>().OnImpact -= HandleImpact;
        }


        private void HandleImpact()
        {
            //Bu methoddaki fizik işlemleri kalıcıdır bir kere olup bitmez yani Local değil global gibi davranır.
            //Bu method bize belirlediğimiz noktada ne kadar collider var ise onun sayısını döner yani int değer döner.
            int hitCount = Physics2D.OverlapCircleNonAlloc(attackDirection.position + attackDirection.forward, attackRadius, _attackResults);

            for (int i = 0; i < hitCount; i++)
            {
                IHealth health = _attackResults[i].GetComponent<IHealth>();

                if (health != null)
                {

                    health.TakeHit(this);

                }
            }
        }


        private void OnDrawGizmos()
        {

            OnDrawGizmosSelected();

        }

        private void OnDrawGizmosSelected()
        {

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackDirection.position + attackDirection.forward, attackRadius);

        }

    }


}

