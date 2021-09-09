using UniRx;
using UnityEngine;

namespace Samples.Section3.FactoryMethods
{
    public class NextFrameSample : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        // Start is called before the first frame update
        void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            //スペースキーが押されたら、Rigidbodyに力を加える
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //次のFixedUpdateのタイミングで処理を実行する
                Observable.NextFrame(FrameCountType.FixedUpdate)
                    .Subscribe(_ =>
                    {
                        _rigidbody.AddForce(Vector3.up, ForceMode.VelocityChange);
                    });
            }
        }
    }
}
