using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldItems : MonoBehaviour
{
    // 어떤 아이템인지 명시
    public Item item;
    // 아이템별 이미지 변환
    public SpriteRenderer image;

    // 필드에 아이템을 생성할 때 SetItem 통해 전달받은 item으로 현재 클래스의 item을 초기화
    public void SetItem(Item _item)
    {
        item.itemName = _item.itemName;
        item.itemImage = _item.itemImage;
        item.itemType = _item.itemType;

        // 아이템에 맞게 이미지 변화
        image.sprite = item.itemImage;
    }

    public Item GetItem()
    {
        return item;
    }
    // 아이템 획득 시 필드의 아이템은 파괴
    public void DestroyItem()
    {
        Destroy(gameObject);
    }
}
