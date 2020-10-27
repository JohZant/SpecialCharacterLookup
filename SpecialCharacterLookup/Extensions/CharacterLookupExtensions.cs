using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpecialCharacterLookup.Extensions
{
    public static class CharacterLookupExtensions
    {
        /// <summary>
        /// Checks string for any characters that are not registered with <see cref="CharacterLookup"/>
        /// </summary>
        /// <param name="lookup"></param>
        /// <param name="str">The string to check.</param>
        /// <returns>Returns true if all characters in <paramref name="str"/> are registered in the <see cref="CharacterLookup"/></returns>
        public static bool PassesCharacterCheck(this CharacterLookup lookup, string str)
        {
            foreach (var c in str)
            {
                if (!CharacterLookup.Value[c])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Checks the <paramref name="str"/> for characters that are not registered as true in the <see cref="CharacterLookup"/>
        /// </summary>
        /// <param name="lookup"></param>
        /// <param name="str">The string to check.</param>
        /// <returns>List of characters in the string that were registered as false</returns>
        public static IEnumerable<char> UnregisteredCharactersFromString(this CharacterLookup lookup, string str)
        {
            var result = new List<char>();

            foreach (var c in str)
            {
                if (!CharacterLookup.Value[c])
                {
                    result.Add(c);
                }
            }
            return result.Distinct();
        }

        /// <summary>
        /// Removes all characters marked as false from string
        /// </summary>
        /// <param name="lookup"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string CleanString(this CharacterLookup lookup, string str)
        {
            char[] buffer = new char[str.Length];
            int index = 0;
            foreach (char c in str)
            {
                if (CharacterLookup.Value[c])
                {
                    buffer[index] = c;
                    index++;
                }
            }
            return new string(buffer, 0, index);
        }
    }
}
