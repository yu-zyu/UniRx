using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Samples.Section4.Filters
{
    public class TakeUntil : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //このGameObjectがDestroyされるまでｶｳﾝﾄｱｯﾌﾟし続ける
            Observable.Interval(TimeSpan.FromSeconds(1))
                .TakeUntil(this.OnDestroyAsObservable())
                .Subscribe(x => Debug.Log(x));
        }
    }
}
