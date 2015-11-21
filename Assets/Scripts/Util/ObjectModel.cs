using System;
using DG.Tweening.Core.Enums;

namespace Assets.Scripts.Util
{
    public abstract class ObjectModel<TModel> : BaseObject, IObservable<ObjectModel<TModel>>
    {
        private int name;
        public int Name
        {
            get { return name; }
            set { name = value; Update(); }
        }

        public event Action<ObjectModel<TModel>> Updated = delegate { };

        protected void Update()
        {
            Updated(this);
        }
    }
}
