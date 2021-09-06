using UniRx;
using UnityEngine;

namespace Sample.Section3.Subjects
{
    public class ReplaySubjectSample : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            //過去３メッセージまでキャッシュするReplaySubject
            var subject = new ReplaySubject<int>(bufferSize: 3);

            //メッセージを発行
            for(int i=0; i < 10; i++)
            {
                subject.OnNext(i);
            }

            //OnCompletedメッセージもキャッシュされる
            subject.OnCompleted();

            //OnErrorメッセージもキャッシュできる
            //subject.OnError(new Exception("Error!"));

            //購読
            subject.Subscribe(
                x => Debug.Log("OnNext:" + x),
                ex => Debug.LogError("OnError:" + ex),
                () => Debug.Log("OnCompleted"));

            subject.Dispose();
        }
    }
}
