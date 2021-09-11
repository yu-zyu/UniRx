using UniRx;
using UnityEngine;

namespace Samples.Section4.Filters
{
    public class DistinctSample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var array = new[] { 1, 2, 2, 3, 1, 1, 2, 2, 3 };

            array.ToObservable()
                //過去にすでに発行したことがあるメッセージは無視
                .Distinct()
                .Subscribe(x => Debug.Log(x));
        }
    }
}
