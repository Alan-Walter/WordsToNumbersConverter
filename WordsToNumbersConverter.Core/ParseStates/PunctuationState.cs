namespace WordsToNumbersConverter.Core.ParseStates
{
    internal class PunctuationState : ParseState
    {
        public PunctuationState(int startIndex) : base(startIndex)
        {
        }

        public override void Handle(StringParser parser, int index)
        {
            var isLast = index == parser.Value.Length;
            var isLetter = !isLast && char.IsLetter(parser.Value[index]);
            var isNotPunctuation = !isLast && !char.IsPunctuation(parser.Value[index]);

            if (isLast || isLetter || isNotPunctuation)
            {
                parser.AddToResult(new StringPart
                {
                    PartType = Enums.PartType.Punctuation,
                    Value = parser.Value.Substring(_startIndex, index - _startIndex)
                });
            }

            if (isLetter)
            {
                parser.TransitTo(new WordState(index));
            }
            else if (isNotPunctuation)
            {
                parser.TransitTo(new CharSetState(index));
            }
        }
    }
}