using UnityEngine;
using System.Collections;

public class PieceTutorialWindow : MonoBehaviour {

    Select select;

    [SerializeField]
    GameObject[] pieceInfoImage_One;
    [SerializeField]
    GameObject[] pieceInfoImage_Two;
    [SerializeField]
    GameObject[] pieceInfoImage_Three;

    int imageNum;

    // Use this for initialization
    void Start () {

        foreach (var i in pieceInfoImage_One)
        {
            i.SetActive(false);
        }
        foreach (var i in pieceInfoImage_Two)
        {
            i.SetActive(false);
        }
        foreach (var i in pieceInfoImage_Three)
        {
            i.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update () {

        SetTutorialImage(select.catchPiese);
        if(select.catchPiese == PieceNum.NON)
        {
            pieceInfoImage_One[8].SetActive(true);
            pieceInfoImage_Two[8].SetActive(true);
            pieceInfoImage_Three[8].SetActive(true);
        }

        if (select.catchPiese != PieceNum.NON)
        {
            pieceInfoImage_One[8].SetActive(false);
            pieceInfoImage_Two[8].SetActive(false);
            pieceInfoImage_Three[8].SetActive(false);
        }

    }

    void SetTutorialImage(PieceNum _imageNum)
    {

        pieceInfoImage_One[imageNum].SetActive(false);
        pieceInfoImage_Two[imageNum].SetActive(false);
        pieceInfoImage_Three[imageNum].SetActive(false);

        imageNum = (int)_imageNum;
        //imageNum = Mathf.Max(imageNum, 0);

        pieceInfoImage_One[imageNum].SetActive(true);
        pieceInfoImage_Two[imageNum].SetActive(true);
        pieceInfoImage_Three[imageNum].SetActive(true);



    }
}
