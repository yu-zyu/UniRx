using UniRx;
using UnityEngine;

namespace Samples.Section4.Filters
{
    public class FirstOrDefaultSample2 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //OnCompletedメッセージのみを発行する
            Observable.Empty<int>()
                .FirstOrDefault()
                .Subscribe(
                x => Debug.Log(x),
                ex => Debug.LogError(ex),
                () => Debug.Log("OnCompleted")
                );
        }
    }
}
