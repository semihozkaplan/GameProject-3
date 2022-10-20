using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.Combats;
using ProjectGame3.Combats;

namespace ProjectGame3.Controllers
{

    public class DeadZoneController : MonoBehaviour
    {

        IAttacker _attacker;

        private void Awake()
        {

            _attacker = GetComponent<EnemyAttacker>();

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

            IHealth health = collision.GetComponent<IHealth>();

            if (health != null)
            {

                health.TakeHit(_attacker);

            }

        }

    }


}

