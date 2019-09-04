using System;

namespace ApiAkkaDepencyInjection.Domain
{
    public sealed class Draw
    {
        public string Code { get; private set; }

        public DateTime Date { get; private set; }
        public short FirstNumber { get; private set; }
        public short SecondNumber { get; private set; }
        public short ThirdNumber { get; private set; }
        public short FourthNumber { get; private set; }

        public Draw(string code, DateTime date, short firstNumber, short secondNumber, short thirdNumber, short fourthNumber)
        {
            Code = code;
            Date = date;
            FirstNumber = firstNumber;
            SecondNumber = secondNumber;
            ThirdNumber = thirdNumber;
            FourthNumber = fourthNumber;
        }
    }
}