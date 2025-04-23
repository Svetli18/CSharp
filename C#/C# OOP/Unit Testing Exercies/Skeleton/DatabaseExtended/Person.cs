namespace ExtendedDatabase
{
    public class Person
    {
        private long id;
        private string userName;

        //ok
        public Person(long id, string userName)
        {
            this.Id = id;
            this.UserName = userName;
        }
        //ok
        public string UserName
        {
            get { return userName; }
            private set { userName = value; }
        }
        //ok
        public long Id
        {
            get { return id; }
            private set { id = value; }
        }
    }
}
