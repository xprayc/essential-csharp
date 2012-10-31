using System;

public class Receiver
{
    public class ReceiverEventArgs : EventArgs
    {
        private string _msg;

        public ReceiverEventArgs(string msg)
        {
            _msg = msg;
        }

        public string Message {
            get {
                return _msg;
            }

            set {
                _msg = value;
            }
        }
    }

    public event EventHandler<ReceiverEventArgs> OnReceived;

    public void Send(string msg)
    {
        if (OnReceived != null)
        {
            OnReceived(this, new ReceiverEventArgs(msg));
        }
    }
}

public class MessageHandler
{
    public MessageHandler(string name)
    {
        _name = name;
    }

    private string _name;

    public void Handle(object sender, Receiver.ReceiverEventArgs args)
    {
        System.Console.WriteLine("{0}: Received --> {1}", _name, args.Message);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Receiver receiver = new Receiver();
        MessageHandler handler = new MessageHandler("spiderman");

        receiver.OnReceived += handler.Handle;

        receiver.Send("Hello Kitty");
        receiver.Send("Hello Tiger");
    }
}
