namespace RuntimePatchingDemo;

public class SomeClassToPatch
{
    private int counter;
    private bool isRunning;

    public int Count()
    {
        if (isRunning)
        {
            counter++;
            Console.WriteLine($"patchee: it is running, incremented counter by one to {counter}");
        }
        else
        {
            Console.WriteLine("patchee: it is not running");
        }

        return counter * 10;
    }
}