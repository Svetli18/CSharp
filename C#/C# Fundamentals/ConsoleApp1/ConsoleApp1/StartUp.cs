public class StartUp
{
    private static void Main(string[] args)
    {
        //CircularQueue<int> ints = new CircularQueue<int>();

        //ints.Enqueue(1);
        //ints.Enqueue(2);
        //ints.Enqueue(3);
        //ints.Enqueue(4);
        //ints.Enqueue(5);

        SortedSet<bool> set = new SortedSet<bool>();

        set.Add(true);
        set.Add(false);

        Console.WriteLine(string.Join(Environment.NewLine, set));
    }
}