using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class IssueAnOnCompletedMessage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //データソース作成
        var subject = new Subject<int>();

        //Observableの購読
        subject.Subscribe(
            //OnNextメッセージのハンドリング
            x => Debug.Log(x),
            //OnNextメッセージのハンドリング
            () => Debug.Log("OnCompleted")
            );

        subject.OnNext(1);
        subject.OnNext(2);
        subject.OnNext(3);

        //OnNextメッセージを発行するとSubscribeは終了しObservableが破棄される
        //さらにこのSubject自体も完了状態で固定される
        subject.OnCompleted();

        //破棄
        subject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
