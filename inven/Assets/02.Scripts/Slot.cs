using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour, IPointerUpHandler
{
    // ������ ���� ����
    public int slotnum;

    // ������ , �̹��� ���� ����
    public Item item;
    public Image itemIcon;

    // 
    public bool isShopMode;
    // 
    public bool isSell = false;
    //
    public GameObject chkSell;

    public void UppdateSlotUI()
    {
        // itemIcon sprite�� ������ �̹����� �ʱ�ȭ�ϰ� Ȱ��ȭ �����ش�.
        itemIcon.sprite = item.itemImage;
        itemIcon.gameObject.SetActive(true);

    }

    // item�� null�� SetActive�� false�� �����ش�
    public void RemoveSlot()
    {
        item = null;
        itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if(item != null)
        {
            if (!isShopMode)
            {
                // Slot�� �ִ� item.Use�޼��带 ȣ���մϴ�.
                bool isUse = item.Use();
                // ������ ��뿡 �����ϸ� RemoveItem�� ȣ��
                if (isUse)
                {
                    // Inventory�� items���� �˸��� �Ӽ��� ����
                    Inventory.instance.RemoveItem(slotnum);
                }
            }
            else
            {
                // ����
                isSell = true;
                chkSell.SetActive(isSell);
            }
        }
    }

    // 
    public void SellItem()
    {   // 
        if (isSell)
        {
            // 
            ItemDataBase.instance.money += item.itemCost;
            Inventory.instance.RemoveItem(slotnum);
            // 
            isSell = false;
            chkSell.SetActive(isSell);
        }
    }

    // 
    private void OnDisable()
    {
        isSell = false;
        chkSell.SetActive(isSell);
    }
}
