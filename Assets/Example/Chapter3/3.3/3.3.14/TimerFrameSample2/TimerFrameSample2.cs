using UniRx;
using UnityEngine;

public class TimerFrameSample2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var timer = Observable.TimerFrame(dueTimeFrameCount: 5, periodFrameCount: 10);

        Debug.Log("Subscribe()したフレーム：" + Time.frameCount);

        timer.Subscribe(
            x => Debug.Log($"{x} - {Time.frameCount}"),
            () => Debug.Log("OnCompleted")
            ).AddTo(this); //Dispose() の実行を忘れない
    }
}
