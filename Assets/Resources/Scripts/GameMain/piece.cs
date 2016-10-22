using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class piece : MonoBehaviour
{
    [SerializeField]
    private CreateBoard board;
    //現在のsell
    public Vector2 sell = Vector2.zero;

    [SerializeField]
    TextAsset CharacterDataCSV;

    private int life;
    private int attack_power;
    private int counter_attack_power;
    private List<areaBase> move_areas = new List<areaBase>();
    private List<areaBase> attack_areas = new List<areaBase>();

    private int team_number;


    public void setSell(Vector2 _sell)
    {
        sell = _sell;
        transform.position = board.getSellPosition(_sell);

        board.setOnpise(_sell, gameObject);
    }


    void Start()
    {
        board = GameObject.Find("Board").GetComponent<CreateBoard>();

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
        Debug.Log(attack_areas.Count);
        foreach (var area in attack_areas)
        {
            area.SetAttackOn(_sell, board);
        }
    }



    private void LoadCharacterDate()
    {
        StringReader reader = new StringReader(CharacterDataCSV.text);

        string[] fields = reader.ReadLine().Split(',');
        life = int.Parse(fields[1]);
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
        while ((text = reader.ReadLine()) != "")
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
            setSell(sell);

        }

    }
}
