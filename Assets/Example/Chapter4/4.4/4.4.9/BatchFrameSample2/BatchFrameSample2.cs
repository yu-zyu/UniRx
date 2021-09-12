using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Samples.Section4.Synthesizers
{
    public class BatchFrameSample2 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var rigidBody = GetComponent<Rigidbody>();

            //ジャンプボタンが入力されたら通知されるObservable
            IObservable<Unit> jumpButton =
                this.UpdateAsObservable()
                .Where(_ => Input.GetButtonDown("Jump"));
            //ジャンプボタンがおされたら次のFixedUpdateでジャンプ処理をする
            jumpButton
                .BatchFrame(0, FrameCountType.FixedUpdate)
                .Subscribe(_ =>
                {
                    rigidBody.AddForce(Vector3.up, ForceMode.VelocityChange);
                });
        }
    }
}
