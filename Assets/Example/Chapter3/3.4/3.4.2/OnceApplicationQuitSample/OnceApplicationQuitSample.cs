using UniRx;
using UnityEngine;

namespace Samples.Section3.FactoryMethods
{
    public class OnceApplicationQuitSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //OnApplicationQuitの実行タイミングで発火する
            Observable.OnceApplicationQuit()
                .Subscribe(_ => Debug.Log("アプリケーションが終了しました"));
        }
    }
}
