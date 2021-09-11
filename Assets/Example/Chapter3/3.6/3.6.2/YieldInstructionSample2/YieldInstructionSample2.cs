using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Samples.Section3.Coroutines
{
    public class YieldInstructionSample2 : MonoBehaviour
    {
        //uGUIのButton
        [SerializeField] private Button _moveBotton;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(MoveCoroutine());
        }

        //uGUIのButtonが押されたら1秒間オブジェクトを前進させるコルーチン
        private IEnumerator MoveCoroutine()
        {
            while (true)
            {
                //Buttonが押されるまで待つ
                //OnClickAsObservable()は無限腸ストリームなので、Take(1)で長さを１に制限する
                yield return _moveBotton
                .OnClickAsObservable()
                .Take(1)
                .ToYieldInstruction();

                var start = Time.time;
                while(Time.time - start <= 1.0f)
                {
                    transform.position += Vector3.forward * Time.deltaTime;
                    yield return null;
                }
            }
        }
    }
}
