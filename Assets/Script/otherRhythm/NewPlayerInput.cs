using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace RhythmHeavenMania
{

    public class NewPlayerInput:MonoBehaviour {

        UnityEngine.InputSystem.PlayerInput playerInput;
        void Start()
        {
            playerInput = GameObject.FindObjectOfType<UnityEngine.InputSystem.PlayerInput>();
            playerInput.actions["A"].started += OnStartPressA;
            //playerInput.actions["A"].
            playerInput.actions["A"].canceled += OnFinishPressA;

            playerInput.actions["B"].started += OnStartPressB;
            playerInput.actions["B"].canceled += OnFinishPressB;
        }
        bool isPressingA;
        bool isPressingB;
        private void OnFinishPressB(InputAction.CallbackContext obj)
        {
            isPressingB = false;
        }

        private void OnStartPressB(InputAction.CallbackContext obj)
        {
            isPressingB = true;
        }

        private void OnFinishPressA(InputAction.CallbackContext obj)
        {
            isPressingA = false;
        }

        private void OnStartPressA(InputAction.CallbackContext obj)
        {
            isPressingA = true;
        }
        public bool Pressed()
        {
            return playerInput.actions["A"].WasPressedThisFrame() && !GameManager.instance.autoplay && Conductor.instance.isPlaying;
        }
        public bool AltPressed()
        {
            return playerInput.actions["B"].WasPressedThisFrame() && !GameManager.instance.autoplay && Conductor.instance.isPlaying;
        }
    }

   
}