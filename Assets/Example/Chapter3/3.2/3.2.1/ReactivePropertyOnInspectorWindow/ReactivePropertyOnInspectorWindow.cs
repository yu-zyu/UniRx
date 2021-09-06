using System;
using UniRx;
using UnityEngine;

namespace Samples.Section3.ReactiveProperty
{
    public class ReactivePropertyOnInspectorWindow : MonoBehaviour
    {
        //ジェネリック版表示されない
        public ReactiveProperty<int> A;

        //Int固定版　表示される
        public IntReactiveProperty B;

        public LongReactiveProperty C;
        public ByteReactiveProperty D;
        public FloatReactiveProperty E;
        public DoubleReactiveProperty F;
        public StringReactiveProperty G;
        public BoolReactiveProperty H;
        public Vector2ReactiveProperty I;
        public Vector3ReactiveProperty J;
        public Vector4ReactiveProperty K;
        public ColorReactiveProperty L;
        public RectReactiveProperty M;
        public AnimationCurveReactiveProperty N;
        public BoundsReactiveProperty O;
        public QuaternionReactiveProperty P;

        public MagicalReactiveProperty Q;
        public FruitReactiveProperty R;
    }

    [Serializable]
    public class MagicalReactiveProperty : ReactiveProperty<Magical>
    {
    
    }

    [Serializable]
    public class Magical
    {
      public int magicalInt;
      public float magicalFloat;

    }
}
