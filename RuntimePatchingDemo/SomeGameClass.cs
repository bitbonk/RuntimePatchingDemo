namespace RuntimePatchingDemo;

public class SomeGameClass
{
    public bool isRunning;
    public int counter;

    public int DoSomething()
    {
        if (isRunning)
        {
            counter++;
        }
        return counter * 10;
    }
}