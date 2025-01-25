using DevExpress.Xpo;

namespace MyXpoApp.Data;

public class StatisticInfoDbr : XPLiteObject
{
	private Guid key;
	private string info = string.Empty;
	private DateTime date;


	public StatisticInfoDbr(Session session) : base(session) { }


	[Key(true)]
	public Guid Key
	{
		get => this.key;
		set => SetPropertyValue(nameof(this.Key), ref this.key, value);
	}

	[Size(255)]
	public string Info
	{
		get => this.info;
		set => SetPropertyValue(nameof(this.Info), ref this.info, value);
	}

	public DateTime Date
	{
		get => this.date;
		set => SetPropertyValue(nameof(this.Date), ref this.date, value);
	}
}
