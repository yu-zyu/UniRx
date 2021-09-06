using UniRx;
using UnityEngine;

namespace Samples.Section3.ReactiveProperty
{
    public class ReactivePropertySample2 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var health = new ReactiveProperty<int>(100);

            health.Subscribe(x => Debug.Log("通知された値:" + x));

            //現在の値と同じ値を設定すると通知は飛ばない
            Debug.Log("<Valueに100を設定>");
            health.Value = 100;

            //強制的に通知を飛ばす場合はSetValueAndForceNotifyを使って値を設定する
            Debug.Log("<Value の上書きを強制通知>");
            health.SetValueAndForceNotify(100);

            health.Dispose();
        }
    }
}
