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

    //
    public Slot[] slots;
    public Transform slotHolder;

    //
    public ShopSlot[] shopSlots;
    public Transform shopHolder;

    private void Start()
    {
        // �κ��丮 ���� �ʱ�ȭ
        inven = Inventory.instance;

        // GetComponentsInChildren�̿��ؼ� content���� Slot �����Ǵ°� ���� ����
        slots = slotHolder.GetComponentsInChildren<Slot>();
        // 
        shopSlots = slotHolder.GetComponentsInChildren<ShopSlot>();

        //
        for (int i = 0; i < shopSlots.Length; i++)
        {
            shopSlots[i].Init(this);
            shopSlots[i].slotnum = i;
        }

        // onSlotCountChange�� ������ �޼��� ����
        inven.onSlotCountChange += SlotChange;
        // �븮�� ȣ�⺸�� �޼��尡 ���� ����Ǵ� ���� �߻� �� 
        // Edit - project Settings - Script Execution Order - InventoryUI , Inventory ������ 
        // ��ũ��Ʈ ���� �����ؼ� �ذ�


        //onChangeItem�� ������ �޼��� ����
        inven.onChangeItem += RedrawSlotUI;

        // �ѹ� ȣ���ؼ� ��� ������ �ʱ�ȭ
        RedrawSlotUI();

        // �ʱ⿡ �κ��丮 ������ ���·� ����
        inventoryPanel.SetActive(activeInventory);

        // ���� ��Ȱ��ȭ
        closeShop.onClick.AddListener(DeActiveShop);
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
        // I Ű�� �κ��丮 â Ȱ��ȭ + ������ �������� �ʴٸ�
        if (Input.GetKeyDown(KeyCode.I) && !isStoreActive)
        {
            activeInventory = !activeInventory;
            inventoryPanel.SetActive(activeInventory);
        }
        // ���콺 ��ư�� Ŭ�� �Ǹ� rayshop���� �޼ҵ� ȣ��
        if (Input.GetMouseButtonUp(0))
        {
            RayShop();
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



    // ���� Ŭ�� �� �ŷ�â Ȱ��ȭ �ǰ��ϴ� �ڵ� �ۼ�
    public GameObject shop;
    // ������ ��Ȱ��ȭ ��Ű�� �ڵ� �ۼ��� ���� ��ư����
    public Button closeShop;
    // �� ������ ���̸� iŰ�� ������ �κ��� ��Ȱ��ȭ ���� �ʰ� �����ش�.
    public bool isStoreActive;
    //
    public ShopData shopData;

    //  Ŭ���� ��ġ�� ���̸� �� ���� ��ġ�� üũ
    public void RayShop()
    {
        // ���콺�� ��ġ�� �����ͼ� ȭ�� ��ǥ�� ������ǥ�� ��ȯ �޾� ���
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = -10;
        // Ȯ�� DrawRay �� â�� ���̸� �׷���
        // Debug.DrawRay(mousePos, transform.forward, Color.red, 0.5f);

        //
        // ������� -1 ��� 0
        if (!UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject(-1))
        {
            // ����ĳ��Ʈ�� �̿��ؼ� ��Ʈ���� �����´�.
            RaycastHit2D hit2D = Physics2D.Raycast(mousePos, transform.forward, 30);
            if (hit2D.collider != null)
            { // hit���� ������� �ʰ�
                // �浹ü�� �±װ� �������
                if (hit2D.collider.tag == "Store")
                {
                    if (!isStoreActive)
                    {
                        ActiveShop(true);
                        //
                        shopData = hit2D.collider.GetComponent<ShopData>();
                        //
                        for (int i = 0; i < shopData.stocks.Count; i++)
                        {
                            // ������ ������ �����͸� �޾Ƽ� ���� ���Կ� ä���ش�.
                            shopSlots[i].item = shopData.stocks[i];
                            shopSlots[i].UppdateSlotUI();
                        }
                    }
                }
            }
        }
    }

    //
    public void Buy(int num)
    {
        shopData.soldOuts[num] = true;
    }

    // ��/Ȱ��ȭ �ڵ�� ���� �ۼ�
    public void ActiveShop(bool isOpen)
    {
        if (activeInventory)
        {
            // �κ��丮 Ȱ������ : ������ ������ iŰ�� ������ �κ��丮 â�� ��������ʰ�,
            // �κ��丮 â�� ������ ������ �������� ����
            isStoreActive = isOpen;
            shop.SetActive(isOpen);
            inventoryPanel.SetActive(isOpen);
            // ��� ������ ����带 �Ű��������ٰ� �ʱ�ȭ�ǰ� ������ش�
            for (int i = 0; i < slots.Length; i++)
            {   // �������ڸ� ������ �����ϰ� �Ǹ� ��� ���Կ� ����尡 ���̵ȴ�
                // �ݴ�� close ��ư�� ������ ����尡 ������ �ȴ�.
                slots[i].isShopMode = isOpen;
            }
        }
        
    }
    //
    public void DeActiveShop()
    {
        ActiveShop(false);
        // 
        shopData = null;
        for (int i = 0; i < shopSlots.Length; i++)
        {
            shopSlots[i].RemoveSlot();
        }
    }

    //
    public void SellBtn()
    {
        // ������ ũ�⿡�� �ϳ��� ���鼭 ����
        // 0���� �����ϸ� �޺κ��� ������ ������ �з����鼭 �����Ͱ� ���̱� �����̴�
        for (int i = slots.Length; i > 0; i--)
        {
            slots[i - 1].SellItem();
        }
    }
}
