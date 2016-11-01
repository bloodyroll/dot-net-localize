# dot-net-localize
A simple way to localize your .net application

### Preparing
First of all you need to attach AppLocalizer.dll to your solution. Now prepare your localization data by creating resource file. At the moment this library eats XML-file "resources.xml" from main app directory (AppDomain.CurrentDomain.BaseDirectory + @"\resources.xml").
Here is small example:

```sh
<?xml version="1.0"?>
<Phrases xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema">
  <Phrases>
    <Phrase>
      <PhraseKey>1</PhraseKey>
      <Values>
        <string>eng 1</string>
        <string>rus 1</string>
        <string>ger 1</string>
      </Values>
    </Phrase>
    <Phrase>
      <PhraseKey>2</PhraseKey>
      <Values>
        <string>eng 2</string>
        <string>rus 2</string>
        <string>ger 2</string>
      </Values>
    </Phrase>
    <Phrase>
      <PhraseKey>TestLang_First</PhraseKey>
      <Values>
        <string>english enum 1</string>
        <string>russian enum 1</string>
        <string>german enum  1</string>
      </Values>
    </Phrase>
    <Phrase>
      <PhraseKey>TestLang_Second</PhraseKey>
      <Values>
        <string>english enum 2</string>
        <string>russian enum 2</string>
        <string>german enum  2</string>
      </Values>
    </Phrase>
  </Phrases>
  <Languages>
    <string>English</string>
    <string>Русский</string>
    <string>Deutsch</string>
  </Languages>
</Phrases>
```
 - 'Languages' tag contains language descriptions
 - 'Phrases' tag contains dictionary data:  'PhraseKey' is a key for phrase, 'Values' - all text values of this phrase, index is comparing with 'Languages' string data

To generate this sample use 'GenerateLocTest' console app. This .exe uses public method 'AppLocalizer.XmlRead.Serialization.SaveToXmlFile' to serialize data class with phrases

### Starting 
To read data from file use next call in your solution:
```
Translate.Initialize();
```
To change language use next:
```
Translate.SetLanguage(0);
```
A byte parameter is a number of language index in data file;

### Using

Wpf test appllication: 'WpfLocTest'

- Getting data in-code

Use next method to return localized string value with phrase key parameter:
```
var strValue = Translate.Value("TestLang_First");
```

- XAML using

Example with Textblock:
```
<TextBlock Margin="5"
           Text="{Binding Path=(appLocalizer:Translate.OneLangDictionary)[1], FallbackValue=OneLangData}" />
```

- Localize description attribute

Use custom LocalizedDescriptionAttribute:
```
 public enum TestLangEnum
    {
        [LocalizedDescription("TestLang_First")]
        First,

        [LocalizedDescription("TestLang_Second")]
        Second,
    }
```
