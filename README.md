# Dependencies
Recommended to use .Net Core 3.1 (LTS).

# Build
Recommended to follow .Net Core build process. If you need to run the program, depending on the input path and the name of .exe file, the command line may look like this:
```
Name_Sorter_Console ./input.txt
```

# Classes
## Data
- **LocalDataRepository**: A repository for getting local data. 
## Model
- **Person**: Represents a person, which contains details such as given names and last name.
## Services
- **PersonValidator**: Validate a person (Person). 
- **SortPersonService**: A service to sort the list of persons.
