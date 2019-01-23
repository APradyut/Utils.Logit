using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Support.Logit
{
	public sealed partial class LogIt
	{
		/// <summary>
		/// This function takes in the Exception object and logs it into the file. It returns a number which could be used to refer the error in future.
		/// </summary>
		/// <param name="e">Exception occured</param>
		/// <returns>Unique number for future reference</returns>
		public async Task<string> LogExceptionAsync(Exception e)
		{
			string data = "";
			string Key = DateTime.Now.ToFileTime().ToString().Substring(0, 9);
			if (_isTXT)
			{
				data = "############################################################################\n"
					+ "Date Time: " + DateTime.Now + "\n"
					+ "Error number: " + Key + "\n"
					+ "Error occured in: " + e.StackTrace + "\n"
					+ "Error Message: " + e.Message + "\n"
					+ "Error Inner Message: " + e.InnerException + "\n";
			}
			else
			{
				data = DateTime.Now + ","
					+ Key + ","
					+ e.StackTrace + ","
					+ e.Message + ","
					+ e.InnerException + "\n";
			}
			await WriteAsync(data);
			return Key;
		}

		/// <summary>
		/// This function takes in the message as a string and logs it into the file.
		/// </summary>
		/// <param name="Message">Message to be logged</param>
		public async void LogInfoAsync(string Message)
		{
			string data = "";
			if (_isCSV)
				data = ",Log,," + Message + "\n";
			else data = "############################################################################\n"
					+ "Log: " + Message + "\n";
			await WriteAsync(data);
		}
	}
}

