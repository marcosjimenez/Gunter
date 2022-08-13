namespace Gunter.Commands
{
    internal interface IExecutableCommand
    {
        string CommandName { get; }

        bool IsAsync { get; }

        bool IsRunning { get; }

        void Execute();
    }
}
