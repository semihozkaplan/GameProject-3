using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.Combats;

namespace ProjectGame3.Combats
{

    public class Health : MonoBehaviour, IHealth
    {

        [SerializeField] int _maxHealth = 3;
        int _currentHealth;

        public bool IsDead => _currentHealth < 1;

        public event System.Action<int, int> OnHealthChanged;
        public event System.Action OnDead;

        private void Awake()
        {

            _currentHealth = _maxHealth;

        }

        public void TakeHit(IAttacker attacker)
        {

            if (IsDead) return;

            _currentHealth = Mathf.Max(_currentHealth -= attacker.Damage, 0); // Aşağıdaki mantığın aynısını yapmaktadır.
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);              // Eğer 0 can kaldıysa eksilere düşme, en büyük aralığı yani 0 değerini dön.  

            if (IsDead)
            {

                OnDead?.Invoke();

            }

        }

        public void HealByShopKeeper(int lifeCount)
        {

            // İki aralıktan en küçük sayıyı döneceği için en fazla maxHealth dönebilir.
            // Satın alınan can maxHealth miktarını aşmasın diye böyle bir işlem yapmış olduk.
            _currentHealth = Mathf.Min(_currentHealth += lifeCount, _maxHealth); 
            OnHealthChanged?.Invoke(_currentHealth, _maxHealth);

        }


    }


}

