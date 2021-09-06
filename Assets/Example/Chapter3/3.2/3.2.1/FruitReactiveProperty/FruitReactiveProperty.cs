using System;
using UniRx;

namespace Samples.Section3.ReactiveProperty
{
    //フルーツ一覧を表すEnum
    public enum Fruit
    {
        Apple,
        Banana,
        Peach,
        Melon,
        Orange
    }

    //Fruit型を扱うReactiveProperty
    [Serializable]
    public class FruitReactiveProperty : ReactiveProperty<Fruit>
    {
        public FruitReactiveProperty()
        {

        }

        public FruitReactiveProperty(Fruit init) : base(init)
        {

        }
    }
}
