using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    public int coinCount = 0;
    Text coinScore;

    private void Start () {

        coinScore = GameObject.Find("CoinScore").GetComponent<Text>();
        
    }

    private void Update () {
        coinScore.text = "Coins: " + coinCount.ToString();
    }
}
