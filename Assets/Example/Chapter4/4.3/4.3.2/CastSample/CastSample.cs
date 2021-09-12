using UniRx;
using UnityEngine;

namespace Samples.Section4.Converters
{
    public class CastSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var objects = new object[]
            {
                "hoge",
                "fuga",
                'a',
                -1,
                "fuga",
                'Z',
                0.1
            };

            objects.ToObservable()
                //string型にcastする
                .Cast<object, string>()
                .Subscribe(
                x => Debug.Log(x),
                ex => Debug.LogError(ex),
                () => Debug.Log("OnCompleted"));
        }
    }
}
