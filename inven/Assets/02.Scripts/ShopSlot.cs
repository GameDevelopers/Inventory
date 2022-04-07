using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//
//  Slot.cs에서 UppdateSlotUI,RemoveSlot,OnPointerUp 메서드 3개 복사가져오기
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
        // itemIcon sprite를 아이템 이미지로 초기화하고 활성화 시켜준다.
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);
        // 
        if (soldOut)
        {
            itemIcon.color = new Color(0.5f, 0.5f, 0.5f);
        }
    }

    // item은 null로 SetActive는 false를 시켜준다
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
