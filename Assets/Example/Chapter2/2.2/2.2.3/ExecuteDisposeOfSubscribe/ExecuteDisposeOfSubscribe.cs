using System;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ExecuteDisposeOfSubscribe : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<int>();

        //同じSubjectを3回Subscribe（３つのObservableが生成される）
        IDisposable disposableA = subject
            .Subscribe(x => Debug.Log("A:" + x)); //A
        IDisposable disposableB = subject
            .Subscribe(x => Debug.Log("B:" + x)); //B
        IDisposable disposableC = subject
            .Subscribe(x => Debug.Log("C:" + x)); //C

        //値を発行
        subject.OnNext(100);

        //AのDisposeを実行する
        disposableA.Dispose();

        Debug.Log("---");

        //再度値を発行
        subject.OnNext(200);

        //終了　（全Observable破棄）
        subject.OnCompleted();

        //Subject自体を破棄する
        subject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
