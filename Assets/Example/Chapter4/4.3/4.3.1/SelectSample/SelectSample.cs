using UniRx;
using UnityEngine;

namespace Samples.Section4.Converters
{
    public class SelectSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Observable.Range(1, 5)
                //メッセージの内容を10倍する
                .Select(x => x * 10)
                .Subscribe(x => Debug.Log(x));
        }
    }
}
