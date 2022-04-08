using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ShopData : MonoBehaviour
{
    // ������ ���۵Ǹ� ����Ʈ�� �������� �߰���
    public List<Item> stocks = new List<Item>();
    // �������� �ȸ��� ����Ʈ�� ���� ��ġ�� ������ �����
    public bool[] soldOuts;

    void Start()
    {
        // �׽�Ʈ�� ���� ������ �߰�
        stocks.Add(ItemDataBase.instance.itemDB[0]);
        stocks.Add(ItemDataBase.instance.itemDB[1]);
        stocks.Add(ItemDataBase.instance.itemDB[2]);
        stocks.Add(ItemDataBase.instance.itemDB[3]);
        stocks.Add(ItemDataBase.instance.itemDB[4]);
        // �ش�������� �ȸ� ������ ������ ���� ��
        soldOuts = new bool[stocks.Count];
        // �迭�� ����Ʈ�� ũ�⸸ŭ �ʱ�ȭ�ϰ� �ݺ����� ���� �迭�� ���� �������� �ʱ�ȭ
        for (int i = 0; i < soldOuts.Length; i++)
        {
            soldOuts[i] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}