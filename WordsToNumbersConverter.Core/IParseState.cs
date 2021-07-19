using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsToNumbersConverter.Core
{
    internal interface IParseState
    {

        void Handle(StringParser parser, int index);
    }
}
