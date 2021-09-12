using System;
using UniRx;
using UnityEngine;

namespace Samples.Section4.Synthesizers
{
    public class BatchFrameSample1 : MonoBehaviour
    {
        //敵オブジェクトの管理をしているコンポーネント（という想定）
        [SerializeField] private EnemyManager _enemyManager = new EnemyManager();

        // Start is called before the first frame update
        void Start()
        {
            //倒した敵のIDがObservableで通知される（という想定）
            IObservable<int> killed = _enemyManager.OnKilledEnemyIdObservable;

            //フレーム数0,FrameCountType.EndOfFrameを指定する事で、
            //このフレーム中に発生したイベントを１つにまとめられる
            killed
                .BatchFrame(0, FrameCountType.EndOfFrame)
                .Subscribe(ids =>
                {
                    //1フレーム中に倒した敵の数を出力する
                    Debug.Log(Time.frameCount + ":" + ids.Count);
                });
        }
    }

    public class EnemyManager
    {
        private Subject<int> enemyId = new Subject<int>();

        public IObservable<int> OnKilledEnemyIdObservable => enemyId;
    }
}
