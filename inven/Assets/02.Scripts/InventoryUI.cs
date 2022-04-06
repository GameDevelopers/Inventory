using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    // �κ��丮 ���� ����
    Inventory inven;

    // �κ��丮 �гο� Inventory UI Panel ������Ʈ�� ����ش�.
    public GameObject inventoryPanel;

    // Ȱ��ȭ ���� �Ǵ�
    bool activeInventory = false;

    public Slot[] slots;
    public Transform slotHolder;

    private void Start()
    {
        // �κ��丮 ���� �ʱ�ȭ
        inven = Inventory.instance;

        // GetComponentsInChildren�̿��ؼ� content���� Slot �����Ǵ°� ���� ����
        slots = slotHolder.GetComponentsInChildren<Slot>();

        // onSlotCountChange�� ������ �޼��� ����
        inven.onSlotCountChange += SlotChange;
        // �븮�� ȣ�⺸�� �޼��尡 ���� ����Ǵ� ���� �߻� �� 
        // Edit - project Settings - Script Execution Order - InventoryUI , Inventory ������ 
        // ��ũ��Ʈ ���� �����ؼ� �ذ�


        //onChangeItem�� ������ �޼��� ����
        inven.onChangeItem += RedrawSlotUI;

        // �ʱ⿡ �κ��丮 ������ ���·� ����
        inventoryPanel.SetActive(activeInventory);
    }


    private void SlotChange(int val)
    {
        // slots�� ������ŭ�� Ȱ��ȭ �ϰ� �������� ��Ȱ��ȭ
        for (int i = 0; i < slots.Length; i++)
        {
            // Slot�� slotnum�� ���ʷ� ��ȣ�� �ο� 
            slots[i].slotnum = i;

            // SlotCnt ��ŭ�� interactable �� true �༭ Ȱ��ȭ
            // Button �� interactable�� false�� ��Ȱ��ȭ�ȴ�.
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
    // ���԰��� ����
    public void AddSlot()
    {
        inven.SlotCnt++;
    }

    private void Update()
    {
        // I Ű�� �κ��丮 â Ȱ��ȭ
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
    }

    //
    private void RedrawSlotUI()
    {
        // �ݺ����� ���� ���Ե��� �ʱ�ȭ
        // items�� ������ŭ slot�� ä���ֽ��ϴ�.
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
