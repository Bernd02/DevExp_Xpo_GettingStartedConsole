using DevExpress.Xpo;
using Microsoft.Extensions.DependencyInjection;
using MyXpoApp;
using MyXpoApp.Data;


MyXpoDbInitializer.InitDb();

var doExit = false;
do
{
	RunTest();

	Console.WriteLine("Run again? [ Y | n ]: ");

} while (Console.ReadLine()?.ToLower() != "n");


// --------------------------------------------------
void RunTest()
{
	var sp = App.Instance.ServiceProvider;
	var unitOfWork = sp.GetRequiredService<UnitOfWork>();

	// --------------------------------------------------
	// Create data
	Console.WriteLine("Type some text to create a new 'StatisticInfo' record.");
	var userInputInfo = Console.ReadLine()!;
	var newStatisticInfo = new StatisticInfoDbR(unitOfWork);
	newStatisticInfo.Info = userInputInfo;
	newStatisticInfo.Date = DateTime.Now;
	unitOfWork.CommitChanges();

	// --------------------------------------------------
	// Read data
	Console.WriteLine("Your text is saved. The 'StatisticInfo' table now contains the following records:");
	var query = unitOfWork
		.Query<StatisticInfoDbR>()
		.OrderBy(statInfo => statInfo.Date);

	foreach (var statInfo in query)
	{
		Console.WriteLine($"[{statInfo.Date.ToShortDateString()}] {statInfo.Info}");
	}

	// --------------------------------------------------
	// Delete data
	var itemsToDelte = unitOfWork
		.Query<StatisticInfoDbR>()
		.ToList() ?? new List<StatisticInfoDbR>();

	Console.WriteLine($"Record count is {itemsToDelte.Count}. Delete all records? [ y | N ]: ");
	if (Console.ReadLine()?.ToLower() == "y")
	{
		unitOfWork.Delete(itemsToDelte);
		unitOfWork.CommitChanges();

		Console.WriteLine($"Deleted {itemsToDelte.Count} items.");
		Console.WriteLine();
	}
}
