using System;

internal class Task1
{
    public class Dispatcher
    {
        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnNameChange(new NameChangeEventArgs(name));
            }
        }

        public event NameChangeEventHandler? NameChange;

        public void OnNameChange(NameChangeEventArgs args)
        {
            NameChange?.Invoke(this, args);
        }
    }

    class Handler
    {
        public void OnDispatcherNameChange(object sender, NameChangeEventArgs args)
        {
            Console.WriteLine($"Dispatcher’s name changed to {args.Name}");
        }
    }

    public class NameChangeEventArgs : EventArgs
    {
        public string Name { get; private set; }

        public NameChangeEventArgs(string name)
        {
            Name = name;
        }
    }

    public delegate void NameChangeEventHandler(object sender, NameChangeEventArgs args);
    static void Main()
    {
        Dispatcher dispatcher = new Dispatcher();
        Handler handler = new Handler();

        dispatcher.NameChange += handler.OnDispatcherNameChange;

        while (true)
        {
            string temp = Console.ReadLine();

            if (temp == "End" || temp == "END")
            {
                break;
            }
            else
            {
                dispatcher.Name = temp;
            }
        }
    }
}