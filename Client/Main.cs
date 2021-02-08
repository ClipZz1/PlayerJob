using System;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace Client
{
    public class Main : BaseScript
    {
        public Main()
        {
            //Event handler for "OnClientResourceStart"
            EventHandlers["onClientResourceStart"] += new Action<string>(OnClientResourceStart);
        }

        private void OnClientResourceStart(string resourceName)
        {
            if (GetCurrentResourceName() != resourceName) return;

            //It will output this through the F8 key
            Debug.WriteLine($"The resource {resourceName} has been started on the client.");
        }
    }
}
