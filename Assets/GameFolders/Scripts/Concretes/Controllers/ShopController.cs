using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Uis;

namespace ProjectGame3.Controllers
{

    public class ShopController : MonoBehaviour
    {

        ShopGameObject _shopObject;

        private void Start()
        {

            _shopObject = FindObjectOfType<ShopGameObject>();

        }

        private void OnTriggerEnter2D(Collider2D collision)
        {

          PlayerTrigger(collision, true);

        }

        private void OnTriggerExit2D(Collider2D collision)
        {

            PlayerTrigger(collision, false);

        }

        private void PlayerTrigger(Collider2D collider, bool isActive)
        {

            PlayerController player = collider.GetComponent<PlayerController>();

            if (player != null)
            {

                _shopObject.IsActiveShop(isActive);

            }

        }

    }

}


