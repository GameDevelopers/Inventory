using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

//
//  Slot.cs에서 UppdateSlotUI,RemoveSlot,OnPointerUp(얘만 내용삭제) 메서드 3개 복사가져오기
public class ShopSlot : MonoBehaviour, IPointerUpHandler
{
    public int slotnum;
    public Item item;
    public Image itemIcon;
    // 아이템이 팔렸음을 표시
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

    // 상점 슬롯이 눌리면 소지한 돈과 아이템의 가격을 비교해서 돈이 부족하지 않다면
    // 아이템을 구매시 가격만큼 돈에서 차감하고 해당아이템을 인벤토리에 표시
    public void OnPointerUp(PointerEventData eventData)
    {
        if (item != null)
        {
            if(ItemDataBase.instance.money >= item.itemCost && !soldOut 
                && Inventory.instance.items.Count < Inventory.instance.SlotCnt)
            {
                ItemDataBase.instance.money -= item.itemCost;
                Inventory.instance.AddItem(item);
                // 팔린 아이템을 
                soldOut = true;
                inventoryUI.Buy(slotnum);
                UppdateSlotUI();
            }
        }
    }

}
