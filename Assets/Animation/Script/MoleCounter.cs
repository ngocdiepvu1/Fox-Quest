using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoleCounter : MonoBehaviour
{
    public int moleCount = 0;
    Text moleScore;

    private void Start () {
        moleScore = GameObject.Find("MoleScore").GetComponent<Text>();
    }

    private void Update () {
        moleScore.text = "Moles: " + moleCount.ToString();
    }
}
