using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ������ ����
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

    // ItemEffect List ����
    public List<ItemEffect> efts;

    public bool Use()
    {
        bool isuUsed = false;
        // �ݺ��� ������ efts�� ExecuteRole�� ����
        foreach ( ItemEffect eft in efts)
        {
            isuUsed = eft.ExecuteRole();
        }

        
        // ������ ��� ���� ���� ��ȯ
        return isuUsed;
    }
}

