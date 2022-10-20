using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Abstracts.Combats;

namespace ProjectGame3.Uis
{

    public class GameOverObject : MonoBehaviour
    {

        [SerializeField] GameObject gameOverPanel;
        IHealth _playerHealth;


        private void OnEnable()  // Her ihtimale karşı ilk başta gameoverpanel i false olarak ayarladık.
        {

            gameOverPanel.SetActive(false);

        }

        public void SetPlayerHealth(IHealth health) // Setleme işlemini playercontroller içerisinde yaptım dönüp bakabilirsin :)
        {

            _playerHealth = health;
            _playerHealth.OnDead += HandleDead;
        }

        private void HandleDead()
        {

            gameOverPanel.SetActive(true);
            _playerHealth.OnDead -= HandleDead;
            _playerHealth = null; // Öldüğü için artık herhangi bir sağlığa sahip olmasın demiş olduk.

        }

    }

}

