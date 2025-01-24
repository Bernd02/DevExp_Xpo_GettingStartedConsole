using DevExpress.Xpo;
using Microsoft.Extensions.DependencyInjection;

namespace MyXpoApp;

internal class App
{
	private static object instanceLock = new object();
	private static App? instance;
	public static App Instance
	{
		get
		{
			if (instance != null) return instance;
			lock (instanceLock)
			{
				if (instance == null)
				{
					instance = new App();
				}
				return instance;
			}
		}
	}


	private App()
	{
		ServiceProvider = this.BuildServiceProvider();
	}


	public IServiceProvider ServiceProvider { get; }


	private IServiceProvider BuildServiceProvider()
	{
		var serviceCollection = new ServiceCollection();

		// register myXpoDbUnitOfWork
		serviceCollection.AddScoped<UnitOfWork>();

		return serviceCollection.BuildServiceProvider();
	}
}
