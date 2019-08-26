using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        void Execute(TCommand command);
    }
}
