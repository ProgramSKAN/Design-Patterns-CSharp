using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Business.Commands
{
    //this stores list of commands that are previously executed in a stack
    //also checks if command can be executed
    public class CommandManager
    {
        private Stack<ICommand> commands = new Stack<ICommand>();//why stack? to properly undo commands

        public void Invoke(ICommand command)
        {
            if (command.CanExecute())
            {
                commands.Push(command);
                command.Execute();
            }
        }

        public void Undo()
        {
            while (commands.Count > 0)
            {
                var command = commands.Pop();
                command.Undo();
            }
        }
    }
}
