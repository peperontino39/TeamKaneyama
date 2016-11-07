using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public class CommandList : MonoBehaviour
{

    [SerializeField]
    GameObject[] command_list;


    public enum Command
    {
        ATTACK,
        END,
        SIEGE,
        CANCEL
    }
    void Start()
    {
        ALLSetInteractable(false);
    }

    public void ALLSetInteractable(bool _is)
    {
        foreach (var command in command_list)
        {
            command.GetComponent<Button>().interactable = _is;
        }
    }

    public void SetInteractable(Command com,bool _is)
    {
        command_list[(int)com].GetComponent<Button>().interactable = _is;
    }

    public void setOnClick(Command com, UnityAction call)
    {
        command_list[(int)com].GetComponent<Button>().onClick.AddListener(call);
    }

}
