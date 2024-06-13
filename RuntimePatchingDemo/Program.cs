using RuntimePatchingDemo;

var patchee = new SomeClassToPatch();

var isPatched = false;

while (true)
{
    Console.WriteLine();
    if (!isPatched)
    {
        Console.WriteLine("Should the patch be applied now? (y)");
        isPatched = Console.ReadKey().KeyChar == 'y';
        if (isPatched)
        {
            MyPatcher.DoPatching();
            Console.WriteLine("Patch applied");
        }
    }

    var count = patchee.Count();
    await Task.Delay(100);
    Console.WriteLine($"resulting counter: {count}");
}