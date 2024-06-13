using System.ComponentModel;

namespace WinFormsApp1;

partial class AddApplicationForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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

    private void InitializeComponent()
    {
        this.textBoxExecutablePath = new System.Windows.Forms.TextBox();
        this.buttonBrowse = new System.Windows.Forms.Button();
        this.textBoxAppName = new System.Windows.Forms.TextBox();
        this.textBoxArguments = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.buttonOK = new System.Windows.Forms.Button();
        this.buttonCancel = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // textBoxExecutablePath
        // 
        this.textBoxExecutablePath.Location = new System.Drawing.Point(12, 25);
        this.textBoxExecutablePath.Name = "textBoxExecutablePath";
        this.textBoxExecutablePath.Size = new System.Drawing.Size(300, 20);
        this.textBoxExecutablePath.TabIndex = 0;
        // 
        // buttonBrowse
        // 
        this.buttonBrowse.Location = new System.Drawing.Point(318, 23);
        this.buttonBrowse.Name = "buttonBrowse";
        this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
        this.buttonBrowse.TabIndex = 1;
        this.buttonBrowse.Text = "Browse";
        this.buttonBrowse.UseVisualStyleBackColor = true;
        this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
        // 
        // textBoxAppName
        // 
        this.textBoxAppName.Location = new System.Drawing.Point(12, 64);
        this.textBoxAppName.Name = "textBoxAppName";
        this.textBoxAppName.Size = new System.Drawing.Size(381, 20);
        this.textBoxAppName.TabIndex = 2;
        // 
        // textBoxArguments
        // 
        this.textBoxArguments.Location = new System.Drawing.Point(12, 103);
        this.textBoxArguments.Name = "textBoxArguments";
        this.textBoxArguments.Size = new System.Drawing.Size(381, 20);
        this.textBoxArguments.TabIndex = 3;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(12, 9);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(84, 13);
        this.label1.TabIndex = 4;
        this.label1.Text = "Executable Path";
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(12, 48);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(60, 13);
        this.label2.TabIndex = 5;
        this.label2.Text = "App Name";
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(12, 87);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(55, 13);
        this.label3.TabIndex = 6;
        this.label3.Text = "Arguments";
        // 
        // buttonOK
        // 
        this.buttonOK.Location = new System.Drawing.Point(237, 129);
        this.buttonOK.Name = "buttonOK";
        this.buttonOK.Size = new System.Drawing.Size(75, 23);
        this.buttonOK.TabIndex = 7;
        this.buttonOK.Text = "OK";
        this.buttonOK.UseVisualStyleBackColor = true;
        this.buttonOK.Click += buttonOK_Click;
        // 
        // buttonCancel
        // 
        this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.buttonCancel.Location = new System.Drawing.Point(318, 129);
        this.buttonCancel.Name = "buttonCancel";
        this.buttonCancel.Size = new System.Drawing.Size(75, 23);
        this.buttonCancel.TabIndex = 8;
        this.buttonCancel.Text = "Cancel";
        this.buttonCancel.UseVisualStyleBackColor = true;
        // 
        // AddApplicationForm
        // 
        this.ClientSize = new System.Drawing.Size(405, 164);
        this.Controls.Add(this.buttonCancel);
        this.Controls.Add(this.buttonOK);
        this.Controls.Add(this.label3);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.textBoxArguments);
        this.Controls.Add(this.textBoxAppName);
        this.Controls.Add(this.buttonBrowse);
        this.Controls.Add(this.textBoxExecutablePath);
        this.Name = "AddApplicationForm";
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.TextBox textBoxExecutablePath;
    private System.Windows.Forms.Button buttonBrowse;
    private System.Windows.Forms.TextBox textBoxAppName;
    private System.Windows.Forms.TextBox textBoxArguments;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Button buttonOK;
    private System.Windows.Forms.Button buttonCancel;
}