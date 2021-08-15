﻿using System.Collections;
using UniRx;
using UnityEngine;
using System; // .NET 4.xモードで動かす場合は必須

/// <summary>
/// 100からカウントダウンし、Debug.Logにその値を表示するサンプル
/// </summary>
public class TimeCounterUniRx : MonoBehaviour
{
    //イベントを発行する核となるインスタンス
    private Subject<int> timerSubject = new Subject<int>();

    //イベントの購読側だけを公開
    public IObservable<int> OnTimeChanged
    {
        get { return timerSubject; }
    } 

    void Start()
    {
        StartCoroutine(TimerCoroutine());
    }

    IEnumerator TimerCoroutine()
    {
        //100からカウントダウン
        var time = 100;
        while (time > 0)
        {
            time--;

            //イベントを発行
            timerSubject.OnNext(time);

            //1秒待つ
            yield return new WaitForSeconds(1);
        }
    }
}
