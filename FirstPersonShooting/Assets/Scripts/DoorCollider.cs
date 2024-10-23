using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DoorCollider : MonoBehaviour
{
    //for door script
    [HideInInspector] public bool isUp = true;
    public float speed = 7;

    bool unlock = false;
    public TextMeshProUGUI text;
    public bool isLocked = false;
    private CharacterInput controls;

    private void Awake()
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

    void Update() 
    {
        if(controls.Player.Interact.triggered && unlock == true && GameManager.instance.keys > 0)
        {
            GameManager.instance.ChangeKeys(-1);
            isLocked = false;
            text.text = ("");
            isUp = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player") && isLocked == true)
        {
            text.text = ("Open Door?\n(1 Key)");
            unlock = true;
        }
        if (other.gameObject.tag == ("Player") && isLocked == false)
        {
            isUp = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            text.text = ("");
            unlock = false;
            isUp = true;
        }
    }
}
