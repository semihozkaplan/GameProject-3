using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Managers;
using ProjectGame3.Enums;

namespace ProjectGame3.Uis
{

    public class MenuButtonObject : MonoBehaviour
    {

        public void StartButton()
        {

            GameManager.Instance.LoadingScreen(SceneTypeEnums.Game);

        }

        public void Quit(){

            GameManager.Instance.QuitGame();

        }

    }


}

