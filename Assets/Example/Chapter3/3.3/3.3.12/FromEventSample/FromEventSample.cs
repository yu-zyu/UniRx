using System;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Samples.Section3.FactoryMethods
{
    public class FromEventSample : MonoBehaviour
    {
        //オリジナルのEventArgs
        public sealed class MyEventArgs : EventArgs
        {
            public int MyPropety { get; set; }
        }

        //MyEventArgsを扱うイベントハンドラ
        event EventHandler<MyEventArgs> _onEvent;

        //int型を引数に取る Action
        event Action<int> _callBackAction;

        //uGUIのボタン
        [SerializeField] private Button _uiButton;
        private readonly CompositeDisposable _disposables = new CompositeDisposable();

        // Start is called before the first frame update
        void Start()
        {
            //FromEventPatternを使う場合
            //(sender, eventArgs)を両方使ってイベントをIObservable<MyEventArgs>に変換する
            Observable.FromEventPattern<EventHandler<MyEventArgs>, MyEventArgs>(
                h => h.Invoke, h => _onEvent += h, h => _onEvent -= h)
                .Subscribe()
                .AddTo(_disposables);

            //FromEventを使う場合
            //eventArgsのみを使ってイベントをIObservable<MyEventArgs>に変換する
            Observable.FromEvent<EventHandler<MyEventArgs>, MyEventArgs>(
                h => (sender, e) => h(e), h => _onEvent += h, h => _onEvent -= h)
                .Subscribe(_ => print("FromEvent"))
                .AddTo(_disposables);

            //Action<T> を使ったイベントもObservable<T>にも変換できる
            Observable.FromEvent<int>(
                h => _callBackAction += h, h => _callBackAction -= h)
                .Subscribe()
                .AddTo(_disposables);

            //UnityEventからObservableにも変換可能
            Observable.FromEvent<UnityAction>(
                h => new UnityAction(h),
                h => _uiButton.onClick.AddListener(h),
                h => _uiButton.onClick.RemoveListener(h)
                ).Subscribe()
                .AddTo(_disposables);

            //ただし、UnityEventからObservableに変換する場合は
            //FromEventの糖衣構文として「AsObsrevable()」が容易されている
            _uiButton.onClick.AsObservable().Subscribe().AddTo(_disposables);
        }

        private void OnDestroy()
        {
            //破棄されたときにまとめてDisposeする

            _disposables.Dispose();
        }
    }
}
