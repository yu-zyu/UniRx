using UniRx;
using UnityEngine;

namespace Samples.Section3.FactoryMethods
{
    public class RangeSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //0から5個、連続した整数値を発行する
            Observable.Range(start: 0, count: 5)
                .Subscribe(
                x => Debug.Log("OnNext:" + x),
                ex => Debug.Log("OnError:" + ex),
                () => Debug.Log("OnCompleted")
                );
        }
    }
}
