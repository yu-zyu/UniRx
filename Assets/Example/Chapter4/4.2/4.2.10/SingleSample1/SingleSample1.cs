using UniRx;
using UnityEngine;

namespace Samples.Section4.Filters
{
    public class SingleSample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Observable.Range(1, 10)
                //5のみを通過する
                .Single(x => x == 5)
                .Subscribe(
                x => Debug.Log(x),
                ex => Debug.LogError(ex),
                () => Debug.Log("OnCompleted"));
        }
    }
}
