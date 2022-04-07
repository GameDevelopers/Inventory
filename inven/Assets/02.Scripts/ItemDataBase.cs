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

    // 프리팹 복제 생성을 위한 변수
    public GameObject fielditemPrefab;
    // 아이템을 생성할 위치
    public Vector3[] pos;

    // 아이템 습득 확인을 위한 스타트 메서드
    private void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject go = Instantiate(fielditemPrefab, pos[i], Quaternion.identity);
            go.GetComponent<FieldItems>().SetItem(itemDB[Random.Range(0, 3)]);
        }    
    }

}
