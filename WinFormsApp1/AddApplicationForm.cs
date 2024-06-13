namespace WinFormsApp1;

public partial class AddApplicationForm : Form
{
    public AddApplicationForm()
    {
        InitializeComponent();
    }
    
    private void buttonBrowse_Click(object sender, EventArgs e)
    {
        using (OpenFileDialog openFileDialog = new OpenFileDialog())
        {
            openFileDialog.Filter = "Executable files (*.exe)|*.exe";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                textBoxExecutablePath.Text = openFileDialog.FileName;
                textBoxAppName.Text = Path.GetFileNameWithoutExtension(openFileDialog.FileName);
            }
        }
    }
    
    private void buttonOK_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(textBoxExecutablePath.Text))
        {
            MessageBox.Show("Executable path is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        
        if (string.IsNullOrWhiteSpace(textBoxAppName.Text))
        {
            MessageBox.Show("Application name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        
        DialogResult = DialogResult.OK;
        Close();
    }

    public string ExecutablePath => textBoxExecutablePath.Text;
    public string AppName => textBoxAppName.Text;
    public string Arguments => textBoxArguments.Text;
}