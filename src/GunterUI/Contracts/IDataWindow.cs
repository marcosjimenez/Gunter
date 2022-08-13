namespace Contracts
{
    internal interface IDataWindow
    {
        bool SetExtraData(object data);
        Form Form { get; }

    }
}
