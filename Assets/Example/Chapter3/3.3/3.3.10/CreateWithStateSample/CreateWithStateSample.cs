using System;
using UniRx;
using UnityEngine;

namespace Samples.Section3.FactoryMethods
{
    public class CreateWithStateSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            CreateCountObservable(10).Subscribe(x => Debug.Log(x));
        }

        //指定個数、連続した値を発行する（Rangeと同じ挙動）Observableを作って返す
        private IObservable<int> CreateCountObservable(int count)
        {
            //countが0以下の場合はOnCompletedメッセージのみを返す
            if (count <= 0) return Observable.Empty<int>();

            //指定した数だけ連続する値を発行する
            return Observable.CreateWithState<int, int>(
                state: count,
                subscribe: (maxCount, observer) =>
                 {
                    //maxCountにstateで指定した値が入っている
                    for (int i = 0; i < maxCount; i++)
                     {
                         observer.OnNext(maxCount);
                     }

                     observer.OnCompleted();
                     return Disposable.Empty;
                 });
        }
    }
}
