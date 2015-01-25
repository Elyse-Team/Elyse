using System;
using System.Collections.Generic;

namespace Elyse.Languagetool
{
	public class Error
	{
        public int fromx { get; private set; }
        public int fromy { get; private set; }
        public int toy { get; private set; }
        public int tox { get; private set; }
        public string ruleID { get; private set; }
        public string msg { get; private set; }
        public string[] replacements { get; private set; }
        public string context { get; private set; }
        public int contextOffset { get; private set; }
        public int offset { get; private set; }
        public string category { get; private set; }
        public string locqualityissuetype { get; private set; }

		public Error (int fromx = 0, int fromy = 0, int toy = 0, int tox = 0, string ruleID ="", 
            string msg = "", string replacements = "", string context = "", int contextOffset = 0,
            int offset = 0, string category = "", string locqualityissuetype = "")
		{
            this.fromx = fromx;
            this.fromy = fromy;
            this.toy = toy;
            this.tox = tox;
            this.ruleID = ruleID;
            this.msg = msg;
            this.replacements = replacements.Split(new Char[] { '#' });
            this.context = context;
            this.contextOffset = contextOffset;
            this.offset = offset;
            this.category = category;
            this.locqualityissuetype = locqualityissuetype;
		}
	}
}

