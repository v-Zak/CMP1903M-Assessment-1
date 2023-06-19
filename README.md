# CMP1903M Assessment 1 - Analysis of Text

The following repository meets the requirements of the university brief outlined below:

Analysis of text is a crucial aspect of many computing applications. The ability to single out
words and phrases allows us to look for, for example: themes, sentiment and complexity of
language. For example, many on-line games allow players to message each other during the
game and twitter users send different messages. Analysis of these messages might reveal a
lot about the writers and their experience of the application they are using.
In this part of the assignment you are required to create a programme that looks at sentences
of text, use appropriate data structures to store the words and carry out an analysis of the
words entered.

On running the programme the user should be presented with two options in the console:

1. Do you want to enter the text via the keyboard?
2. Do you want to read in the text from a file?
   
If ‘Option 1’ is selected then the user will enter one or more sentences of text, one sentence
at a time. The use of an asterisk (*) could indicate the end of the entry. For example they may
enter:

The cat sat on the mat.

The program should then report back some basic analysis of this text:

Number of sentences entered = 1
Number of vowels = 6
Number of consonants = 11
Number of upper case letters = 1
Number of lower case letters = 16
The frequency of individual letters = ?

If ‘Option 2’ is selected then a file of pre-written text is opened, read and a similar analysis is
carried out and displayed on the console. In addition a file of “long words” is created as part
of the application and saved in the current directory i.e. any words longer than 7 characters.
