using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;

public class piece : MonoBehaviour
{
    [SerializeField]
    private CreateBoard board;
    //現在のsell
    public Vector2 sell = Vector2.zero;

    [SerializeField]
    TextAsset CharacterDataCSV;
    [SerializeField]
    Slider hp_ber;

    public int max_hp;
    public int life;
    public int attack_power;
    public int counter_attack_power;
    private List<areaBase> move_areas = new List<areaBase>();
    private List<areaBase> attack_areas = new List<areaBase>();

    public int team_number;


    public void setSell(Vector2 _sell)
    {
        transform.position = board.getSellPosition(_sell);
        sell = _sell;
    }

    void Awake()
    {
        board = GameObject.Find("Board").GetComponent<CreateBoard>();

    }

    void Start()
    {
        board.setOnpise(sell, gameObject);
        setSell(sell);

        LoadCharacterDate();
    }

    public void OnMoveArea()
    {
        foreach(var area in move_areas)
        {
            area.setMoveOn(this, board);
        }
    }
    public void OnAttackArea( Vector2 _sell)
    {
       
        foreach (var area in attack_areas)
        {
            area.SetAttackOn(_sell, board);
        }
    }

    public void damage(int _damage = 0)
    {
        life -= _damage;
        hp_ber.value = (float)life / (float)max_hp; 
    }

    private void LoadCharacterDate()
    {
        StringReader reader = new StringReader(CharacterDataCSV.text);

        string[] fields = reader.ReadLine().Split(',');
        max_hp = life = int.Parse(fields[1]);
        fields = reader.ReadLine().Split(',');
        attack_power = int.Parse(fields[1]);
        fields = reader.ReadLine().Split(',');
        counter_attack_power = int.Parse(fields[1]);
        reader.ReadLine();

        string text = "";
        while ((text = reader.ReadLine()) != "U")
        {
            
           AddMoveAreas(text.Split(','));
        }
        while ((text = reader.ReadLine()) != null)
        {
            AddAttackAreas(text.Split(','));
        }
    }

    private void AddAttackAreas(string[] fields)
    {
        if (fields[0] == "point")
        {
            attack_areas.Add(new PointArea(
                new Vector2(int.Parse(fields[1]), int.Parse(fields[2])))
                );
        }
        if (fields[0] == "line")
        {

            attack_areas.Add(new LineArea(
               new Vector2(int.Parse(fields[1]), int.Parse(fields[2])),
               int.Parse(fields[3]))
               );
        }
    }

    private void AddMoveAreas(string[] fields)
    {
        if (fields[0] == "point")
        {
            move_areas.Add(new PointArea(
                new Vector2(int.Parse(fields[1]), int.Parse(fields[2])))
                );
        }
        if (fields[0] == "line")
        {
            move_areas.Add(new LineArea(
               new Vector2(int.Parse(fields[1]), int.Parse(fields[2])),
               int.Parse(fields[3]))
               );
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            
        }

    }
}
