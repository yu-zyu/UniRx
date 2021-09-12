﻿using UniRx;
using UnityEngine;

namespace Samples.Section4.Filters
{
    public class TakeWhile : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var array = new[] { 1, 3, 4, 7, 2, 5, 9 };

            array.ToObservable()
                //数値が5より小さい間は通過させる
                //一度でも5以上になったら終了
                .TakeWhile(x => x < 5)
                .Subscribe(
                x => Debug.Log(x),
                () => Debug.Log("OnCompleted")
                );
        }
    }
}
