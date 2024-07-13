namespace Test_task.SignalR
{
    public interface IComHub
    {
        Task RecieveMessage(string message);
    }

}
