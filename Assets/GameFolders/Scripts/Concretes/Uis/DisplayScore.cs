using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ProjectGame3.Managers;

namespace ProjectGame3.Uis
{

    public class DisplayScore : MonoBehaviour
    {

        TextMeshProUGUI _scoreText;

        private void Awake()
        {

            _scoreText = GetComponent<TextMeshProUGUI>();

        }

        private void Start()
        {

            HandleScoreChanged(GameManager.Instance.Score);

        }

        private void OnEnable()
        {

            GameManager.Instance.OnScoreChanged += HandleScoreChanged;

        }

        private void OnDisable()
        {

            GameManager.Instance.OnScoreChanged -= HandleScoreChanged;

        }

        private void HandleScoreChanged(int score)
        {

            _scoreText.text = score.ToString();

        }



    }


}

