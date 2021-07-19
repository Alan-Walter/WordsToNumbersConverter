namespace WordsToNumbersConverter.Core.ParseStates
{
    internal class WordState : ParseState
    {
        public WordState(int startIndex) : base(startIndex)
        {
        }

        public override void Handle(StringParser parser, int index)
        {
            var isLast = index == parser.Value.Length;
            var isNotWord = !isLast && !char.IsLetter(parser.Value[index]);
            var isPunctuation = !isLast && char.IsPunctuation(parser.Value[index]);

            if (isLast || isPunctuation || isNotWord)
            {
                parser.AddToResult(new StringPart
                {
                    PartType = Enums.PartType.Word,
                    Value = parser.Value.Substring(_startIndex, index - _startIndex)
                });
            }

            if (isPunctuation)
            {
                parser.TransitTo(new PunctuationState(index));
            }
            else if (isNotWord)
            {
                parser.TransitTo(new CharSetState(index));
            }
        }
    }
}