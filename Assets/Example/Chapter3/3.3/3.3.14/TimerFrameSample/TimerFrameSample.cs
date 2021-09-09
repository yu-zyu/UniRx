using UniRx;
using UnityEngine;

public class TimerFrameSample : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var timer = Observable.TimerFrame(dueTimeFrameCount: 5);
        Debug.Log("Subscribe()したフレーム：" + Time.frameCount);

        timer.Subscribe(x =>
        {
            Debug.Log("OnNextが発行されたフレーム：" + Time.frameCount);
            Debug.Log("OnNextの中身：" + x);
        }, () => Debug.Log("OnCompleted"));
    }
}
