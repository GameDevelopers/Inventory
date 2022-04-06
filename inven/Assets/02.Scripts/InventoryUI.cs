using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // 인벤토리 변수 선언
    Inventory inven;

    // 인벤토리 패널에 Inventory UI Panel 오브젝트를 담아준다.
    public GameObject inventoryPanel;

    // 활성화 여부 판단
    bool activeInventory = false;

    public Slot[] slots;
    public Transform slotHolder;

    private void Start()
    {
        // 인벤토리 변수 초기화
        inven = Inventory.instance;

        // GetComponentsInChildren이용해서 content안의 Slot 생성되는거 전부 선택
        slots = slotHolder.GetComponentsInChildren<Slot>();

        // onSlotCountChange가 참조할 메서드 정의
        inven.onSlotCountChange += SlotChange;
        // 대리자 호출보다 메서드가 먼저 실행되는 에러 발생 시 
        // Edit - project Settings - Script Execution Order - InventoryUI , Inventory 순으로 
        // 스크립트 순서 지정해서 해결


        //onChangeItem이 참조할 메서드 정의
        inven.onChangeItem += RedrawSlotUI;

        // 초기에 인벤토리 안켜진 상태로 시작
        inventoryPanel.SetActive(activeInventory);
    }


    private void SlotChange(int val)
    {
        // slots의 갯수만큼만 활성화 하고 나머지는 비활성화
        for (int i = 0; i < slots.Length; i++)
        {
            // Slot의 slotnum을 차례로 번호를 부여 
            slots[i].slotnum = i;

            // SlotCnt 만큼만 interactable 를 true 줘서 활성화
            // Button 의 interactable이 false면 비활성화된다.
            if (i < inven.SlotCnt)
            {
                slots[i].GetComponent<Button>().interactable = true;
            }
            else
            {
                slots[i].GetComponent<Button>().interactable = false;
            }
        }
    }
    // 슬롯개수 증가
    public void AddSlot()
    {
        inven.SlotCnt++;
    }

    private void Update()
    {
        // I 키로 인벤토리 창 활성화
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }

    //
    private void RedrawSlotUI()
    {
        // 반복문을 통해 슬롯들을 초기화
        // items의 갯수만큼 slot을 채워넣습니다.
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i].RemoveSlot();
        }

        for (int i = 0; i < inven.items.Count; i++)
        {
            slots[i].item = inven.items[i];
            slots[i].UppdateSlotUI();
        }
    }
}
