// See https://aka.ms/new-console-template for more information

using RuntimePatchingDemo;

MyPatcher.DoPatching();

var game = new SomeGameClass();

while (true)
{
    var count = game.DoSomething();
    await Task.Delay(1000);
    Console.WriteLine($"running: {count}");
}

