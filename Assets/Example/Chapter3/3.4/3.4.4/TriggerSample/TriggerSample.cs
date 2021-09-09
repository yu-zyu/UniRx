using UniRx;
using UniRx.Triggers; //UniRx.Triggersが必要
using UnityEngine;

namespace Samples.Section3.UnityEvents
{
    public class TriggerSample : MonoBehaviour
    {
        //自分とは別のGameObject
        [SerializeField] private GameObject _childGameObject;

        // Start is called before the first frame update
        void Start()
        {
            //UniRx.Triggersを追加する事で、
            //Unityの各イベントをObservableとして扱う事ができるようになる
            //自身のGameObjectでのUpdateをObservableに変換する
            this.UpdateAsObservable()
                .Subscribe(_ =>
                {
                    transform.position += Vector3.forward * Time.deltaTime;
                });

            //他のGameObjectのOnCollisionEnterをObseravableに変換する
            _childGameObject.OnCollisionEnterAsObservable()
                .Subscribe(collision =>
                {
                    Debug.Log(collision.gameObject.name + "に衝突しました");
                }).AddTo(this); //他のGameObjectを参照するならAddToを併用した方が安全

            //自身のGameObjectのOnDestroyをObservableに変換する
            this.OnDestroyAsObservable()
                .Subscribe(_ =>
                {
                    Debug.Log("破棄されました");
                });
        }
    }
}
