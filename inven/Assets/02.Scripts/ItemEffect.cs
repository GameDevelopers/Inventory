using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// �����ۺ��� ȿ���� �ٸ��� ���ֱ� ���� item��ũ��Ʈ�� ������ �ۼ�
//ItemEffect�� �߻� Ŭ����, ScriptableObjectt��ӹ޾� ���
public abstract class ItemEffect : ScriptableObject
{
    // �߻�޼���
    public abstract bool ExecuteRole();
 
}
