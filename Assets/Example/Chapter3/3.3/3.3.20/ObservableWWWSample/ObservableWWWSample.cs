using UniRx;
using UnityEngine;

namespace Samples.Section3.FactoryMethods
{
    public class ObservableWWWSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var uri = "https://magical-iga.com/";

            //結果（www.text)のみを受け取る場合
            ObservableWWW.Get(uri)
                .Subscribe(x => Debug.Log(x));

            //通信終了時にwwwごと受け取る場合
            ObservableWWW.GetWWW(uri)
                .Subscribe(www => Debug.Log(www.text));
        }
    }
}
