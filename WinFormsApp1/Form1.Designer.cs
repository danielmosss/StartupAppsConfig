namespace WinFormsApp1;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
        listView1 = new ListView();
        AppName = new ColumnHeader("(none)");
        button1 = new Button();
        richTextBox1 = new RichTextBox();
        contextMenuStrip1 = new ContextMenuStrip(components);
        searchToolStripMenuItem = new ToolStripMenuItem();
        textBox1 = new TextBox();
        contextMenuStrip2 = new ContextMenuStrip(components);
        contextMenuStrip3 = new ContextMenuStrip(components);
        configurationToolStripMenuItem = new ToolStripMenuItem();
        toolStripTextBox1 = new ToolStripTextBox();
        label1 = new Label();
        treeView1 = new TreeView();
        LabelSelectConfig = new Label();
        RunConfig = new Button();
        button3 = new Button();
        DeleteApplication = new Button();
        AddApplication = new Button();
        notifyIcon1 = new NotifyIcon(components);
        listSelectedApps = new ListView();
        columnHeader1 = new ColumnHeader("(none)");
        label2 = new Label();
        contextMenuStrip1.SuspendLayout();
        contextMenuStrip3.SuspendLayout();
        SuspendLayout();
        // 
        // listView1
        // 
        listView1.Columns.AddRange(new ColumnHeader[] { AppName });
        listView1.Location = new Point(12, 42);
        listView1.Name = "listView1";
        listView1.Size = new Size(355, 338);
        listView1.TabIndex = 0;
        listView1.UseCompatibleStateImageBehavior = false;
        listView1.View = View.Details;
        listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
        listView1.MouseDoubleClick += listView1_MouseDoubleClick;
        // 
        // AppName
        // 
        AppName.Text = "Apps";
        AppName.Width = 350;
        // 
        // button1
        // 
        button1.Location = new Point(688, 13);
        button1.Name = "button1";
        button1.Size = new Size(75, 23);
        button1.TabIndex = 2;
        button1.Text = "Save";
        button1.UseVisualStyleBackColor = true;
        button1.Click += SaveConfig_Click;
        // 
        // richTextBox1
        // 
        richTextBox1.Location = new Point(60, 11);
        richTextBox1.Name = "richTextBox1";
        richTextBox1.Size = new Size(307, 23);
        richTextBox1.TabIndex = 3;
        richTextBox1.Text = "";
        richTextBox1.TextChanged += richTextBox1_TextChanged;
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.ImageScalingSize = new Size(20, 20);
        contextMenuStrip1.Items.AddRange(new ToolStripItem[] { searchToolStripMenuItem });
        contextMenuStrip1.Name = "contextMenuStrip1";
        contextMenuStrip1.Size = new Size(110, 26);
        // 
        // searchToolStripMenuItem
        // 
        searchToolStripMenuItem.Name = "searchToolStripMenuItem";
        searchToolStripMenuItem.Size = new Size(109, 22);
        searchToolStripMenuItem.Text = "Search";
        // 
        // textBox1
        // 
        textBox1.Location = new Point(496, 12);
        textBox1.Margin = new Padding(3, 2, 3, 2);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(186, 23);
        textBox1.TabIndex = 4;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // contextMenuStrip2
        // 
        contextMenuStrip2.ImageScalingSize = new Size(20, 20);
        contextMenuStrip2.Name = "contextMenuStrip2";
        contextMenuStrip2.Size = new Size(61, 4);
        // 
        // contextMenuStrip3
        // 
        contextMenuStrip3.ImageScalingSize = new Size(20, 20);
        contextMenuStrip3.Items.AddRange(new ToolStripItem[] { configurationToolStripMenuItem, toolStripTextBox1 });
        contextMenuStrip3.Name = "contextMenuStrip3";
        contextMenuStrip3.Size = new Size(161, 51);
        // 
        // configurationToolStripMenuItem
        // 
        configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
        configurationToolStripMenuItem.Size = new Size(160, 22);
        configurationToolStripMenuItem.Text = "Configuration";
        // 
        // toolStripTextBox1
        // 
        toolStripTextBox1.Name = "toolStripTextBox1";
        toolStripTextBox1.Size = new Size(100, 23);
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(409, 14);
        label1.Name = "label1";
        label1.Size = new Size(81, 15);
        label1.TabIndex = 7;
        label1.Text = "Configuration";
        label1.Click += label1_Click;
        // 
        // treeView1
        // 
        treeView1.Location = new Point(809, 42);
        treeView1.Name = "treeView1";
        treeView1.Size = new Size(370, 367);
        treeView1.TabIndex = 8;
        // 
        // LabelSelectConfig
        // 
        LabelSelectConfig.AutoSize = true;
        LabelSelectConfig.Location = new Point(809, 20);
        LabelSelectConfig.Name = "LabelSelectConfig";
        LabelSelectConfig.Size = new Size(122, 15);
        LabelSelectConfig.TabIndex = 9;
        LabelSelectConfig.Text = "Select a configuration";
        LabelSelectConfig.Click += label2_Click;
        // 
        // RunConfig
        // 
        RunConfig.BackColor = Color.Lime;
        RunConfig.Location = new Point(937, 16);
        RunConfig.Name = "RunConfig";
        RunConfig.Size = new Size(75, 23);
        RunConfig.TabIndex = 10;
        RunConfig.Text = "Start";
        RunConfig.UseVisualStyleBackColor = false;
        RunConfig.Click += RunConfig_Click;
        // 
        // button3
        // 
        button3.BackColor = Color.FromArgb(255, 128, 0);
        button3.Location = new Point(1018, 16);
        button3.Name = "button3";
        button3.Size = new Size(75, 23);
        button3.TabIndex = 11;
        button3.Text = "Delete";
        button3.UseVisualStyleBackColor = false;
        button3.Click += DeleteConfig_Click;
        // 
        // DeleteApplication
        // 
        DeleteApplication.BackColor = Color.FromArgb(255, 128, 0);
        DeleteApplication.Location = new Point(292, 386);
        DeleteApplication.Name = "DeleteApplication";
        DeleteApplication.Size = new Size(75, 23);
        DeleteApplication.TabIndex = 12;
        DeleteApplication.Text = "Delete";
        DeleteApplication.UseVisualStyleBackColor = false;
        DeleteApplication.Click += DeleteApplication_Click;
        // 
        // AddApplication
        // 
        AddApplication.Location = new Point(211, 386);
        AddApplication.Name = "AddApplication";
        AddApplication.Size = new Size(75, 23);
        AddApplication.TabIndex = 13;
        AddApplication.Text = "Add";
        AddApplication.UseVisualStyleBackColor = true;
        AddApplication.Click += AddApplication_Click;
        // 
        // notifyIcon1
        // 
        notifyIcon1.Text = "notifyIcon1";
        notifyIcon1.Visible = true;
        // 
        // listSelectedApps
        // 
        listSelectedApps.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
        listSelectedApps.Location = new Point(408, 42);
        listSelectedApps.Name = "listSelectedApps";
        listSelectedApps.Size = new Size(355, 367);
        listSelectedApps.TabIndex = 16;
        listSelectedApps.UseCompatibleStateImageBehavior = false;
        listSelectedApps.View = View.Details;
        listSelectedApps.MouseDoubleClick += listSelectedApps_MouseDoubleClick;
        // 
        // columnHeader1
        // 
        columnHeader1.Text = "Selected Apps";
        columnHeader1.Width = 350;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 14);
        label2.Name = "label2";
        label2.Size = new Size(42, 15);
        label2.TabIndex = 17;
        label2.Text = "Search";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1191, 426);
        Controls.Add(label2);
        Controls.Add(listSelectedApps);
        Controls.Add(AddApplication);
        Controls.Add(DeleteApplication);
        Controls.Add(button3);
        Controls.Add(RunConfig);
        Controls.Add(LabelSelectConfig);
        Controls.Add(treeView1);
        Controls.Add(label1);
        Controls.Add(textBox1);
        Controls.Add(richTextBox1);
        Controls.Add(button1);
        Controls.Add(listView1);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "Form1";
        Text = "Application Startup Manager";
        Load += Form1_Load;
        contextMenuStrip1.ResumeLayout(false);
        contextMenuStrip3.ResumeLayout(false);
        contextMenuStrip3.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListView listView1;
    private ColumnHeader AppName;
    private Button button1;
    private RichTextBox richTextBox1;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem searchToolStripMenuItem;
    private TextBox textBox1;
    private ContextMenuStrip contextMenuStrip2;
    private ContextMenuStrip contextMenuStrip3;
    private ToolStripMenuItem configurationToolStripMenuItem;
    private ToolStripTextBox toolStripTextBox1;
    private Label label1;
    private TreeView treeView1;
    private Label LabelSelectConfig;
    private Button RunConfig;
    private Button button3;
    private Button DeleteApplication;
    private Button AddApplication;
    private NotifyIcon notifyIcon1;
    private ListView listSelectedApps;
    private ColumnHeader columnHeader1;
    private Label label2;
}