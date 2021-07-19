namespace WordsToNumbersConverter.Core.ParseStates
{
    internal class CharSetState : ParseState
    {
        public CharSetState(int startIndex) : base(startIndex)
        {
        }

        public override void Handle(StringParser parser, int index)
        {
            var isLast = index == parser.Value.Length;
            var isLetter = !isLast && char.IsLetter(parser.Value[index]);
            var isPunctuation = !isLast && char.IsPunctuation(parser.Value[index]);

            if (isLast || isLetter || isPunctuation)
            {
                if (index - _startIndex > 0)
                {
                    parser.AddToResult(new StringPart
                    {
                        Value = parser.Value.Substring(_startIndex, index - _startIndex)
                    });
                }
            }

            if (isLetter)
            {
                parser.TransitTo(new WordState(index));
            }
            else if (isPunctuation)
            {
                parser.TransitTo(new PunctuationState(index));
            }
        }
    }
}