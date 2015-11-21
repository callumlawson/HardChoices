using System;

namespace Assets.Scripts.Util
{
    public class BaseObject
    {
        public Guid Guid { get; set; }

        protected BaseObject()
        {
            Guid = Guid.NewGuid();
        }
    }
}
