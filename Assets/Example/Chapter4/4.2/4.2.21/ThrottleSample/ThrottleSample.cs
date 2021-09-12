using System;
using UniRx;
using UnityEngine;

namespace Samples.Section4.Filters
{
    public class ThrottleSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //GameObjectが静止するまで待ってからその座標を取り出す
            transform
                .ObserveEveryValueChanged(x => x.position)
                .Throttle(TimeSpan.FromSeconds(1)) //1秒
                .Subscribe(x => Debug.Log(x));
        }
    }
}
