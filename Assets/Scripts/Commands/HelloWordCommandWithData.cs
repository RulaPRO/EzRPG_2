using Core.CommandRunner.Interfaces.Command;
using UnityEngine;

namespace Commands
{
    public class HelloWordCommandWithData : ICommandWithData<HelloWordData>
    {
        public void Execute(HelloWordData commandData)
        {
            Debug.LogError($"[HelloWordCommandWithData Execute] {commandData.Message}");
        }
    }
}