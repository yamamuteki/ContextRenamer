namespace ContextRenamer
{
    using ContextRenamer.Service;

    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                return;
            }

            string option = args[0];
            string path = args[1];

            new OptionService().Dispatch(option, path);
        }
    }
}