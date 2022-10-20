using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjectGame3.Abstracts.Combats
{

    public interface IHealth : ITakeHit //Bu interfaceyi hem ITakeHit hemde IHealthdaki özellikleri bir class alabilsin diye yazdık(Health classı)
    {

        bool IsDead { get; }
        void HealByShopKeeper(int lifeCount);
        event System.Action<int, int> OnHealthChanged;
        event System.Action OnDead;
        


    }



}

