﻿using PlasticSearch.Models.search;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PlasticSearch.Models.tokenizer
{
    class ExactSearchTokenizer : Tokenizer
    {
        private const string EXACT_TEABLE_NAME = "dbo.Exact";

        public override ISet<string> TokenizeQuery(string text) => Regex.Split(text, SPLITTER).ToHashSet();

        public override List<string> Develope(string token) => new string[] { token }.ToList();

        public override void TokenizeData(string filePath, string text)
        {
            Regex.Split(text, SPLITTER).ToList().ForEach(token =>
            {
                DatabaseController.Instance.AddDataToken(token, filePath, EXACT_TEABLE_NAME);

            });
        }
    }
}