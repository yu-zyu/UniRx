using UniRx;
using UnityEngine;

namespace Samples.Section4.Synthesizers
{
    public class ConcatSample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var s1 = Observable.Range(0, 3);
            var s2 = Observable.Range(10, 3);

            s1.Concat(s2)
                .Subscribe(x => Debug.Log(x));
        }
    }
}
