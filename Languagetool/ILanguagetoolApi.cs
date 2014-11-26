using System;
using System.Collections.Generic;

namespace Elyse.Languagetool
{
	public interface ILanguagetoolApi
	{
		List<MisspeledWord> GetMisspeledWords(string text);
	}
}

