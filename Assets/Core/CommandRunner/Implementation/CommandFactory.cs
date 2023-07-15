using System;
using System.Collections.Generic;
using Core.CommandRunner.Interfaces;
using Core.CommandRunner.Interfaces.Command;
using VContainer;

namespace Core.CommandRunner.Implementation
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IObjectResolver diContainer;
        private readonly Dictionary<Type, ICommandEntity> commandsCache = new();

        public CommandFactory(IObjectResolver diContainer)
        {
            this.diContainer = diContainer;
        }

        public T GetCommand<T>()
            where T : class, ICommandEntity, new()
        {
            var commandType = typeof(T);
            if (commandsCache.TryGetValue(commandType, out var command))
            {
                return command as T;
            }

            return InjectCommandAndAddToCache(new T());
        }

        private T InjectCommandAndAddToCache<T>(T command)
            where T : class, ICommandEntity
        {
            diContainer.Inject(command);
            commandsCache.Add(command.GetType(), command);
            return command;
        }
    }
}