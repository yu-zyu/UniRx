using UniRx;
using UnityEngine;

namespace Samples.Section3.FactoryMethods
{
    public class ReturnSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Observable.Return(100)
                .Subscribe(
                x => Debug.Log("OnNext:" + x),
                ex => Debug.Log("OnError:" + ex),
                () => Debug.Log("OnCompleted:")
                );
        }
    }
}
