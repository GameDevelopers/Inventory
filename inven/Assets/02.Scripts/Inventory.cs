using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    // �̱��� ���� ���
    public static Inventory instance;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance);
            return;
        }
        instance = this;
    }
    #endregion

    // SlotCnt ���� ����Ǹ� �˷��ֱ� ���� Delegate(�븮��)��� 
    public delegate void OnSlotCountChange(int val); // �븮�� ����
    public OnSlotCountChange onSlotCountChange; // �븮�� �ν��Ͻ�ȭ

    // �������� �߰��Ǹ� ����UI���� �߰��ǰ� �����
    public delegate void OnChangeItem();
    public OnChangeItem onChangeItem;

    // ���� ����
    private int slotCnt;
    public int SlotCnt
    {
        get => slotCnt;
        set
        {
            slotCnt = value;
            // �븮�� ȣ��
            onSlotCountChange.Invoke(slotCnt);
        }
    }

    private void Start()
    {
        SlotCnt = 4;
    }

    // �÷��̾� ������ ���� �� �κ��丮�� �̵�
    // ȹ���� �������� ���� ����Ʈ ����
    List<Item> items = new List<Item>();

    // �������� ����Ʈ�� �߰��ϴ� �޼���
    // items�� ������ ���� Ȱ��ȭ�� ���� ������ �������� ������ �߰�
    public bool AddItem(Item _item)
    {
        if(items.Count < SlotCnt)
        {
            items.Add(_item);
            if(onChangeItem != null)
            // ������ �߰��� �����ϸ� onChangeItem�� ȣ��
            onChangeItem.Invoke();
            return true;
        }
        // ������ �߰��� �����ϸ� true �ƴϸ� false ��ȯ
        return false;
    }

    // �÷��̾�� �ʵ�������� �浹�ϸ� AddItem ȣ��
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FieldItem"))
        {
            FieldItems fieldItems = collision.GetComponent<FieldItems>();
            // AddItem�� �������� �߰��Ǹ� true ��ȯ
            // ������ �߰��� �����ϸ� �ʵ�������� �ı�

        }
    }
}