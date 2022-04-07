using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//
//  Slot.cs���� UppdateSlotUI,RemoveSlot,OnPointerUp �޼��� 3�� ���簡������
public class ShopSlot : MonoBehaviour, IPointerUpHandler
{
    public int slotnum;
    public Item item;
    public Image itemIcon;
    //
    public bool soldOut = false;
    //
    InventoryUI inventoryUI;

    //
    public void Init(InventoryUI Iui)
    {
        inventoryUI = Iui;
    }


    public void UppdateSlotUI()
    {
        // itemIcon sprite�� ������ �̹����� �ʱ�ȭ�ϰ� Ȱ��ȭ �����ش�.
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
        // 
        if (soldOut)
        {
            itemIcon.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }

    // item�� null�� SetActive�� false�� �����ش�
    public void RemoveSlot()
    {
        item = null;
        //
        soldOut = false;
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (item != null)
        {
            if(ItemDataBase.instance.money >= item.itemCost && !soldOut 
                && Inventory.instance.items.Count < Inventory.instance.SlotCnt)
            {
                ItemDataBase.instance.money -= item.itemCost;
                Inventory.instance.AddItem(item);
                //
                soldOut = true;
                inventoryUI.Buy(slotnum);
                UppdateSlotUI();
            }
        }
    }

}
