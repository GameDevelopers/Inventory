using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDataBase : MonoBehaviour
{
    public static ItemDataBase instance;

    private void Awake()
    {
        instance = this;
    }
    public List<Item> itemDB = new List<Item>();

    // ������ ���� ������ ���� ����
    public GameObject fielditemPrefab;
    // �������� ������ ��ġ
    public Vector3[] pos;

    // ������ ���� Ȯ���� ���� ��ŸƮ �޼���
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject go = Instantiate(fielditemPrefab, pos[i], Quaternion.identity);
            go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0, 3)]);
        }    
    }

}
