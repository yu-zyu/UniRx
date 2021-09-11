using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace Samples.Section3.Coroutines
{
    public class YieldInstructionSample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(WaitCoroutine());
        }

        private IEnumerator WaitCoroutine()
        {
            Debug.Log("Coroutine start:" + Time.time);

            //Observable をコルーチンに変換する
            yield return Observable
                .Timer(TimeSpan.FromSeconds(1))
                .ToYieldInstruction();

            Debug.Log("Coroutine end:" + Time.time);
        }
    }
}
