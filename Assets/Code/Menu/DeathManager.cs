﻿using System;
using JUTPS;
using UnityEngine;

namespace Code.Menu
{
    public class DeathManager : MonoBehaviour
    {
        // Outlets
        public GameObject deathScreen;
        private JUCharacterController _characterController;
        
        private void Awake()
        {
            _characterController = FindObjectOfType<JUCharacterController>();
        }

        private void Update()
        {
            if (_characterController.IsDead)
            {
                deathScreen.SetActive(true);
            }
        }
    }
}