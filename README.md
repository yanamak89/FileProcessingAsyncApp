# Task: Refactoring Additional Assignment from Lesson #11

## Description

This task is a refactoring of the additional assignment using `async/await`. The objective is to create a console application that:

- Accesses two files in different threads.
- Reads the content of these files.
- Writes the obtained information to a third file.
- Ensures correct access to the file for writing using thread locking.
- Implements sequential execution of three threads.

## Implementation

### Main Steps

1. **Asynchronous File Operations:**
   - Reading data from files using `StreamReader`.
   - Writing data to the output file using `StreamWriter`.

2. **Thread Locking:**
   - Using `SemaphoreSlim` to ensure correct writing to the third file.

3. **Delay Simulation:**
   - Using `Task.Delay` to simulate data processing.

4. **Sequential Execution:**
   - Threads work sequentially, controlling access to the resource through a semaphore.

## How to Run

1. Create a console project in your IDE:
   ```bash
   dotnet new console -n AsyncFileProcessing
   cd AsyncFileProcessing
   ```
2. Replace the content of `Program.cs` with the provided code.
3. Run the application using the command:
   ```bash
   dotnet run
   ```

## Expected Result

The program will create three files:

1. `file1.txt`: Contains the text "This is the content of file 1.".
2. `file2.txt`: Contains the text "This is the content of file 2.".
3. `result.txt`: Contains the merged content of both files with timestamps.

### Example Console Log:
```
Data processing completed. Check the result file.
```

### Example Content of `result.txt`:
```
[2024-12-30 16:00:54] Data from file1.txt:
This is the content of file 1.

[2024-12-30 16:00:55] Data from file2.txt:
This is the content of file 2.
```

## Notes

- Ensure that .NET SDK 6.0 or later is installed.
- If additional functionality is required, such as processing more than two files, the program can be easily scaled.
- The code ensures sequential thread execution and correct writing to the file, even under high load.
