using UniRx;
using UnityEngine;

public class HotConversionExampleUsingSubject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var originalSubject = new Subject<string>();

        //OnNextの内容をスペース区切りで連結し、最後の1つだけを出力するObservable
        var apendStringObservable =
            originalSubject
            .Scan((previous, current) => previous + " " + current)
            .Last();

        //連結用のSubject
        var publishSubject = new Subject<string>();

        //元のObsrvableに対して、PublishSubjectを使ってSubscribeを実行する
        //この時点でappendStringObservableが動き始める
        apendStringObservable.Subscribe(publishSubject);

        originalSubject.OnNext("I");
        originalSubject.OnNext("have");

        //途中でpubleshSubjectのほうをSubscribeする
        publishSubject.Subscribe(x => Debug.Log(x));

        originalSubject.OnNext("a");
        originalSubject.OnNext("pen");
        originalSubject.OnCompleted();

        //Hot変換解除
        publishSubject.Dispose();
        originalSubject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
