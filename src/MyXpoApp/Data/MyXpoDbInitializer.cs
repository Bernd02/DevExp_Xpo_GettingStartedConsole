using DevExpress.Xpo;
using DevExpress.Xpo.DB;
using System.Reflection;

namespace MyXpoApp.Data;

internal static class MyXpoDbInitializer
{
	public static void InitDb()
	{
		//string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

		var executingAssemblyDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).DirectoryName!;
		var appDataPath = Path.Combine(executingAssemblyDirectory, "SqliteDb");

		if (!Directory.Exists(appDataPath))
		{
			Directory.CreateDirectory(appDataPath);
		}

		string connectionString = SQLiteConnectionProvider.GetConnectionString(Path.Combine(appDataPath, "myXpoApp.db"));
		XpoDefault.DataLayer = XpoDefault.GetDataLayer(connectionString, AutoCreateOption.DatabaseAndSchema);

	}
}
