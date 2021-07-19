namespace WordsToNumbersConverter.Core.ParseStates
{
    internal abstract class ParseState : Core.IParseState
    {
        protected readonly int _startIndex;

        protected ParseState(int startIndex)
        {
            _startIndex = startIndex;
        }

        public abstract void Handle(StringParser parser, int index);
    }
}