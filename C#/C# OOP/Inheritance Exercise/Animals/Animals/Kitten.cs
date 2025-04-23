namespace Animals.Animals
{
    public class Kitten : Cat
    {
        private const string KittenDefautGender = "Female";

        public Kitten(string name, int age, string gender) 
            : base(name, age, KittenDefautGender)
        {

        }

        //public override string Gender 
        //{ 
        //    get => base.Gender; 
        //    protected set
        //    {
        //        if (base.Gender != KittenDefautGender)
        //        {
        //            base.Gender = KittenDefautGender;
        //        }
        //    } 
        //}

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
