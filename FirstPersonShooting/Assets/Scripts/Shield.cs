using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private CharacterInput controls;
    [HideInInspector] public bool blocking;

    void Awake()
    {
        controls = new CharacterInput();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Block()
    {
        blocking = true;
        Invoke("BlockEnd", 1);
    }

    void Update()
    {
        if(controls.Player.Shield.triggered && blocking)
        {
            Block();
        }
    }
}
