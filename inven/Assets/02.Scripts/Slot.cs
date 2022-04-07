using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerUpHandler
{
    // 정수형 변수 생성
    public int slotnum;

    // 아이템 , 이미지 변수 생성
    public Item item;
    public Image itemIcon;

    public void UppdateSlotUI()
    {
        // itemIcon sprite를 아이템 이미지로 초기화하고 활성화 시켜준다.
        itemIcon.sprite = item.itemImage;
        //itemIcon.gameObject.SetActive(true);

    }

    // item은 null로 SetActive는 false를 시켜준다
    public void RemoveSlot()
    {
        item = null;
        //itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Slot에 있는 item.Use메서드를 호출합니다.
        bool isUse = item.Use();
        // 아이템 사용에 성공하면 RemoveItem을 호출
        if (isUse)
        {
            // Inventory의 items에서 알맞은 속성을 제거
            Inventory.instance.RemoveItem(slotnum);
        }
    }
}
