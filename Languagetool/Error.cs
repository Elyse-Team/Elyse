using System;
using System.Collections.Generic;

namespace Elyse.Languagetool
{
	public class Error
	{
        private int _fromy;
        private int _fromx;
        private int _toy;
        private int _tox;
        private string _ruleID;
        private string _msg;
        private string[] _replacements;
        private string _context;
        private int _contextOffset;
        private int _offset;
        private string _category;
        private string _locqualityissuetype;

        public int fromx { get { return _fromx; } }
        public int fromy { get { return _fromy; } }
        public int toy { get { return _toy; } }
        public string ruleID { get { return _ruleID; } }
        public string msg { get { return _msg; } }
        public string[] replacements { get { return _replacements; } }
        public string context { get { return _context; } }
        public int contextOffset { get { return _contextOffset; } }
        public int offset { get { return _offset; } }
        public string category { get { return _category; } }
        public string locqualityissuetype { get { return _locqualityissuetype; } }

		public Error (int fromx = 0, int fromy = 0, int toy = 0, int tox = 0, string ruleID ="", 
            string msg = "", string replacements = "", string context = "", int contextOffset = 0,
            int offset = 0, string category = "", string locqualityissuetype = "")
		{
            _fromx = fromx;
            _fromy = fromy;
            _toy = toy;
            _tox = tox;
            _ruleID = ruleID;
            _msg = msg;
            _replacements = replacements.Split(new Char [] {'#'});
            _context = context;
            _contextOffset = contextOffset;
            _offset = offset;
            _category = category;
            _locqualityissuetype = locqualityissuetype;
		}
	}
}

