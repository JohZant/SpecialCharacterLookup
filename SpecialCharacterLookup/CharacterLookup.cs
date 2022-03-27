namespace SpecialCharacterLookup
{
    public class CharacterLookup
    {
        private static bool[] _sharedLookup;
        private bool[] _lookup;

        static CharacterLookup()
        {
            if (_sharedLookup == null)
            {
                _sharedLookup = new bool[65536];
            }
        }

        /// <summary>
        /// Initialise an instance of <see cref="CharacterLookup"/>
        /// </summary>
        /// <param name="useSharedLookup">Use a shared </param>
        public CharacterLookup(bool useSharedLookup = true)
        {
            // Set the shared property
            this.Shared = useSharedLookup;

            if (this.Shared == false)
            {
                this._lookup = new bool[65536];
            }
        }
        
        public static bool[] Value => _sharedLookup;

        /// <summary>
        /// If true, the charactor lookup will share the values with all other instances of <see cref="CharacterLookup"/> marked as shared.
        /// If false, any values changed will not be reflected in any other instance
        /// </summary>
        public bool Shared { get; private set; }

        public bool[] Value
        {
            get
            {
                if (this.Shared)
                {
                    return _sharedLookup;
                }
                else
                {
                    return _lookup;
                }
            }
        }
        /// <summary>
        /// Registers all characters
        /// </summary>
        /// <param name="value">The value that all characters in the lookup will be set to</param>
        public void RegisterAll(bool value = true)
        {
            for (int i = 0; i < _sharedLookup.Length; i++)
            {
                _sharedLookup[i] = value;
            }
        }

        /// <summary>
        /// Registers all lowercase characters in the English Alphabet. i.e. a, b, c, etc.
        /// </summary>
        /// <param name="value">The value returned by the lookup for the uppercase English Alphabet</param>
        public void RegisterAlphabetLowercase(bool value = true)
        {
            for (char c = 'a'; c <= 'z'; c++) _sharedLookup[c] = value;
        }

        /// <summary>
        /// Registers all uppercase characters in the English Alphabet. i.e. A, B, C, etc.
        /// </summary>
        /// <param name="value">The value returned by the lookup for the uppercase English Alphabet</param>
        public void RegisterAlphabetUppercase(bool value = true)
        {
            for (char c = 'A'; c <= 'Z'; c++) _sharedLookup[c] = value;
        }

        /// <summary>
        /// Registers a character value in the lookup
        /// </summary>
        /// <param name="character">The character in the lookup</param>
        /// <param name="value">The value returned by the lookup for the specified character</param>
        public void RegisterCharacter(char character, bool value = true)
        {
            _sharedLookup[character] = value;
        }

        /// <summary>
        /// Registers all simple numeric characters. i.e. 0, 1, 2, ..., 8, 9.
        /// </summary>
        /// <param name="value">The value returned by the lookup for the uppercase English Alphabet</param>
        public void RegisterNumeric(bool value = true)
        {
            for (char c = '0'; c <= '9'; c++) _sharedLookup[c] = value;
        }

        private bool[] GetLookup()
        {
            if (_sharedLookup == null)
            {
                _sharedLookup = new bool[65536];
            }

            return _sharedLookup;
        }
    }
}
