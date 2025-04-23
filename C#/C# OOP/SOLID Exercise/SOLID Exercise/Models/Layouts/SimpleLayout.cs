namespace SOLID_Exercise.Models.Layouts
{
    using SOLID_Exercise.Models.Contracts;

    public class SimpleLayout : ILayout
    {
        //this format must be in that order "<date-time> - <report level> - <message>"
        public string Format => "{0} - {1} - {2}";
    }
}
