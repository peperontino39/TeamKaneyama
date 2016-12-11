using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public enum Command
{
    ATTACK,
    END,
    SIEGE,
    CANCEL,
    INCASTLE,
    EXITCASTLE
}
public class CommandList : MonoBehaviour
{

    [SerializeField]
    public Button[] command_list;


  
    void Start()
    {
        ALLSetInteractable(false);
    }

    public void ALLSetInteractable(bool _is)
    {
        foreach (var command in command_list)
        {
            command.interactable = _is;
        }
    }

    public void SetInteractable(Command com, bool _is)
    {
        command_list[(int)com].interactable = _is;
    }

    public void setOnClick(Command com, UnityAction call)
    {
        command_list[(int)com].onClick.AddListener(call);
    }

}
