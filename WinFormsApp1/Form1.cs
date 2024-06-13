using System.Diagnostics;
using Microsoft.Win32;
using System.Management;
using Microsoft.Data.Sqlite;

namespace WinFormsApp1;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        DataAccess.InitializeDatabase();
        InitiateListView();
        PopulateTreeView();
    }
    
    private List<AppInfo> savedApps = new List<AppInfo>();

    private List<string> filterApps = new List<string>
    {
        "x64",
        "64-bit",
        "x86",
        "driver",
        "update",
        ".net",
        "SDK",
        "setup",
        "installer"
    };

    private List<Configuration> _configurations = new List<Configuration>();

    public readonly record struct Program
    {
        public string Name { get; init; }
        public string Path { get; init; }
        public string Arguments { get; init; }
    }

    public class Configuration
    {
        public string Name { get; set; }
        public List<Program> Programs { get; set; }
    }

    public class AppInfo
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string ExecutablePath { get; set; }
        public string Args { get; set; }
    }

    // public List<(string Name, string Path)> GetInstalledApplications()
    // {
    //     List<(string Name, string Path)> apps = new List<(string Name, string Path)>();
    //     // List of keys to search within
    //     string[] registry_keys =
    //     {
    //         @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall",
    //         @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall"
    //     };
    //
    //     // Checking both LocalMachine and CurrentUser registry hives
    //     RegistryKey[] registryHives = { Registry.LocalMachine, Registry.CurrentUser };
    //
    //     foreach (var hive in registryHives)
    //     {
    //         foreach (var registry_key in registry_keys)
    //         {
    //             using (RegistryKey key = hive.OpenSubKey(registry_key))
    //             {
    //                 if (key != null)
    //                 {
    //                     foreach (string subkey_name in key.GetSubKeyNames())
    //                     {
    //                         using (RegistryKey subkey = key.OpenSubKey(subkey_name))
    //                         {
    //                             string displayName = (string)subkey.GetValue("DisplayName");
    //                             string displayIcon = (string)subkey.GetValue("DisplayIcon");
    //                             string installLocation = (string)subkey.GetValue("InstallLocation");
    //
    //                             if (!string.IsNullOrEmpty(displayName) &&
    //                                 !filterApps.Any(s => displayName.ToLowerInvariant().Contains(s)))
    //                             {
    //                                 string executablePath = displayIcon ?? "";
    //
    //                                 if (string.IsNullOrEmpty(executablePath) || !executablePath.EndsWith(".exe"))
    //                                 {
    //                                     if (!string.IsNullOrEmpty(installLocation))
    //                                     {
    //                                         executablePath = Path.Combine(installLocation, (displayName + ".exe"));
    //                                     }
    //                                 }
    //
    //                                 if (!string.IsNullOrEmpty(executablePath) && executablePath.EndsWith(".exe"))
    //                                 {
    //                                     apps.Add((displayName, executablePath));
    //                                 }
    //                             }
    //                         }
    //                     }
    //                 }
    //             }
    //         }
    //     }
    //
    //     return apps;
    // }

    public void PopulateTreeView()
    {
        treeView1.Nodes.Clear();

        var Configurations = DataAccess.GetConfigurations();
        _configurations.Clear();
        _configurations.AddRange(Configurations);

        foreach (var config in _configurations)
        {
            var node = treeView1.Nodes.Add(config.Name + $" ({config.Programs.Count} Programs)");
            foreach (var prog in config.Programs)
            {
                node.Nodes.Add($"{prog.Name}, Path: {prog.Path}, Args: {prog.Arguments}");
            }
        }
    }

    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    }

    private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        ListViewItem selectedItem = new ListViewItem(listView1.FocusedItem.Text);
        listSelectedApps.Items.Add(selectedItem);
    }

    private void InitiateListView()
    {
        // var apps = GetInstalledApplications();
        // foreach (var app in apps)  
        // {
        //     var appinfo = new AppInfo()
        //     {
        //         Name = app.Name,
        //         ExecutablePath = app.Path,
        //         Args = ""
        //     };
        //     DataAccess.AddApplication(appinfo);
        // }
        // savedApps = apps;
        // foreach (var app in apps)
        // {
        //     ListViewItem item = new ListViewItem(app.Name, app.Path);
        //     listView1.Items.Add(item);
        // }

        savedApps = DataAccess.GetApplications();
        foreach (var app in savedApps)
        {
            ListViewItem item = new ListViewItem(app.Name);
            listView1.Items.Add(item);
        }
    }

    private void listSelectedApps_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        listSelectedApps.Items.Remove(listSelectedApps.FocusedItem);
    }

    private void SaveConfig_Click(object sender, EventArgs e)
    {
        List<Program> programs = new List<Program>();
        foreach (ListViewItem item in listSelectedApps.Items)
        {
            string[] parts = item.Text.Split(',');
            string name = parts[0];
            string path = savedApps.Find(x => x.Name == name).ExecutablePath;

            programs.Add(new Program { Name = name, Path = path, Arguments = "" });
        }

        if (programs.Count == 0)
        {
            MessageBox.Show("Please select at least one program", "Warning", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }

        Configuration config = new Configuration
        {
            Name = textBox1.Text,
            Programs = programs
        };

        DataAccess.AddConfiguration(config);
        PopulateTreeView();
        listSelectedApps.Items.Clear();
    }

    private void richTextBox1_TextChanged(object sender, EventArgs e)
    {
        var filteredItems = savedApps.Where(x => x.Name.ToLower().Contains(richTextBox1.Text.ToLower())).ToList();
        listView1.Items.Clear();
        foreach (var item in filteredItems)
        {
            listView1.Items.Add((string)item.Name);
        }
    }

    private void Form1_Load(object sender, EventArgs e)
    {
    }

    private void label1_Click(object sender, EventArgs e)
    {
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
    }

    private void label2_Click(object sender, EventArgs e)
    {

    }

    private void RunConfig_Click(object sender, EventArgs e)
    {
        if (treeView1.SelectedNode == null)
        {
            MessageBox.Show("Please select a configuration to run", "Warning", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }
        var currentConfig = _configurations[treeView1.SelectedNode.Index];
        foreach (var program in currentConfig.Programs)
        {
            StartApplication(program.Path, program.Arguments, program.Name);
        }
    }

    private void StartApplication(string path, string arguments, string name)
    {
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = path,
                Arguments = arguments
            };
            Process.Start(startInfo);
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, $"{name} failed to start", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void DeleteConfig_Click(object sender, EventArgs e)
    {
        if (treeView1.SelectedNode == null)
        {
            MessageBox.Show("Please select a configuration to delete", "Warning", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }
        else
        {
            var result = MessageBox.Show("Are you sure you want to delete this configuration?", "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }
        }


        DataAccess.DeleteConfiguration(_configurations[treeView1.SelectedNode.Index]);
        PopulateTreeView();
    }

    private void AddApplication_Click(object sender, EventArgs e)
    {
        // open popup where you can see the following info:
        // executable path, where you can select a EXE and this will auto fill the name of the app
        // appname, will be auto filled an you can change it if you want.
        // arguments, arguments can be added 

        using (AddApplicationForm addApplicationForm = new AddApplicationForm())
        {
            if (addApplicationForm.ShowDialog() == DialogResult.OK)
            {
                string executablePath = addApplicationForm.ExecutablePath;
                string appName = addApplicationForm.AppName;
                string arguments = addApplicationForm.Arguments;

                if (string.IsNullOrEmpty(executablePath) || string.IsNullOrEmpty(appName))
                {
                    MessageBox.Show("Please select an executable path and app name", "Warning", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                var app = new AppInfo
                {
                    Name = appName,
                    ExecutablePath = executablePath,
                    Args = arguments
                };
                this.AddNewApplication(app);
            }
        }
    }

    private void DeleteApplication_Click(object sender, EventArgs e)
    {
        if (listView1.FocusedItem == null)
        {
            MessageBox.Show("Please select an application to delete", "Warning", MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
            return;
        }
        else
        {
            var result = MessageBox.Show($"Are you sure you want to delete this application? \n{listView1.FocusedItem.Text}", "Warning", MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }

        }
        var app = savedApps.Find(x => x.Name == listView1.FocusedItem.Text);
        var count = DataAccess.GetApplicationUsageInConfigs(app);
        if (count > 0)
        {
            var result = MessageBox.Show($"The application {app.Name} is used in {count} configurations. Do you want to continue?",
                "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }

            DataAccess.ExecuteQuery("DELETE FROM Programs WHERE ApplicationID = $id", new Dictionary<string, object> { { "$id", app.ID } });
        }

        DataAccess.ExecuteQuery("DELETE FROM Applications WHERE Name = $name", new Dictionary<string, object> { { "$name", app.Name } });
        savedApps.Remove(app);
        listView1.Items.Remove(listView1.FocusedItem);
    }

    private void AddNewApplication(AppInfo app)
    {
        DataAccess.AddApplication(app);
        savedApps.Add(app);
        ListViewItem item = new ListViewItem(app.Name);
        listView1.Items.Add(item);
    }
}

public static class DataAccess
{
    // create 3 methodes, 1 for adding new configruations, 1 for getting all configurations and 1 for initializing the json file
    // i want to store the configurations in a json file
    private static string _connectionString = "Data Source=Configurations.db";

    async public static void InitializeDatabase()
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var createTableCommand = connection.CreateCommand();
            // make this can handle form1.configuration
            // Create a table with configruations: ID, Name
            createTableCommand.CommandText =
                "CREATE TABLE IF NOT EXISTS Configurations (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT UNIQUE)";
            createTableCommand.ExecuteNonQuery();
            
            // create table Applications: ID, Name, ExecutablePath
            createTableCommand.CommandText =
                "CREATE TABLE IF NOT EXISTS Applications (ID INTEGER PRIMARY KEY AUTOINCREMENT, Name TEXT UNIQUE, ExecutablePath TEXT, Args TEXT)";
            createTableCommand.ExecuteNonQuery();
            
            // create a table with programs: ID, ConfigurationID, ApplicationID
            createTableCommand.CommandText =
                @"CREATE TABLE IF NOT EXISTS Programs (
                    ID INTEGER PRIMARY KEY AUTOINCREMENT,
                    ApplicationID INTEGER,
                    ConfigurationID INTEGER,
                    FOREIGN KEY(ApplicationID) REFERENCES Applications(ID),
                    FOREIGN KEY(ConfigurationID) REFERENCES Configurations(ID))";
            
            createTableCommand.ExecuteNonQuery();
        }
    }

    public static List<Form1.Configuration> GetConfigurations()
    {
        List<Form1.Configuration> configurations = new List<Form1.Configuration>();
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var selectCommand = connection.CreateCommand();
            selectCommand.CommandText = "SELECT ID, Name FROM Configurations";
            using (var reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var selectCommand2 = connection.CreateCommand();
                    selectCommand2.CommandText =
                        @"SELECT Applications.Name, Applications.ExecutablePath, Applications.Args
                          FROM Programs 
                          INNER JOIN Applications ON Programs.ApplicationID = Applications.ID
                          WHERE ConfigurationID = $id";
                    selectCommand2.Parameters.AddWithValue("$id", reader.GetInt32(0));
                    using (var programReader = selectCommand2.ExecuteReader())
                    {
                        List<Form1.Program> programs = new List<Form1.Program>();
                        while (programReader.Read())
                        {
                            programs.Add(new Form1.Program
                            {
                                Name = programReader.GetString(0),
                                Path = programReader.GetString(1),
                                Arguments = programReader.GetString(2)
                            });
                        }

                        configurations.Add(new Form1.Configuration
                        {
                            Name = reader.GetString(1),
                            Programs = programs
                        });
                    }
                }
            }
        }

        return configurations;
    }

    public static void AddConfiguration(Form1.Configuration newConfig)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            var query = "INSERT INTO Configurations (Name) VALUES ($name)";
            ExecuteQuery(query, new Dictionary<string, object> {{"$name", newConfig.Name}});

            connection.Open();
            var insertCommand = connection.CreateCommand();
            insertCommand.CommandText = "SELECT last_insert_rowid()";
            int configID = Convert.ToInt32(insertCommand.ExecuteScalar());

            var queryInsertProgram = "INSERT INTO Programs (ApplicationID, ConfigurationID) VALUES ($appID, $configID)";
            foreach (var program in newConfig.Programs)
            {
                var appID = connection.CreateCommand();
                appID.CommandText = "SELECT ID FROM Applications WHERE Name = $name";
                appID.Parameters.AddWithValue("$name", program.Name);
                appID.Prepare();
                appID.ExecuteNonQuery();
                var appIDValue = Convert.ToInt32(appID.ExecuteScalar());
                
                ExecuteQuery(queryInsertProgram, new Dictionary<string, object>
                {
                    {"$appID", appIDValue},
                    {"$configID", configID}
                });
            }
        }
    }
    
    public static void DeleteConfiguration(Form1.Configuration config)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var selectCommand = connection.CreateCommand();
            selectCommand.CommandText = "SELECT ID FROM Configurations WHERE Name = $name";
            selectCommand.Parameters.AddWithValue("$name", config.Name);
            selectCommand.Prepare();
            selectCommand.ExecuteNonQuery();
            
            var configID = Convert.ToInt32(selectCommand.ExecuteScalar());
            
            var queryPrograms = "DELETE FROM Programs WHERE ConfigurationID = $configID";
            ExecuteQuery(queryPrograms, new Dictionary<string, object> {{"$configID", configID}});
            
            var query = "DELETE FROM Configurations WHERE Name = $name";
            ExecuteQuery(query, new Dictionary<string, object> {{"$name", config.Name}});
        }
    }
    
    public static void ExecuteQuery(string query, Dictionary<string, object> parameters = null) 
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
            }
            command.CommandText = query;
            command.ExecuteNonQuery();
        }
    }
    public static void AddApplication(Form1.AppInfo app)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            var query = "INSERT INTO Applications (Name, ExecutablePath, Args) VALUES ($name, $path, $args)";
            ExecuteQuery(query, new Dictionary<string, object>
            {
                {"$name", app.Name},
                {"$path", app.ExecutablePath},
                {"$args", app.Args}
            });
        }
    }

    public static List<Form1.AppInfo> GetApplications()
    {
        List<Form1.AppInfo> applications = new List<Form1.AppInfo>();
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var selectCommand = connection.CreateCommand();
            selectCommand.CommandText = "SELECT ID, Name, ExecutablePath, Args FROM Applications";
            using (var reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    applications.Add(new Form1.AppInfo
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        ExecutablePath = reader.GetString(2),
                        Args = reader.GetString(3)
                    });
                }
            }
        }

        return applications;
    }

    public static int GetApplicationUsageInConfigs(Form1.AppInfo app)
    {
        var querySelect = "SELECT COUNT(*) FROM Programs WHERE ApplicationID = $id";
        var parameters = new Dictionary<string, object> {{"$id", app.ID}};
        var count = 0;
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            var command = connection.CreateCommand();
            command.CommandText = querySelect;
            command.Parameters.AddWithValue("$id", app.ID);
            count = Convert.ToInt32(command.ExecuteScalar());
        }

        return count;
    }
       
}