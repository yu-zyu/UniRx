using System.Collections;
using UniRx;
using UnityEngine;

namespace Samples.Section3.ReactiveProperty
{
    //カウントダウンするタイマ
    public class ReactivePropertyTiimerSample : MonoBehaviour
    {
        //実態としてReactivePropertyを定義
        [SerializeField]
        private IntReactiveProperty _current = new IntReactiveProperty(60);

        //現在のタイマの値（読み取り専用）
        //ReactivePropertyをIRえあｄOnlyReactivePropertyにアップキャスト
        public IReadOnlyReactiveProperty<int> CurrentTime => _current;

        void Start()
        {
            StartCoroutine(CountDownCoroutine());
            _current.AddTo(this);
        }

        private IEnumerator CountDownCoroutine()
        {
            while(_current.Value > 0)
            {
                //1秒に１つずつ値を更新する
                _current.Value--;
                yield return new WaitForSeconds(1);
            }
        }
    }
}
