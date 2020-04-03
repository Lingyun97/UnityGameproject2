using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{

    public Text myscore;
    public int melon = 0;

    void Awake()
    {
        myscore = GameObject.Find("Score").GetComponent<Text>();
    }

    public void SetScore()
    {
        this.melon++;
        myscore.text = "Score " + melon;

    }
    public void win()
    {
        myscore.text = "Unbelievable,You win. And You gain " + melon + " in final level";
    }

}
