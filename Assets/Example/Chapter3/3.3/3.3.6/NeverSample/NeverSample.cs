using UniRx;
using UnityEngine;

namespace Samples.Section3.FactoryMethods
{
    public class NeverSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Observable.Never<int>()
                .Subscribe(
                x => Debug.Log("OnNext:" + x),
                ex => Debug.LogError("OnError:" + ex.Message),
                () => Debug.Log("OnCompleted")
                );
        }
    }
}
