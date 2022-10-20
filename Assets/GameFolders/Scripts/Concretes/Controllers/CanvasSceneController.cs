using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjectGame3.Enums;
using ProjectGame3.Managers;

namespace ProjectGame3.Controllers
{

    public class CanvasSceneController : MonoBehaviour
    {

        [SerializeField] SceneTypeEnums sceneType;
        [SerializeField] GameObject canvasObject;

        private void Start()
        {

            GameManager.Instance.OnSceneChanged += HandleSceneChanged;

        }

        private void OnDestroy()
        {

            GameManager.Instance.OnSceneChanged -= HandleSceneChanged;

        }

        private void HandleSceneChanged(SceneTypeEnums sceneType)
        {

            if (sceneType == this.sceneType)
            {
                
                canvasObject.SetActive(true);

            }

            else
            {
                
                canvasObject.SetActive(false);

            }

        }

    }


}

