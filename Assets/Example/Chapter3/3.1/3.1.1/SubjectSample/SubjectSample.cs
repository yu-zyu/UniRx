using UniRx;
using UnityEngine;

namespace Samples.Section3.Subjects
{
    public class SubjectSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            var subject = new Subject<int>();

            //メッセージを発行
            subject.OnNext(1);

            //購読開始
            subject.Subscribe(
                x => Debug.Log("OnNext:" + x),
                ex => Debug.Log("OnError:" + ex),
                () => Debug.Log("OnCompleted:")
                );

            //メッセージを発行
            subject.OnNext(2);
            subject.OnNext(3);

            subject.OnCompleted();

            //Dispose()を忘れない
            subject.Dispose();
        }
    }
}
