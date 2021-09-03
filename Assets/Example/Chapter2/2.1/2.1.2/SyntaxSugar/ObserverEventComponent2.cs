using System;
using UniRx;
using UnityEngine;

namespace Samples.Section2.MyObservers
{
    public class ObserverEventComponent2 : MonoBehaviour
    {
        [SerializeField]
        private CountDownEventProvider _countDownEventProvider;

        //Observerのインスタンス
        private PrintLogObserver<int> _printLogObserver;
        private IDisposable _disposable;

        // Start is called before the first frame update
        void Start()
        {
            //SubjectのSubscribeを呼び出して、observerを登録する
            _disposable = _countDownEventProvider
                .CountDownObservable
                .Subscribe(
                  x => Debug.Log(x), //OnNext
                  ex => Debug.Log(ex), //OnError
                  () => Debug.Log("OnCompleted!") //OnCompleted
                );
        }

        private void OnDestroy()
        {
            //GameObject破棄時にイベント購読を中断する 
            _disposable?.Dispose();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
