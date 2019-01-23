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
		private bool _isCSV = false;
		private bool _isTXT = true;
		private string _filePath;
		private Encoding _useEncoding;
		private async void WriteInit()
		{
			string data = "";
			if (_isCSV)
			{
				data = "Logging File," + DateTime.Now + "\n\n";
				data = "Date Time, Error number, Error StackTrace, Error/Info Message, Error Inner Message\n";
			}
			if (_isTXT)
			{
				data = "Logging file created on " + DateTime.Now + "\n\n\n";
			}
			await WriteAsync(data);
		}

		private async Task<int> WriteAsync(string Data)
		{
			////Initial creation
			if (!File.Exists(_filePath))
			{
				var file = File.Create(_filePath);
				file.Close();
				//Writing Initial content
				WriteInit();
			}
			//Writing data to file
			byte[] encodedText = Encoding.Unicode.GetBytes(Data);
			using (FileStream sourceStream = new FileStream(_filePath,FileMode.Append, FileAccess.Write, FileShare.None,bufferSize: 4096, useAsync: true))
			{
				await sourceStream.WriteAsync(encodedText, 0, encodedText.Length);
			};
			return 0;
		}
	}
}
