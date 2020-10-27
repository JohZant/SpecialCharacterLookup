
# SpecialCharacterLookup

![Nuget](https://img.shields.io/nuget/v/SpecialCharacterLookup)

Very simple class that can assist with checking strings for characters registered as unsafe.

### Usage

Initialise a `CharacterLookup` class and then register the characters that you want to be able to test against.

    CharacterLookup characterLookup = new CharacterLookup;
    characterLookup.RegisterAlphabetLowercase();
    characterLookup.RegisterNumeric();
Then test characters against the class by using the static `Value` property.

    CharacterLookup.Value['c'];// will return true

### Extensions
The `SpecialCharacterLookup.Extensions` namespace contains some extensions that can test strings against the lookup and even clean out characters that have not been registered as `true`.

### Use case
This class was created to allow me to register characters as *safe* from one application and have another class test against the lookup. I just got sick of finding a new character that should be *safe* and having to add it into a class library, recompile and update my application with the library.
