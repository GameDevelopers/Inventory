using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 아이템 생성
public enum ItemType
{
    Equipment,
    Consumables,
    Etc
}

[System.Serializable]
public class Item 
{
    public ItemType itemType;
    public string itemName;
    public Sprite itemImage;

    public bool Use()
    {
        // 아이템 사용 성공 여부 반환
        return false;
    }
}

