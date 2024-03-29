using System;
using System.Text.Json;

class ProjectSetup
{
    public static void DoAll(bool isYFlagSet)
    {
        UserInput.Info($"-y flag: {isYFlagSet}");

        string projectName = UserInput.AskUserString("Enter the project name");
        string projectDescription = UserInput.AskUserString("Enter the project description");
        string projectAuthor = UserInput.AskUserString("Enter the project author");
        bool UseExpressTemplate = UserInput.AskUserBool("Use Express Template? (y/n)");
        DateTime ProjectDate = DateTime.Now;

        Console.Clear();

        // Create a JSON object to store the project information
        var projectInfo = new
        {
            name = projectName,
            version = "1.0.0",
            description = projectDescription,
            main = "index.js",
            scripts = new { start = "node index.js" },
            Author = projectAuthor,
            UseExpressTemplate = UseExpressTemplate,
            Date = ProjectDate
        };

        // Convert the projectInfo object to JSON string with indentation
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(projectInfo, options);

        // Create a folder with the project name
        string projectFolder = projectName.Replace(" ", "_");
        System.IO.Directory.CreateDirectory(projectFolder);

        // Write the JSON string to a file in the project folder
        string filePath = System.IO.Path.Combine(projectFolder, "package.json");
        System.IO.File.WriteAllText(filePath, json);

        Console.WriteLine($"Project information has been saved to {filePath}");

        // Read the JSON string from the same file
        string jsonContent = System.IO.File.ReadAllText(filePath);
        UserInput.Info(json);

        // Create a new file in the project folder
        string fileName = "index.js";
        string fileContent = UseExpressTemplate ? ExpressTemplate.Template : "console.log('Hello, World!');";
        string filePath2 = System.IO.Path.Combine(projectFolder, fileName);
        System.IO.File.WriteAllText(filePath2, fileContent);
    }
}