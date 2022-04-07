using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ShopData : MonoBehaviour
{
    //
    public List<Item> stocks = new List<Item>();
    //
    public bool[] soldOuts;

    void Start()
    {
        //
        stocks.Add(ItemDataBase.instance.itemDB[0]);
        stocks.Add(ItemDataBase.instance.itemDB[1]);
        stocks.Add(ItemDataBase.instance.itemDB[2]);
        stocks.Add(ItemDataBase.instance.itemDB[3]);
        stocks.Add(ItemDataBase.instance.itemDB[4]);
        //
        soldOuts = new bool[stocks.Count];
        //
        for (int i = 0; i < soldOuts.Length; i++)
        {
            soldOuts[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
