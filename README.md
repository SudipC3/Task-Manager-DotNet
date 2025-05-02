# Task Manager (.NET)

A simple console-based task management application built with .NET that helps you keep track of your tasks.

## Features

- Add new tasks with titles and deadlines
- View all tasks with their status (Done/Pending)
- Mark tasks as completed
- Persistent storage using JSON

## Requirements

- .NET 8.0 or higher

## Installation

1. Clone the repository:
   ```
   git clone https://github.com/SudipC3/Task-Manager-DotNet.git
   ```

2. Navigate to the project directory:
   ```
   cd Task-Manager-DotNet
   ```

3. Build the project:
   ```
   dotnet build
   ```

## Usage

Run the application:
```
dotnet run
```

### Menu Options

1. **Add Task** - Create a new task with a title and deadline
2. **View Tasks** - Display all tasks with their details
3. **Mark Task as Done** - Mark a task as completed
4. **Exit** - Close the application

## Data Storage

Tasks are stored in a `tasks.json` file in the application directory. The file is automatically created when you add your first task.

## Project Structure

- `Program.cs` - Contains the main application logic and user interface
- `tasks.json` - Stores the task data in JSON format


## Contributing

Contributions are welcome! Please feel free to submit a Pull Request.