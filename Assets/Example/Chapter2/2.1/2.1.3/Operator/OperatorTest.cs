using UniRx;
using UnityEngine;

namespace Samples.Section2.Operators
{
    public class OperatorTest : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var subject = new Subject<int>();

            //そのままSubscribe
            subject.Subscribe(x => Debug.Log("raw: " + x));

            // 0 以下を除外してSubscribe
            // Whereを間に挟む事で、条件を満たすメッセージのみを通過させる事ができる
            subject
                .Where(x => x > 0)
                .Subscribe(x => Debug.Log("filter:" + x));

            //メッセージ発行
            subject.OnNext(1);
            subject.OnNext(-1);
            subject.OnNext(3);
            subject.OnNext(0);

            //終了
            subject.OnCompleted();
            subject.Dispose();
        }
    }
}
