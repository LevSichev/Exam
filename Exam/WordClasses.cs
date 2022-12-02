using Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
-WordRus(WordEng)
--Хранит русское(английское) слово
--единственное поле - string, в котором точно лежит русское (английское) слово
--проверка на этапе конструктора
---если все символы русские, значит русское (если все английские - английское)
*/

namespace Exam
{
    internal class WordRus
    {
        private string word { get; set; }

        WordRus(string inputword)
        {
            //if inputword is rus
            word = inputword;
            //else throw a fucking exception i guess
        }
        void SetWord(string inputword)
        {
            //if inputword is rus
            word = inputword;
            //else throw a fucking exception i guess
        }
        public override string ToString()
        {
            return word;
        }
    }
    internal class WordEng
    {
        private string word { get; set; }

        WordEng(string inputword)
        {
            //if inputword is eng
            word = inputword;
            //else throw a fucking exception i guess
        }
        void SetWord(string inputword)
        {
            //if inputword is eng
            word = inputword;
            //else throw a fucking exception i guess
        }
        public override string ToString()
        {
            return word;
        }
    }
}
