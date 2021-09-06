using UniRx;
using UnityEngine;

namespace Samples.Section3.Subjects.Async
{
    //プレイヤのテクスチャを変更する
    public class PlayerTextureChanger : MonoBehaviour
    {
        [SerializeField]
        private GameResourceProvider _gameResourceProvider;

        // Start is called before the first frame update
        void Start()
        {
            //プレイヤのテクスチャの読み込みが完了次第テクスチャを変更する
            _gameResourceProvider.PlayerTextureAsync
                .Subscribe(SetMyTexture)
                .AddTo(this);
        }

        private void SetMyTexture(Texture newTexture)
        {
            var r = GetComponent<Renderer>();
            r.sharedMaterial.mainTexture = newTexture;
        }
    }
}
