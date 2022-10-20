using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ProjectGame3.Managers;
using ProjectGame3.Combats;
using ProjectGame3.Abstracts.Combats;
using ProjectGame3.Controllers;

namespace ProjectGame3.Uis
{

    public class QuestionPanel : MonoBehaviour
    {

        [SerializeField] ResultPanel _resultPanel;
        TextMeshProUGUI _messageText;
        IHealth _playerHealth;
        
        int _lifeCount;
        
        private void OnEnable()
        {

            // Burada yaptığımız işlem -> Şuanki objenin transformuna yani olduğu yere git
            // Ve onun getchild methodu ile 0.indexine ulaş ve o indeğin içerisindeki TMP companentini al.  
            // GetCompanentInChildren ise ilk bulduğu child elementi döner o yüzden aşağıdaki yazım şekli daha belirgin ve daha güzel.
            _messageText = transform.GetChild(0).GetComponent<TextMeshProUGUI>(); 

        }

        private void OnDisable()
        {

            _lifeCount = 0;
            _playerHealth = null;

        }

        public void SetLifeCountAndHealth(int lifeCount, IHealth playerHealth)     // Buradaki setleme işlemini anlamak için ShopGameObjects scriptine git.
        {

            _lifeCount = lifeCount;
            _messageText.text = $"Do You want to buy {_lifeCount} HP ?";  // Parametrenin aldığı değere göre yazı değişecek.
            _playerHealth = playerHealth;

        }

        public void YesButton()
        {

            _resultPanel.gameObject.SetActive(true);

            if(_lifeCount <= GameManager.Instance.Score)
            {

                _resultPanel.ResultMessageText($"You have earned {_lifeCount} HP ");
                GameManager.Instance.DecreaseScore(_lifeCount);
                _playerHealth.HealByShopKeeper(_lifeCount);
                
            }

            else
            {
                
                _resultPanel.ResultMessageText("You do not have enough diamond !!!");

            }

            this.gameObject.SetActive(false); //Soru panelini kapatması için yaptığımız işlem

        }


    }


}

