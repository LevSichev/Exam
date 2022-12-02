using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

/*
Классы:
-BetterDictionary
--В конструкторе передавать тип(рус-англ, англо-рус и тд)???
--Сериализуемый
--У одного слова несколько переводов -> у одного ключа несколько значений 
---Dictionary<WordEng, List<WordRus>>
--Метод, который принимает KeyValuePair и записывает его в файл
--2 отдельных класса под рус-англ и англ-рус


-WordRus (WordEng)
--Хранит русское (английское) слово
--единственное поле - string, в котором точно лежит русское (английское) слово
--проверка на этапе конструктора
---если все символы русские, значит русское (если все английские - английское) 
*/

namespace Exam
{
    internal class BetterDictionaryEngToRus
    {
        private Dictionary<WordEng, List<WordRus>> Dictionary { get; set; }

        public BetterDictionaryEngToRus(bool rusToEng = false)
        {
            Dictionary = new Dictionary<WordEng, List<WordRus>>();
        }

        public void Translate(WordEng word)
        {
            List<WordRus> translations = new List<WordRus>();
            Dictionary.TryGetValue(word, out translations);
            translations.ForEach(s => Console.WriteLine(s));
        }

        public void AddWord(WordEng word, List<WordRus> translations)
        {
            Dictionary.Add(word, translations);
        }

        public void RemoveWord(WordEng word)
        {
            Dictionary.Remove(word);
        }

        public void ReplaceWord(WordEng toReplace, WordEng replacement)
        {
            List<WordRus> tmp;
            Dictionary.TryGetValue(toReplace, out tmp);

            RemoveWord(toReplace);
            AddWord(replacement, tmp);
        }

        public void RemoveTranslation(WordRus translation)
        {
            List<WordRus> tmp;
            WordEng tmpkey = GetWordByTranslation(translation);
            Dictionary.TryGetValue(GetWordByTranslation(translation), out tmp);
            if (tmp.Count > 1)
            {
                tmp.Remove(translation);
            }
            RemoveWord(tmpkey);
            AddWord(tmpkey, tmp);
        }

        public void ReplaceTranslation(WordRus toReplace, WordRus replacement)
        {
            //List<WordRus> tmp;
            //Dictionary.TryGetValue(GetWordByTranslation(toReplace), out tmp);
        }

        public WordEng GetWordByTranslation(WordRus translation)
        {
            return Dictionary.First(word => word.Value.Contains(translation)).Key;
        }
    }
}
