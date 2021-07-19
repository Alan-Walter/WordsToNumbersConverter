using System.Collections.Generic;

using WordsToNumbersConverter.Core.ParseStates;

namespace WordsToNumbersConverter.Core
{
    internal class StringParser
    {
        private readonly string _value;
        private IParseState _parseState;
        private readonly List<StringPart> _parseResult;

        internal string Value => _value;

        internal void AddToResult(StringPart stringPart)
        {
            _parseResult.Add(stringPart);
        }

        internal void TransitTo(IParseState parseState)
        {
            _parseState = parseState;
        }

        public StringParser(string value)
        {
            _value = value;
            _parseState = new CharSetState(0);
            _parseResult = new List<StringPart>();
        }

        public IReadOnlyCollection<StringPart> Parse()
        {
            for (var i = 0; i <= _value.Length; ++i)
            {
                _parseState.Handle(this, i);
            }

            return _parseResult;
        }
    }
}
