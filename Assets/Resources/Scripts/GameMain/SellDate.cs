using UnityEngine;
using System.Collections;

public class SellDate : MonoBehaviour
{

    enum Status
    {
        NON,
        NORMAL,
    }

    public bool is_movable = false;
    public bool is_attack = false;

    public Vector2 sell;
    private Status status;
    public GameObject on_pise;

    
    public GameObject move_quad;
    public GameObject attack_quad;

    public void SetStatus(int type)
    {
        status = (Status)type;
    }

    

    void Start()
    {
        move_quad = gameObject.transform.FindChild("move_quad").gameObject;
        attack_quad = gameObject.transform.FindChild("attack_quad").gameObject;
    }

    void Update()
    {
        
    }
    public void setMovable(bool _movable)
    {
        is_movable = _movable;
        move_quad.SetActive(_movable);
    }

    public void SetAttack(bool _attack)
    {
        is_attack = _attack;
        attack_quad.SetActive(_attack);
    }

}
