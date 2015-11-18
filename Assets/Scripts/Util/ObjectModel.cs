using System;

namespace Assets.Scripts.Util
{
    public abstract class ObjectModel
    {
        public Guid Guid;

        protected ObjectModel ()
        {
            Guid = Guid.NewGuid();
        }
    }
}
