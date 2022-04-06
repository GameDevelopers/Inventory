using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    // � ���������� ���
    public Item item;
    // �����ۺ� �̹��� ��ȯ
    public SpriteRenderer image;

    // �ʵ忡 �������� ������ �� SetItem ���� ���޹��� item���� ���� Ŭ������ item�� �ʱ�ȭ
    public void SetItem(Item _item)
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;

        // �����ۿ� �°� �̹��� ��ȭ
        image.sprite = item.itemImage;
    }

    public Item GetItem()
    {
        return item;
    }
    // ������ ȹ�� �� �ʵ��� �������� �ı�
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
