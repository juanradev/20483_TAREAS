using System;

namespace _173
{


    public interface Ifile {
        void Open();
    }
    public interface IdBConnection {
        void Open();
    }

    public class UserResources : Ifile, IdBConnection
    {
        void Ifile.Open() {
            Console.WriteLine ("has llamado al metodo Ifile.Open");
        }
       void IdBConnection.Open() {
            Console.WriteLine ("has llamado al metodo IdBConnection.Open");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
           var manager = new UserResources();
           ((Ifile) manager).Open();
           ((IdBConnection) manager).Open();

        }
    }
}
