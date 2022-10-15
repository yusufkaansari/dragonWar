using System.Collections;
using System.Collections.Generic;
using UdemyProject1.Combats;
using UnityEngine;

namespace UdemyProject1.UIs
{
    public class GameCanvas : MonoBehaviour
    {
        [SerializeField] GameObject gameOverPanel;
        private void Awake()
        {
            gameOverPanel = transform.Find("GameOverPanel").gameObject;            
        }
        private void Start()
        {
            Dead dead = FindObjectOfType<Dead>();
            dead.OnDead += HandleOnDead;
        }

        private void HandleOnDead()
        {
            gameOverPanel.SetActive(true);
        }
    }
}

