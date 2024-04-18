# NameSorter

NameSorter is a .NET application designed to sort names from a text file based on their last names and given names. It outputs sorted names both to the console and to a new file, making it suitable for both interactive use and integration into larger workflows.

## Features

- Reads names from a text file, where each name is expected to be in the format `GivenNames LastName`.
- Sorts names by last name and then by given names.
- Outputs sorted names to the console.
- Saves sorted names to a new text file.

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) or later

### Installing

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/NameSorter.git
2. Navigate to the project directory
   ```bash
   cd NameSorter
3. Build the project:
   ```bash
   dotnet build

### Usage
Run the application using the following command:
```bash
dotnet run --project NameSorter [path-to-input-file]

Example:
```bash
dotnet run --project NameSorter ./unsorted-names-list.txt

The sorted names will be displayed in the console and saved to sorted-names-list.txt in the same directory as the input file.

### Running the tests
To run automated tests for this system:
```bash
dotnet test

