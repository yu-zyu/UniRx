using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Samples.Section4.Synthesizers
{
    public class BufferSample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Observable.Range(1, 6)
                //値を1つ前のものとセットにする
                .Buffer(2, 1)
                .Subscribe(x =>
                {
                    if (x.Count > 1)
                    {
                        Debug.Log(x[0] + ":" + x[1]);
                    }
                    else
                    {
                        Debug.Log(x[0]);
                    }
                });
        }
    }
}
