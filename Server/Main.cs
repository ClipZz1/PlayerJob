using System;
using System.Collections.Generic;
using CitizenFX.Core;
using static CitizenFX.Core.Native.API;

namespace Server
{
    public class Main : BaseScript
    {
        //using the dynamic "ESX"
        dynamic ESX;
        public Main()
        {
            TriggerEvent("esx:getSharedObject", new object[] { new Action<dynamic>(esx => {
            ESX = esx;
        })});

            //Registering "job" in main constructor so we don't have to put it in another void
            RegisterCommand("job", new Action<int, List<object>, string>((source, args, raw) =>
            {
                //Using var for variables
                var xPlayer = ESX.GetPlayerFromId(source);
                var Job = xPlayer.getJob();

                //Triggering the "chat:addMessage" event to output your job and salary
                xPlayer.triggerEvent("chat:addMessage", new
                {
                    //color black
                    color = new[] {0, 0, 0},
                    args = new[] {"[Job]", $"Your current job is {Job.name}, your earnings are {Job.grade_salary}"}
                });

            }), false);
        }
    }
}
