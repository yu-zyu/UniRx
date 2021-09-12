using UniRx;
using UnityEngine;
namespace Samples.Section4.Synthesizers
{
    public class PairWiseSample1 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Observable.Range(0, 5) // 0,1,2,3,4
                .Pairwise()
                .Subscribe(p =>
                {
                    //Current と Previousにそれぞれの値が入っている
                    Debug.Log($"{p.Previous}:{p.Current}");
                });
        }
    }
}
