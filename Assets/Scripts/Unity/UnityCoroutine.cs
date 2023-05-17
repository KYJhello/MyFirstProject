using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityCoroutine : MonoBehaviour
{
    /*
     * 코루틴 (coroutine) 중요함!!!
     * 
     * 작업을 다수의 프레임에 분산할 수 있는 비동기식 작업
     * 반복가능한 작업을 분한하여 진행하며, 실행을 일시정지하고 중단한 부분부터 다시시작할
     * 단, 코루틴은 스레드가 아니며 코루틴의 작업은 여전히 메인 스레드에서 실행
     * 
     */

    private void Start()
    {
        StartCoroutine(SubRoutine());
    }

    // 반환형이 반복자
    IEnumerator SubRoutine()
    {
        for (int i = 0; i < 10; i++)
        {
            Debug.Log($"{i}초 지남");
            // 몇 초 기다려라
            yield return new WaitForSeconds(1f);
        }
    }
    private Coroutine routine;
    private void CoroutineStart()
    {
        routine = StartCoroutine(SubRoutine());
    }

    // 반복가능한 작업이 모두 완료되었을 경우 자동 종료
    // 코루틴을 진행시킨 스크립트가 비활성화된경우
    private void CoroutineStop()
    {
        StopCoroutine(routine);
        StopAllCoroutines();
    }
    IEnumerator CoRoutineWait()
    {
        yield return new WaitForSeconds(1f);        // n초 시간지연

        yield return null;                          // 시간지연 없음
    }
   
}
