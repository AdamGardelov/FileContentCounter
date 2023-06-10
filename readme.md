# FileContentCounter

This is a console program that counts the number of occurrences of a file's name (without the file extension) 
within its contents. The program takes one argument, which is the path to the file.

Example: If the argument is "testfile.txt," the program will count how many times the string "testfile" appears in the file.

The program utilizes a FileService to handle the occurrence counting. 
The service has a method called CountWordOccurrencesInFile that reads the file and iterates over all lines in the file, 
for each line it checks for the word. This seems like a better option than File.ReadAllText if the files are very big.

# FileContentCounter.Tests

Using NUnit the there are tests that validate the behavior of the FileService
in various scenarios.

These tests cover different cases, including valid files, missing files, and invalid file paths.