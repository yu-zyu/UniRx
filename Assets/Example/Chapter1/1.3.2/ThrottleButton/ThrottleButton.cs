using UniRx;
using UniRx.Triggers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Samples.Section1
{
    public class ThrottleButton : MonoBehaviour
    {
        void Start()
        {
            //Update()のタイミングでAttackボタンが押されているか判定
            //Attackボタンが押されたらSubscribe()の処理を実行
            //そのあと30フレームの間ボタン入力を無視する
            this.UpdateAsObservable()
                //.Where(_ => Input.GetButtonDown("Attack"))
                .Where(_ => Input.GetMouseButtonDown(0))
                .ThrottleFirstFrame(30)
                .Subscribe(_ =>
                {
                    Debug.Log("Attack!");
                });
        }
    }
}
