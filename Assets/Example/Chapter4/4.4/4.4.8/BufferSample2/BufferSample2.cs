using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace Samples.Section4.Synthesizers
{
    public class BufferSample2 : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //マウスクリックイベント
            var mouseDown =
                this.UpdateAsObservable().Where(_ => Input.GetMouseButtonDown(0));
            mouseDown
                //マウスクリックイベントをバッファリングする
                //バッファの解放条件は
                //「最後にクリックされてから500msの間マウスクリックがなかったとき」
                .Buffer(mouseDown.Throttle(TimeSpan.FromMilliseconds(500)))
                //クリックされた回数でフィルタリング
                .Where(x => x.Count == 2)
                .Subscribe(_ => Debug.Log("ダブルクリックされました"));
        }
    }
}
