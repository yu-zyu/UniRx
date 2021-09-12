using UniRx;
using UnityEngine;

namespace Samples.Section4.Synthesizers
{
    public class AggregateSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //発行された値をすべて足し合わせる
            Observable.Range(0, 10)
                .Aggregate(0, (pre, cur) => pre + cur)
                .Subscribe(x => Debug.Log(x));
        }
    }
}
