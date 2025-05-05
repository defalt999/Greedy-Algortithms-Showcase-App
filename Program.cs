using Spectre.Console;
using Spectre.Console.Cli;

namespace DijkstraPath
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                AnsiConsole.Clear();
                AnsiConsole.MarkupLine("[bold yellow]**************************************[/]");
                AnsiConsole.MarkupLine("[bold yellow]***** Greedy Algorithms Showcase *****[/]");
                AnsiConsole.MarkupLine("[bold yellow]**************************************[/]");


                // Exemplu de graf reprezentat ca matrice de adiacență
                int[,] graf = new int[5, 5]
                {
                    { 0, 2, 5, 0, 0 },//Nod 0
                    { 2, 0, 0, 3, 0 },
                    { 5, 0, 0, 2, 3 },
                    { 0, 3, 2, 0, 4 },
                    { 0, 0, 3, 4, 0 }
                };

                List<(int from, int to, int cost)> graph = new();
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (graf[i, j] > 0)
                        {
                            graph.Add((i, j, graf[i, j]));
                        }

                    }
                }

                var grafic = new Table();
                grafic.AddColumn("From");
                grafic.AddColumn("To");
                grafic.AddColumn("Cost");
                foreach (var edge in graph)
                {
                    grafic.AddRow(edge.from.ToString(), edge.to.ToString(), edge.cost.ToString());
                }
                AnsiConsole.Render(grafic);



                var operation = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .Title("What Algorithm would you like to run")
                    .PageSize(10)
                    .AddChoices("Dijkstra", "Kruskal", "Prim")

                    );

                if (operation == "Dijkstra")
                {
                    var startNode = AnsiConsole.Ask<int>("[red]Choose starting node![/]");

                    AnsiConsole.Progress()
                        .Start(ctx =>
                        {
                            var task = ctx.AddTask("[red]Calculating path[/]");

                            while (!ctx.IsFinished)
                            {
                                Thread.Sleep(100);
                                task.Increment(10);
                            }
                        });


                    int[] distante = Dijkstra.dijkstra(graf, startNode);

                    var table = new Table();
                    table.AddColumn("Node");
                    table.AddColumn("Distance");
                    for (int i = 0; i < distante.Length; i++)
                    {
                        table.AddRow(i.ToString(), distante[i].ToString());
                    }

                    AnsiConsole.Render(table);


                }
                if (operation == "Kruskal")
                {
                    AnsiConsole.Progress()
                        .Start(ctx =>
                        {
                            var task = ctx.AddTask("[red]Calculating MST[/]");
                            while (!ctx.IsFinished)
                            {
                                Thread.Sleep(100);
                                task.Increment(10);
                            }
                        });

                    List<(int from, int to, int cost)> mst = Kruskal.kruskal(graf);
                    var table = new Table();
                    table.AddColumn("From");
                    table.AddColumn("To");
                    table.AddColumn("Cost");
                    foreach (var edge in mst)
                    {
                        table.AddRow(edge.from.ToString(), edge.to.ToString(), edge.cost.ToString());
                    }
                    AnsiConsole.Render(table);

                }
                if(operation== "Prim")
                {
                    var startNode = AnsiConsole.Ask<int>("[red]Choose starting node![/]");
                    AnsiConsole.Progress()
                        .Start(ctx =>
                        {
                            var task = ctx.AddTask("[red]Calculating MST[/]");
                            while (!ctx.IsFinished)
                            {
                                Thread.Sleep(100);
                                task.Increment(10);
                            }
                        });
                    List<(int from, int to, int cost)> mst = Prim.prim(graf, startNode);
                    var table = new Table();
                    table.AddColumn("From");
                    table.AddColumn("To");
                    table.AddColumn("Cost");
                    foreach (var edge in mst)
                    {
                        table.AddRow(edge.from.ToString(), edge.to.ToString(), edge.cost.ToString());
                    }
                    AnsiConsole.Render(table);
                }

                AnsiConsole.Prompt(
                    new TextPrompt<string>("[green]Press any key to continue...[/]")
                    );
            }
        }
    }

}