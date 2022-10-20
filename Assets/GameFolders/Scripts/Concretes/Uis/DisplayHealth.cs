using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using ProjectGame3.Abstracts.Combats;
using ProjectGame3.Controllers;
using System;

namespace ProjectGame3.Uis
{

    public class DisplayHealth : MonoBehaviour
    {

        Image _lifeBarImage;
        IHealth _health;


        private void Awake()
        {

            _lifeBarImage = GetComponent<Image>();
            
        }

        private void OnEnable()
        {

            _health = FindObjectOfType<PlayerController>().GetComponent<IHealth>();
            _health.OnHealthChanged += HandleHealthChanged;

        }



        private void OnDisable()
        {

            _health.OnHealthChanged -= HandleHealthChanged;
            _lifeBarImage.fillAmount = 1f;

        }



        private void HandleHealthChanged(int currentHealth, int maxHealth)
        {

            float result = Convert.ToSingle(currentHealth) / Convert.ToSingle(maxHealth);  // Single keywordunu float değişkenler için kullanırız.
            _lifeBarImage.fillAmount = result;

        }


    }


}

