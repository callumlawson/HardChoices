using System;

namespace Assets.Scripts.Util
{
    public interface IObservable<T>
    {
        event Action<T> Updated;
    }
}