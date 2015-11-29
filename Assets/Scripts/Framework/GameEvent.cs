using MoonSharp.Interpreter;

namespace Assets.Scripts.Framework
{
    class GameEvent
    {
        private Script eventScript;

        public GameEvent(Script eventScript)
        {
            this.eventScript = eventScript;
        }
    }
}
