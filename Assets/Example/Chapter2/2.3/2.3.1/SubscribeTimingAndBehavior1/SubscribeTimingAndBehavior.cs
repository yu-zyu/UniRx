using UniRx;
using UnityEngine;

public class SubscribeTimingAndBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<string>();

        //OnNextの内容をスペース区切りで連結し、最後の１つだけを出力するObservable
        var appendStringObservable =
            subject.Scan((previous, current) => previous + " " + current)
            .Last();

        //Subscribe (このタイミングでObservableが動き出す）
        appendStringObservable.Subscribe(x => Debug.Log(x));

        subject.OnNext("I");
        subject.OnNext("have");
        subject.OnNext("a");
        subject.OnNext("pen");
        subject.OnCompleted();
        subject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
