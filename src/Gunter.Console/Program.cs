using CommandLine;
using Gunter.Commands;
using System.Reflection;

Console.WriteLine("Hello, World!");


var command = "";

var types = LoadVerbs();

do
{
    command = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(command))
        continue;

    var parsedArgs = command.Split(" ");

    var result = Parser.Default.ParseArguments(parsedArgs, types)
        .WithParsed<IExecutableCommand>(Run)
        .WithNotParsed(HandleErrors);

} while (command != "q");

void HandleErrors(IEnumerable<Error> errors)
{
    Console.WriteLine("ERROR");
    foreach (var error in errors)
    {
        Console.WriteLine(error);
    }
}

static void Run(IExecutableCommand obj)
{
    if (obj == null)
        return;

    ((IExecutableCommand)obj).Execute();
}

//load all types using Reflection
static Type[] LoadVerbs()
{
    return Assembly.GetExecutingAssembly().GetTypes()
        .Where(t => t.GetCustomAttribute<VerbAttribute>() != null).ToArray();
}