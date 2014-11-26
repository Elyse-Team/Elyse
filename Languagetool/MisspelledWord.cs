using System;

namespace Elyse.Languagetool
{
	public class MisspeledWord
	{
		private string _text;
		private int[] _position; //[offset, offset+length]
		private string[] _suggest;
		private string _errorMsg;
		private string _errorType;


		public MisspeledWord ()
		{
		
		}
	}
}

