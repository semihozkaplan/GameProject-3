using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Managers;
using ProjectGame3.Enums;

namespace ProjectGame3.Uis
{

    public class GameOverPanel : MonoBehaviour
    {

        public void YesButton()
        {

            GameManager.Instance.LoadingScreen(SceneTypeEnums.Game);

        }

        public void NoButton()
        {

            GameManager.Instance.LoadingScreen(SceneTypeEnums.Menu);

        }

    }

}

