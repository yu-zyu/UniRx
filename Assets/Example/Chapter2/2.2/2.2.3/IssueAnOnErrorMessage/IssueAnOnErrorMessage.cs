using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class IssueAnOnErrorMessage : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //データソース作成
        var subject = new Subject<string>();

        //Observableの購読
        subject
            //string型をint型に変換、失敗したら例外
            .Select(str => int.Parse(str))
            .Subscribe(
              //OnNextメッセージのハンドリング
              x => Debug.Log(x),
              //OnErrorメッセージのハンドリング
              ex => Debug.LogError("例外が発生しました: " + ex.Message),
              //OnCompletedメッセージのハンドリング
              () => Debug.Log("OnCompleted!")
            );

        subject.OnNext("1");
        subject.OnNext("2");

        //int.Parseに失敗して例外が発生する
        //(OnErrorメッセージがSelectオペレータから発行される）
        //そのためメッセージ処理後に購読が終了する
        subject.OnNext("Three");

        //OnErrorメッセージ発生により購読は終了済み
        //有効なObserverがいないため通知されない
        subject.OnNext("4");

        // ---

        // ただしSubject自体が例外を発行したわけではないのでSubjectはまだ正常稼働中
        // そのため再講読すればまた利用ができる
        subject.Subscribe(
            x => Debug.Log(x),
            () => Debug.Log("Completed!")
            );

        subject.OnNext("Hello!");
        subject.OnCompleted();
        subject.Dispose();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

