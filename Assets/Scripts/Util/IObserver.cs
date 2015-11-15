namespace Assets.Scripts.Util
{
    interface IObserver<in T>
    {
        void OnDataSourceUpdated(T dataSource);
    }
}