using System.Collections.Generic;

namespace Random.Logic
{
    public class RansomNotes
    {
        private readonly Dictionary<char, int> _characterCountsDictionary = new Dictionary<char, int>();

        private void GenerateCharacterDictionary(string input)
        {
            foreach (char character in input)
            {
                if (_characterCountsDictionary.ContainsKey(character))
                {
                    _characterCountsDictionary[character]++;
                }
                else
                {
                    _characterCountsDictionary[character] = 1;
                }
            }
        }

        public bool CanConstruct(string ransomNotes, string magazine)
        {
            GenerateCharacterDictionary(magazine);

            foreach (var character in ransomNotes)
            {
                if (_characterCountsDictionary.ContainsKey(character))
                {
                    if (_characterCountsDictionary[character] > 0)
                    {
                        _characterCountsDictionary[character]--;
                        continue;
                    }

                    return false;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}