using UnityEngine;
using UniRx;

public class UseDedicatedOperatorInsteadOfSubject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var originalSubject = new Subject<string>();

        //OnNextの内容をスペース区切りで連結し、最後の１つだけを出力するObservable
        //IConnectableObservable<string>になっている
        IConnectableObservable<string> appendStringObservable =
            originalSubject
            .Scan((previous, current) => previous + " " + current)
            .Last()
            .Publish(); // Hot変換するOperator

        //IconnectableObservable.Connect()を呼び出すと内部でSubscribeの実行が走る
        var disposable = appendStringObservable.Connect();

        originalSubject.OnNext("I");
        originalSubject.OnNext("have");

        //appendStringObservableを直接Subscribeすればよい
        appendStringObservable.Subscribe(x => Debug.Log(x));
        originalSubject.OnNext("a");
        originalSubject.OnNext("pen");
        originalSubject.OnCompleted();

        //Hot変換解除
        disposable.Dispose();
        originalSubject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
