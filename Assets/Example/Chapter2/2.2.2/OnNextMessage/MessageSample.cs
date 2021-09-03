using System;
using UniRx;
using UnityEngine;

namespace Sample.Section2.Observables
{
    public class MessageSample : MonoBehaviour
    {
        //残り時間
        [SerializeField] private float _countTimeSeconds = 30f;

        //時間切れを通知するObservable
        public IObservable<Unit> OnTimeUpAsyncSubject => _onTimeUpSyncSubject;
        //AsyncSubject(メッセージを一度だけ発行できるSubject)
        private readonly AsyncSubject<Unit> _onTimeUpSyncSubject = new AsyncSubject<Unit>();
        private IDisposable _disposable;

        // Start is called before the first frame update
        void Start()
        {
            //指定時間経過したらメッセージを通知する
            _disposable = Observable
                .Timer(TimeSpan.FromSeconds(_countTimeSeconds))
                .Subscribe(_ =>
                {
                    //Timerが発火したら、
                    //Unit型のメッセージを発行する
                    Debug.Log("magical");
                    _onTimeUpSyncSubject.OnNext(Unit.Default);
                    _onTimeUpSyncSubject.OnCompleted();
                });
        }

        private void OnDestroy()
        {
            //Observableがまだ動いていたら止める
            _disposable?.Dispose();

            //AsyncSubjectを破棄
            _onTimeUpSyncSubject.Dispose();
        }
    }
}
