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

    public void UppdateSlotUI()
    {
        // itemIcon sprite�� ������ �̹����� �ʱ�ȭ�ϰ� Ȱ��ȭ �����ش�.
        itemIcon.sprite = item.itemImage;
        //itemIcon.gameObject.SetActive(true);

    }

    // item�� null�� SetActive�� false�� �����ش�
    public void RemoveSlot()
    {
        item = null;
        //itemIcon.gameObject.SetActive(false);
    }

    public void OnPointerUp(PointerEventData eventData)
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
}
