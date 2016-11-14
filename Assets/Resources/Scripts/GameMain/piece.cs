using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine.UI;
using System.Text;
using System;
public class piece : MonoBehaviour
{
    public PieceNum piece_num;
    //現在のsell
    public Vector2 sell = Vector2.zero;

    [SerializeField]
    TextAsset CharacterDataCSV = null;
    public string file_name;
    [SerializeField]
    Slider hp_ber = null;

    public int max_hp;
    public int life;
    public int attack_power;
    public int counter_attack_power;
    private List<areaBase> move_areas = new List<areaBase>();
    private List<areaBase> attack_areas = new List<areaBase>();

    public int team_number;
    public bool is_siege = false;

    public void setSell(Vector2 _sell)
    {
        transform.position = GamaManager.Instance.Board.getSellPosition(_sell);
        sell = _sell;
    }


    void Start()
    {
        GamaManager.Instance.Board.setOnpise(sell, this);
        setSell(sell);

        LoadCharacterDate();
    }

    public void OnMoveArea()
    {
        foreach (var area in move_areas)
        {
            area.setMoveOn(this);
        }
    }
    public void OnAttackArea(Vector2 _sell)
    {

        foreach (var area in attack_areas)
        {
            area.SetAttackOn(this, _sell);
        }
    }

    public void damage(int _damage = 0)
    {
        life -= _damage;
        hp_ber.value = (float)life / (float)max_hp;
        if (life <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void LoadCharacterDate()
    {
        //StringReader reader = new StringReader(CharacterDataCSV.text);
        
        var sr = new StreamReader(Application.streamingAssetsPath + "/" + file_name + ".csv");
       

        string[] fields = sr.ReadLine().Split(',');
        max_hp = life = int.Parse(fields[1]);
        fields = sr.ReadLine().Split(',');
        attack_power = int.Parse(fields[1]);
        fields = sr.ReadLine().Split(',');
        counter_attack_power = int.Parse(fields[1]);
        sr.ReadLine();

        string text = "";
        while ((text = sr.ReadLine()) != "�U���͈�")
        {
            AddMoveAreas(text.Split(','));
        }

        while ((text = sr.ReadLine()) != null)
        {
            AddAttackAreas(text.Split(','));
        }
    }


    private void AddAttackAreas(string[] fields)
    {
        if (fields[0] == "point")
        {
            attack_areas.Add(new PointArea(
                new Vector2(int.Parse(fields[1]), int.Parse(fields[2])) * (-team_number * 2 + 1)
                ));
        }
        if (fields[0] == "line")
        {
            attack_areas.Add(new LineArea(
               new Vector2(int.Parse(fields[1]), int.Parse(fields[2])) * (-team_number * 2 + 1),
               int.Parse(fields[3]))
               );
        }
    }

    private void AddMoveAreas(string[] fields)
    {
        if (fields[0] == "point")
        {
            move_areas.Add(new PointArea(
                new Vector2(int.Parse(fields[1]), int.Parse(fields[2])) * (-team_number * 2 + 1)
                ));
        }
        if (fields[0] == "line")
        {
            move_areas.Add(new LineArea(
               new Vector2(int.Parse(fields[1]), int.Parse(fields[2])) * (-team_number * 2 + 1),
               int.Parse(fields[3]))
               );
        }
    }


}
