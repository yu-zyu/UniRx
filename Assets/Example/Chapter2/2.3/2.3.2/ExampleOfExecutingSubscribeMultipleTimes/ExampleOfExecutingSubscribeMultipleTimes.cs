using UniRx;
using UnityEngine;

public class ExampleOfExecutingSubscribeMultipleTimes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var subject = new Subject<int>();

        //発行された値を途中でログに出すObservable
        //DoはOnNext()のたびに呼ばれる
        var observable = subject.Do(x => Debug.Log("Do:" + x));

        //2会Subscribeする
        observable.Subscribe(x => Debug.Log("First subscribe:" + x));
        observable.Subscribe(x => Debug.Log("Second subscribe:" + x));

        subject.OnNext(1);
        subject.OnCompleted();
        subject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
