using UniRx;
using UnityEngine;

public class SubscribeTimingAndBehavior2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<string>();

        //OnNextの内容をスペース区切りで連結し、最後の１つだけを出力するObservable
        var appendStringObservable =
            subject.Scan((previous, current) => previous + " " + current)
            .Last();

        //Subscribeされる前に値を発行する
        subject.OnNext("I");
        subject.OnNext("have");

        //途中でSubscribeする
        appendStringObservable.Subscribe(x => Debug.Log(x));

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
