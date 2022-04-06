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

    // ItemEffect List 생성
    public List<ItemEffect> efts;

    public bool Use()
    {
        bool isuUsed = false;
        // 반복문 돌려서 efts의 ExecuteRole을 실행
        foreach ( ItemEffect eft in efts)
        {
            isuUsed = eft.ExecuteRole();
        }

        
        // 아이템 사용 성공 여부 반환
        return isuUsed;
    }
}

