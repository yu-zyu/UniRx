using System;
using System.Collections;
using UniRx;
using UnityEngine;

namespace Samples.Section2.MyObservers
{
    public class CountDownEventProvider : MonoBehaviour
    {
        //カウントする秒数
        [SerializeField] private int _countSeconds = 10;

        //Subjectのインスタンス
        private Subject<int> _subject;

        //SubjectのIObservableインターフェースの部分のみ公開する
        public IObservable<int> CountDownObservable => _subject;

        //上記の事は以下と同様
        //private IObservable<int> ob;
        //  public IObservable<int> CountDownObservable {
        //    get => _subject;
        //    set => ob = value;
        //  }
        //public IObservable<int> CountDownObservable {
        //    get { return _subject; }
        //    set { ob = value;  }
        //}

        private void Awake()
        {
            //Subject生成
            _subject = new Subject<int>();
            //カウントダウンするコルーチン起動
            StartCoroutine(CountCoroutine());
        }

        //指定秒数カウントし、その都度メッセージを発行するコルーチン
        private IEnumerator CountCoroutine()
        {
            var current = _countSeconds;

            while(current > 0)
            {
                //現在の値を発行する
                _subject.OnNext(current);
                current--;
                yield return new WaitForSeconds(1.0f);
            }

            //最後に0とOnConmpletedメッセージを発行する
            _subject.OnNext(0);
            _subject.OnCompleted();
        }

        private void OnDestroy()
        {
            //GameObjectが破棄されたらSubjectも解放する
            _subject.Dispose();
        }
    }
}
