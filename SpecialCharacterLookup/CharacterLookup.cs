namespace SpecialCharacterLookup
{
    public class CharacterLookup
    {
        private static bool[] _lookup;

        public static bool[] Value = GetLookup();

        private static bool[] GetLookup()
        {
            if (_lookup == null)
            {
                _lookup = new bool[65536];
            }

            return _lookup;
        }

        public CharacterLookup()
        {
            if (_lookup == null)
            {
                _lookup = new bool[65536];
            }
        }

        /// <summary>
        /// Registers a character value in the lookup
        /// </summary>
        /// <param name="character">The character in the lookup</param>
        /// <param name="value">The value returned by the lookup for the specified character</param>
        public void RegisterCharacter(char character, bool value = true)
        {
            _lookup[character] = value;
        }

        /// <summary>
        /// Registers all uppercase characters in the English Alphabet. i.e. A, B, C, etc.
        /// </summary>
        /// <param name="value">The value returned by the lookup for the uppercase English Alphabet</param>
        public void RegisterAlphabetUppercase(bool value = true)
        {
            for (char c = 'A'; c <= 'Z'; c++) _lookup[c] = value;
        }

        /// <summary>
        /// Registers all lowercase characters in the English Alphabet. i.e. a, b, c, etc.
        /// </summary>
        /// <param name="value">The value returned by the lookup for the uppercase English Alphabet</param>
        public void RegisterAlphabetLowercase(bool value = true)
        {
            for (char c = 'a'; c <= 'z'; c++) _lookup[c] = value;
        }

        /// <summary>
        /// Registers all simple numeric characters. i.e. 0, 1, 2, ..., 8, 9.
        /// </summary>
        /// <param name="value">The value returned by the lookup for the uppercase English Alphabet</param>
        public void RegisterNumeric(bool value = true)
        {
            for (char c = '0'; c <= '9'; c++) _lookup[c] = value;
        }

        /// <summary>
        /// Registers all characters
        /// </summary>
        /// <param name="value">The value that all characters in the lookup will be set to</param>
        public void RegisterAll(bool value = true)
        {
            for (int i = 0; i < _lookup.Length; i++)
            {
                _lookup[i] = value;
            }
        }
    }
}
