using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Samples.Section4.Filters
{
    public class DistincrSample2 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            this.OnCollisionEnterAsObservable()
                //過去に衝突したことがあるGameObjectは無視
                //Collision型からGameObjectのパラメータのみを取り出して比較する
                .Distinct(x => x.gameObject)
                .Subscribe(x => Debug.Log(x.gameObject.name));
        }
    }
}
