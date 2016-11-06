using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public class CommandList : MonoBehaviour {

    [SerializeField]
    GameObject[] command_list;


    enum Command{
        ATTACK,
        END,
        SIEGE
    }
    void Start()
    {

        ALLSetInteractable(false);
    }
    void ALLSetInteractable(bool _is)
    {
        foreach(var command in command_list)
        {
            command.GetComponent<Button>().interactable = _is;
        }
    }
    void setOnClick(Command com, UnityAction call)
    {
        command_list[(int)com].GetComponent<Button>().onClick.AddListener(call);
    }

}
