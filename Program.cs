using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

class TaskItem
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime Deadline { get; set; }
    public bool IsDone { get; set; }

    public override string ToString()
    {
        return $"{Id,3} | {Title,-20} | {Deadline.ToShortDateString()} | {(IsDone ? "Done" : "Pending")}";
    }
}

class Program
{
    static List<TaskItem> tasks = new List<TaskItem>();
    static string filePath = "tasks.json";
    static int nextId = 1;

    static void Main()
    {
        Console.WriteLine("=== Task Manager ===");
        LoadTasks();
        while (true)
        {
            Console.WriteLine("\n1. Add Task\n2. View Tasks\n3. Mark Task as Done\n4. Exit");
            Console.Write("Choose option: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1": AddTask(); break;
                case "2": ViewTasks(); break;
                case "3": MarkTaskAsDone(); break;
                case "4": return;
                default: Console.WriteLine("Invalid option"); break;
            }
        }
    }

    static void AddTask()
    {
        Console.Write("Enter task title: ");
        string title = Console.ReadLine();

        Console.Write("Enter deadline (MM/DD/YYYY): ");
        DateTime deadline;
        while (!DateTime.TryParse(Console.ReadLine(), out deadline))
        {
            Console.Write("Invalid date. Please enter again: ");
        }

        var task = new TaskItem
        {
            Id = nextId++,
            Title = title,
            Deadline = deadline,
            IsDone = false
        };

        tasks.Add(task);
        SaveTasks();
        Console.WriteLine("Task added successfully.");
    }

    static void ViewTasks()
    {
        Console.WriteLine("\n--- All Tasks ---");
        if (tasks.Count == 0)
        {
            Console.WriteLine("No tasks added.");
            return;
        }

        foreach (var task in tasks)
        {
            Console.WriteLine(task);
        }
    }

    static void MarkTaskAsDone()
    {
        ViewTasks();
        Console.Write("Enter the task ID to mark as done: ");
        if (int.TryParse(Console.ReadLine(), out int id))
        {
            var task = tasks.Find(t => t.Id == id);
            if (task != null)
            {
                task.IsDone = true;
                SaveTasks();
                Console.WriteLine("Task marked as done.");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
    }

    static void LoadTasks()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();
            nextId = tasks.Count > 0 ? tasks[^1].Id + 1 : 1;
        }
    }

    static void SaveTasks()
    {
        string json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }
}
