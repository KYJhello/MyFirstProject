using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCoroutine : MonoBehaviour
{
    /*
     * �ڷ�ƾ (coroutine) �߿���!!!
     * 
     * �۾��� �ټ��� �����ӿ� �л��� �� �ִ� �񵿱�� �۾�
     * �ݺ������� �۾��� �����Ͽ� �����ϸ�, ������ �Ͻ������ϰ� �ߴ��� �κк��� �ٽý�����
     * ��, �ڷ�ƾ�� �����尡 �ƴϸ� �ڷ�ƾ�� �۾��� ������ ���� �����忡�� ����
     * 
     */

    private void Start()
    {
        StartCoroutine(SubRoutine());
    }

    // ��ȯ���� �ݺ���
    IEnumerator SubRoutine()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log($"{i}�� ����");
            // �� �� ��ٷ���
            yield return new WaitForSeconds(1f);
        }
    }
    private Coroutine routine;
    private void CoroutineStart()
    {
        routine = StartCoroutine(SubRoutine());
    }

    // �ݺ������� �۾��� ��� �Ϸ�Ǿ��� ��� �ڵ� ����
    // �ڷ�ƾ�� �����Ų ��ũ��Ʈ�� ��Ȱ��ȭ�Ȱ��
    private void CoroutineStop()
    {
        StopCoroutine(routine);
        StopAllCoroutines();
    }
    IEnumerator CoRoutineWait()
    {
        yield return new WaitForSeconds(1f);        // n�� �ð�����

        yield return null;                          // �ð����� ����
    }
   
}
