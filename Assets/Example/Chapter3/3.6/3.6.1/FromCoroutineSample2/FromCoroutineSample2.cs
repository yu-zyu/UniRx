using System;
using System.Collections;
using System.Threading;
using UniRx;
using UnityEngine;

namespace Samples.Section3.Coroutines
{
    public class FromCoroutineSample2 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //CancellationToken を利用する場合
            Observable
                .FromCoroutine(token => WaitingCoroutine(token))
                .Subscribe(
                _ => Debug.Log("OnNext"),
                () => Debug.Log("OnCompleted"))
                .AddTo(this);
        }

        //CancellationTokenを受け取る
        private IEnumerator WaitingCoroutine(CancellationToken token)
        {
            Debug.Log("Coroutine start.");

            //Observableをコルーチンとして待ち受ける場合,
            //このコルーチンが停止したタイミングで
            //yield return で待ち受けているObservableも止まってほしい
            //そのためにCancellationTokenを用いる
            yield return Observable
                .Timer(TimeSpan.FromSeconds(3))
                .ToYieldInstruction(token);

            Debug.Log("Coroutine finish.");
        }
    }
}
