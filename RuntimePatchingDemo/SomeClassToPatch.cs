namespace RuntimePatchingDemo;

public class SomeClassToPatch
{
    public bool isRunning;
    public int counter;

    public int Count()
    {
        if (isRunning)
        {
            counter++;
            Console.WriteLine($"patchee: it is running, incremented counter by one to {counter}");
        }
        else
        {
            Console.WriteLine($"patchee: It is not running");
        }
        
        return counter * 10;
    }
}