using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class TimerViewUniRx : MonoBehaviour
{
    //それぞれインスタンスはインスペクタビューから設定

    [SerializeField] private TimeCounterUniRx timeCounter;
    [SerializeField] private Text counterText; //uGUIのText

    void Start()
    {
        //タイマのカウンタが変化したイベントを受けてuGUI Textを更新する
        timeCounter.OnTimeChanged.Subscribe(time =>
        {
            //現在のタイマ値をUIに反映する
            counterText.text = time.ToString();
        });
    }
}
