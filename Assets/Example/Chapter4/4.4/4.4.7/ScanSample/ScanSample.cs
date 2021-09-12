using UniRx;
using UnityEngine;

namespace Samples.Section4.Synthesizers
{
    public class ScanSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //発行された値を順次足し合わせながら出力する
            Observable.Range(1,5)
                .Scan(0, (pre, cur) => pre + cur)
                .Subscribe(x => Debug.Log(x));
        }
    }
}
