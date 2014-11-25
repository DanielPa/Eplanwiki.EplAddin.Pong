using Eplan.EplApi.ApplicationFramework;

namespace Eplanwiki.EplAddin.Pong
{
    public class AddInModule : IEplAddIn 
    {
        public bool OnExit()
        {
            return true;
        }

        public bool OnInit()
        {
            return true;
        }

        public bool OnInitGui()
        {
            return true;
        }

        public bool OnRegister(ref bool bLoadOnStart)
        {
            return true;
        }

        public bool OnUnregister()
        {
            return true;
        }
    }
}
