using Microsoft.Extensions.Logging;
using System;
using Xunit;
using Xunit.Abstractions;

namespace SpecialCharacterLookup.Tests
{
    public class UnitTests
    {
        private readonly IServiceProvider serviceProvider;
        private readonly ITestOutputHelper outputHelper;
        private readonly CharacterLookup characterLookup;

        public UnitTests(IServiceProvider serviceProvider, ITestOutputHelper outputHelper, CharacterLookup characterLookup)
        {
            this.serviceProvider = serviceProvider;
            this.outputHelper = outputHelper;
            this.characterLookup = characterLookup;
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RegisterAll_ValueSet_AllValuesToSame(bool value)
        {
            // Set some characters to not value
            characterLookup.RegisterAlphabetLowercase(!value);

            // Set all characters to value
            characterLookup.RegisterAll(value);

            // Create tests
            var pass = true;

            foreach (var lookupVal in characterLookup.Value)
            {
                if (lookupVal != value)
                {
                    pass = false;
                    break;
                }
            }

            // Result
            Assert.True(pass);
        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RegisterAlphabetUppercase_ValueSet_Value(bool value)
        {
            // Set all characters as value
            characterLookup.RegisterAll(!value);

            // Run method that we are testing
            characterLookup.RegisterAlphabetUppercase(value);

            // Create tests
            var pass = true;

            for (char c = 'A'; c <= 'Z'; c++)
            {
                if (characterLookup.Value[c] != value)
                {
                    pass = false;
                    break;
                }
            }

            // Result
            Assert.True(pass);

        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RegisterAlphabetLowercase_ValueSet_Value(bool value)
        {
            // Set all characters as value
            characterLookup.RegisterAll(!value);

            // Run method that we are testing
            characterLookup.RegisterAlphabetLowercase(value);

            // Create tests
            var pass = true;

            for (char c = 'a'; c <= 'z'; c++)
            {
                if (characterLookup.Value[c] != value)
                {
                    pass = false;
                    break;
                }
            }

            // Result
            Assert.True(pass);

        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RegisterNumeric_ValueSet_Value(bool value)
        {
            // Set all characters as value
            characterLookup.RegisterAll(!value);

            // Run method that we are testing
            characterLookup.RegisterNumeric(value);

            // Create tests
            var pass = true;

            for (char c = '0'; c <= '9'; c++)
            {
                if (characterLookup.Value[c] != value)
                {
                    pass = false;
                    break;
                }
            }

            // Result
            Assert.True(pass);

        }

        [Theory]
        [InlineData(true)]
        [InlineData(false)]
        public void RegisterCharacter_AllCharacters_SetValue(bool value)
        {
            // Set all characters to not value
            characterLookup.RegisterAll(!value);

            // Create Tests
            var pass = true;

            for (int i = 0; i < characterLookup.Value.Length; i++)
            {
                // Set temp character
                char temp = (char)i;

                // Register character
                characterLookup.RegisterCharacter(temp, value);

                // Test
                if (characterLookup.Value[temp] != value)
                {
                    outputHelper.WriteLine($"Failed on character ({temp}). Expected: {value} - Actual: {characterLookup.Value[temp]}");
                    pass = false;
                    break;
                }
            }

            // Result
            Assert.True(pass);
        }
    }
}
