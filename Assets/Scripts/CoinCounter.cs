using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCounter : MonoBehaviour
{
    TextMesh TM;
    private int counter;

    void Start()
    {
        TM = GetComponent<TextMesh>();
        TM.text = "0";
    }


    public void CoinPickUp()
    {
        TM = GetComponent<TextMesh>();
        counter++;
        TM.text = counter.ToString();
    }
}
