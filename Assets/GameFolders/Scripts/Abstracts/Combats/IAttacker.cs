using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame3.Abstracts.Combats
{

    public interface IAttacker
    {

        void Attack(ITakeHit takeHit);
        public int Damage { get; }


    }


}

