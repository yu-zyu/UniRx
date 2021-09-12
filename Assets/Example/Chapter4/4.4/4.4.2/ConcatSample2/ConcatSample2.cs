using System;
using UniRx;
using UnityEngine;

namespace Samples.Section4.Synthesizers
{
    public class ConcatSample2 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //Observableを扱う Oservable
            IObservable<IObservable<int>> streams =
                Observable
                .Range(1, 3)
                .Select(x =>
                {
                    return Observable.Range(x * 100, 3);
                });

            streams
                .Concat()
                .Subscribe(x => Debug.Log(x));
        }
    }
}
