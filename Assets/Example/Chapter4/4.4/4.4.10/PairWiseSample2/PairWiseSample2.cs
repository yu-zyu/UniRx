using UniRx;
using UnityEngine;

namespace Samples.Section4.Synthesizers
{
    public class PairWiseSample2 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //移動したときにその差分を計算する
            transform.ObserveEveryValueChanged(x => x.position)
                .Pairwise((p, c) => c - p)
                .Subscribe(x => Debug.Log("移動した距離：" + x));
        }
    }
}
