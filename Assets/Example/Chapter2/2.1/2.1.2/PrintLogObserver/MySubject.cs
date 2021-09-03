using System;
using System.Collections.Generic;
using UniRx;

namespace Samples.Section2.MySubjects
{
    //独自実装　Subject
    public class MySubject<T> : ISubject<T>, IDisposable
    {
        public bool IsStopped { get; } = false;
        public bool IsDisposed { get; } = false;

        private readonly object _lockObject = new object();

        //途中で発生した例外
        private Exception error;

        //自身を購読しているObserverリスト
        private List<IObserver<T>> observers;

        public MySubject()
        {
            observers = new List<IObserver<T>>();
        }

        //IObserver.OnNextの実装
        public void OnNext(T value)
        {
            if (IsStopped) return;
            lock (_lockObject)
            {
                ThrowIfDisposed();

                //自身を行動しているobserver全員へメッセージをばらまく
                foreach(var observer in observers)
                {
                    observer.OnNext(value);
                }
            }
        }

        //IObsrever.OnErrorの実装
        public void OnError(Exception error)
        {
            lock (_lockObject)
            {
                ThrowIfDisposed();
                if (IsStopped) return;
                this.error = error;

                try
                {
                    foreach(var observer in observers)
                    {
                        observer.OnError(error);
                    }
                }
                finally
                {
                    Dispose();
                }
            }
        }

        //IObserver.OnCompletedの実装
        public void OnCompleted()
        {
            lock (_lockObject)
            {
                ThrowIfDisposed();
                if (IsStopped) return;
                try
                {
                    foreach(var observer in observers)
                    {
                        observer.OnCompleted();
                    }
                }
                finally
                {
                    Dispose();
                }
            }
        }

        //IObservable.Subscribe の実装
        public IDisposable Subscribe(IObserver<T> observer)
        {
            lock (_lockObject)
            {
                if (IsStopped)
                {
                    //すでに動作を終了しているならOnErrorメッセージ、
                    //またはOnCmpletedメッセージを発行する
                    if(error != null)
                    {
                        observer.OnError(error);
                    }
                    else
                    {
                        observer.OnCompleted();
                    }

                    return Disposable.Empty;
                }

                observers.Add(observer); //リストに追加
                return new Subscription(this, observer);
            }
        }

        private void ThrowIfDisposed()
        {
            if (IsDisposed) throw new ObjectDisposedException("MySubject");
        }

        //SubscribeのDisposeを実現するために用いるinner class
        private sealed class Subscription : IDisposable
        {
            private readonly IObserver<T> _observer;
            private readonly MySubject<T> _parent;

            public Subscription(MySubject<T> parent, IObserver<T> observer)
            {
                this._parent = parent;
                this._observer = observer;
            }

            public void Dispose()
            {
                //Dispose されたらObserverリストから消去する
                _parent.observers.Remove(_observer);
            }
        }

        public void Dispose()
        {
            lock (_lockObject)
            {
                if (!IsDisposed)
                {
                    observers.Clear();
                    observers = null;
                    error = null;
                }
            }
        }
    }
}
