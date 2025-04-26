using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class TriggerKeyP : MonoBehaviour
{
    void Start()
    {
    }

    void Update()
    {
        Animator anim = GetComponent<Animator>();
        if (((KeyControl)Keyboard.current["p"]).wasPressedThisFrame)
        {
            anim.SetTrigger("keyP");
        }
    }
}