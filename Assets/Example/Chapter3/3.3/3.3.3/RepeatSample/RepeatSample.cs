using UniRx;
using UnityEngine;

namespace Samples.Section3.FactoryMethods
{
    public class RepeatSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //"yes"を3個発行する
            Observable.Repeat(value: "yes", repeatCount:3)
                .Subscribe(
                x => Debug.Log("OnNext:" + x),
                ex => Debug.Log("OnError:" + ex),
                () => Debug.Log("OnCompleted")
                );
        }
    }
}
