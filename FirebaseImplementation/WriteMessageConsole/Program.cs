using WriteMessageConsole.Service;

namespace WriteMessageConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteFromConsoleService controller = new WriteFromConsoleService();
            controller.WriteToUsers().Wait();
        }
    }
}
