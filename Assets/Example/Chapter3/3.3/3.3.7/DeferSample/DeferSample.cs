using UniRx;
using UnityEngine;

namespace Samples.Section3.FactoryMethods
{
    public class DeferSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //「乱数を返すObservable」をSubsribe()されるたびに生成する
            var rand = Observable.Defer(() =>
            {
                //乱数を用意
                var randomValue = UnityEngine.Random.Range(0, 100);
                //乱数を返すObservable
                return Observable.Return(randomValue);
            });

            //複数回Subscribe()
            rand.Subscribe(x => Debug.Log(x));
            rand.Subscribe(x => Debug.Log(x));
            rand.Subscribe(x => Debug.Log(x));
        }
    }
}
