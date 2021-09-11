using UniRx;
using UnityEngine;

namespace Samples.Section4.Filters
{
    public class DistinctUntilChangedSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var array = new[] { 1, 2, 2, 3, 1, 1, 2, 2, 2, 3 };

            array.ToObservable()
                .DistinctUntilChanged()
                .Subscribe(x => Debug.Log(x));
        }
    }
}
