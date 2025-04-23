namespace Animals.Animals
{
    public class Tomcat : Cat
    {
        private const string TomcatDefaultGender = "Male";

        public Tomcat(string name, int age, string gender) 
            : base(name, age, TomcatDefaultGender)
        {

        }

        //public override string Gender 
        //{ 
        //    get => base.Gender; 
        //    protected set
        //    {
        //        if (base.Gender != TomcatDefaultGender)
        //        {
        //            base.Gender = TomcatDefaultGender;
        //        }
        //    } 
        //}

        public override string ProduceSound()
        {
            return "MEOW";
        }
    }
}
