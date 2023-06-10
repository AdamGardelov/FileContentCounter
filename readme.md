# FileContentCounter

This is a console program that counts the number of occurrences of a file's name (without the file extension) 
within its contents. The program takes one argument, which is the path to the file.

Example: If the argument is "testfile.txt," the program will count how many times the string "testfile" appears in the file.

The program utilizes a FileService to handle the occurrence counting.

# FileContentCounter.Tests

Using NUnit the there are tests that validate the behavior of the FileService
in various scenarios.

These tests cover different cases, including valid files, missing files, and invalid file paths.