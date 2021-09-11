using UniRx;
using UnityEngine;

namespace Samples.Section4.Filters
{
    public class WhereSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Observable.Range(0, 10)
                .Where(x => x % 2 == 0) //偶数のみを許可する
                .Subscribe(x => Debug.Log(x));
        }
    }
}
