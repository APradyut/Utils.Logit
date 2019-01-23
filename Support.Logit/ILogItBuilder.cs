using System.Text;

namespace Support.Logit
{
	public interface ILogItBuilder
	{
		ILogItBuilder WithEncoding(Encoding encoding);
		ILogItBuilder WithDestinationCSV();
		ILogItBuilder WithDestinationTXT();
		ILogItBuilder WithLoggingFile(string Filename);
		LogIt Build();
	}
}