using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Managers;
using ProjectGame3.Combats;
using ProjectGame3.Abstracts.Combats;
using ProjectGame3.Controllers;
using System;

namespace ProjectGame3.Uis
{

    public class ShopGameObject : MonoBehaviour
    {

        [SerializeField] QuestionPanel questionPanel;
        [SerializeField] GameObject shop;

        IHealth _playerHealth;

        private void OnEnable()
        {

            _playerHealth = FindObjectOfType<PlayerController>().GetComponent<IHealth>();

        }

        private void OnDisable()  // Shop kapandığında player sağlığıtyla ilgili bir işlem yapma null dönsün.
        {

            _playerHealth = null;

        }

        public void BuyLifeClicked(int lifeCount)  //Satın alma tuşuna basılınca eminmisiniz soru ekranını ekrana getirmesi için yaptığımız işlem
                                                   //Her bir buton için unityde parametre girişlerini yaptık. (10-20-30) 
        {

            questionPanel.gameObject.SetActive(true);
            questionPanel.SetLifeCountAndHealth(lifeCount, _playerHealth);

        }

        public void IsActiveShop(bool isActive)
        {

            shop.SetActive(isActive);

        }

    }

}


