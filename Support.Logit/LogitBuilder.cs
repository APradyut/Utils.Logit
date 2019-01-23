using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support.Logit
{
	public class LogItBuilder : ILogItBuilder
	{
		private Encoding _useEncoding;
		private bool _isTXT;
		private bool _isCSV;
		private string _filePath;

		public LogItBuilder()
		{
			_isTXT = true;
			_isCSV = false;
			_useEncoding = Encoding.UTF8;
			_filePath = "Logs.txt";
		}

		public ILogItBuilder WithEncoding(Encoding encoding)
		{
			_useEncoding = encoding;
			return this;
		}
		public ILogItBuilder WithDestinationCSV()
		{
			_isTXT = false;
			_isCSV = true;
			return this;
		}
		public ILogItBuilder WithDestinationTXT()
		{
			_isTXT = true;
			_isCSV = false;
			return this;
		}
		public ILogItBuilder WithLoggingFile(string Filename)
		{
			//Getting the filename and removing the already existing extensions
			int End = Filename.LastIndexOf('.');
			_filePath = Filename.Substring(0, End);
			return this;
		}
		public LogIt Build()
		{
			return new LogIt(_isCSV, _isTXT, _filePath, _useEncoding);
		}

		public static ILogItBuilder CreateNew()
		{
			return new LogItBuilder();
		}
	}
}