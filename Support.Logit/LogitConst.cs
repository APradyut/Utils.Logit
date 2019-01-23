using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support.Logit
{
	public sealed partial class LogIt
	{
		public LogIt(bool isCSV, bool isTXT, string filePath, Encoding useEncoding)
		{
			_isCSV = isCSV;
			_isTXT = isTXT;
			_filePath = filePath;
			_useEncoding = useEncoding;
			if (_isCSV)
			{
				_filePath += ".csv";
			}
			else if (_isTXT)
			{
				_filePath += ".txt";
			}
			//Initial creation
			if (!File.Exists(_filePath))
			{
				Console.WriteLine("File not found! Creating new file!");
				var file = File.Create(_filePath);
				file.Close();
				Console.WriteLine("File creation successful!");
				//Writing Initial content
				WriteInit();
			}
			else Console.WriteLine("File already exists!");
		}
	}
}
