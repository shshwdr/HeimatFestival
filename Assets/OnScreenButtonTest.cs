using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class OnScreenButtonTest : MonoBehaviour
{
    public PlayerInput playerInput;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        
        playerInput.actions["A"].started += OnPressA;
    }

    public void OnPressA(InputAction.CallbackContext context)
    {
        text.text = "A";
    }

    // Update is called once per frame
    void Update()
    {

        //var keyboard = Keyboard.current;
        //if (keyboard.aKey.wasPressedThisFrame)
        //{
        //    playerInput.actions["A"].started += OnPressA;
        //}
    }
}
