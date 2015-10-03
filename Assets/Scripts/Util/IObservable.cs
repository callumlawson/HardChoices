using System;

public interface IObservable
{
    event Action<IObservable> Updated;
}