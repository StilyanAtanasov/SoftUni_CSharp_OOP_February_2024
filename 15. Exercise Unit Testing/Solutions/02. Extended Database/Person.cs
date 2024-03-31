// ReSharper disable all -- This skeleton is provided by the task and should not be changed!

namespace ExtendedDatabase
{
    public class Person
    {
        private long id;
        private string userName = null!;

        public Person(long id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }

        public string UserName
        {
            get { return userName; }
            private set { userName = value; }
        }

        public long Id
        {
            get { return id; }
            private set { id = value; }
        }
    }
}