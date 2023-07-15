using Core.CommandRunner.Interfaces.Command;
using UnityEngine;

namespace Commands
{
    public class HelloWordCommand : ICommand
    {
        public void Execute()
        {
            Debug.LogError("Hello word!!! [HelloWordCommand Execute]");
        }
    }
}