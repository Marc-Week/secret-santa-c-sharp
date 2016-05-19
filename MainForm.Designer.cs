namespace Seceret_Sanata
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.addPersonButton = new System.Windows.Forms.Button();
            this.RunButton = new System.Windows.Forms.Button();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.emailTextBox = new System.Windows.Forms.TextBox();
            this.SpouseComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.spouceLabel = new System.Windows.Forms.Label();
            this.linkLabel = new System.Windows.Forms.Label();
            this.linkComboBox = new System.Windows.Forms.ComboBox();
            this.linkButton = new System.Windows.Forms.Button();
            this.peoplGridView = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Spouce = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.peoplGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // addPersonButton
            // 
            this.addPersonButton.Location = new System.Drawing.Point(15, 163);
            this.addPersonButton.Name = "addPersonButton";
            this.addPersonButton.Size = new System.Drawing.Size(75, 23);
            this.addPersonButton.TabIndex = 0;
            this.addPersonButton.Text = "Add Person";
            this.addPersonButton.UseVisualStyleBackColor = true;
            this.addPersonButton.Click += new System.EventHandler(this.addPersonButton_Click);
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(572, 418);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(75, 23);
            this.RunButton.TabIndex = 1;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(12, 76);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(129, 20);
            this.NameTextBox.TabIndex = 2;
            // 
            // emailTextBox
            // 
            this.emailTextBox.Location = new System.Drawing.Point(12, 126);
            this.emailTextBox.Name = "emailTextBox";
            this.emailTextBox.Size = new System.Drawing.Size(129, 20);
            this.emailTextBox.TabIndex = 3;
            // 
            // SpouseComboBox
            // 
            this.SpouseComboBox.FormattingEnabled = true;
            this.SpouseComboBox.Location = new System.Drawing.Point(16, 347);
            this.SpouseComboBox.Name = "SpouseComboBox";
            this.SpouseComboBox.Size = new System.Drawing.Size(129, 21);
            this.SpouseComboBox.TabIndex = 4;
            this.SpouseComboBox.SelectedIndexChanged += new System.EventHandler(this.SpouseComboBox_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 110);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Email";
            // 
            // spouceLabel
            // 
            this.spouceLabel.AutoSize = true;
            this.spouceLabel.Location = new System.Drawing.Point(13, 322);
            this.spouceLabel.Name = "spouceLabel";
            this.spouceLabel.Size = new System.Drawing.Size(44, 13);
            this.spouceLabel.TabIndex = 7;
            this.spouceLabel.Text = "Spouce";
            // 
            // linkLabel
            // 
            this.linkLabel.AutoSize = true;
            this.linkLabel.Location = new System.Drawing.Point(13, 271);
            this.linkLabel.Name = "linkLabel";
            this.linkLabel.Size = new System.Drawing.Size(40, 13);
            this.linkLabel.TabIndex = 9;
            this.linkLabel.Text = "Person";
            // 
            // linkComboBox
            // 
            this.linkComboBox.FormattingEnabled = true;
            this.linkComboBox.Location = new System.Drawing.Point(16, 287);
            this.linkComboBox.Name = "linkComboBox";
            this.linkComboBox.Size = new System.Drawing.Size(128, 21);
            this.linkComboBox.TabIndex = 10;
            this.linkComboBox.SelectedIndexChanged += new System.EventHandler(this.linkComboBox_SelectedIndexChanged);
            // 
            // linkButton
            // 
            this.linkButton.Location = new System.Drawing.Point(15, 383);
            this.linkButton.Name = "linkButton";
            this.linkButton.Size = new System.Drawing.Size(75, 23);
            this.linkButton.TabIndex = 11;
            this.linkButton.Text = "Link Spouce";
            this.linkButton.UseVisualStyleBackColor = true;
            this.linkButton.Click += new System.EventHandler(this.linkButton_Click);
            // 
            // peoplGridView
            // 
            this.peoplGridView.AllowUserToAddRows = false;
            this.peoplGridView.AllowUserToResizeColumns = false;
            this.peoplGridView.AllowUserToResizeRows = false;
            this.peoplGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.peoplGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.Email,
            this.Spouce});
            this.peoplGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.peoplGridView.Location = new System.Drawing.Point(305, 41);
            this.peoplGridView.Name = "peoplGridView";
            this.peoplGridView.ReadOnly = true;
            this.peoplGridView.Size = new System.Drawing.Size(342, 304);
            this.peoplGridView.TabIndex = 12;
            // 
            // Name
            // 
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // Spouce
            // 
            this.Spouce.HeaderText = "Spouce";
            this.Spouce.Name = "Spouce";
            this.Spouce.ReadOnly = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 473);
            this.Controls.Add(this.peoplGridView);
            this.Controls.Add(this.linkButton);
            this.Controls.Add(this.linkComboBox);
            this.Controls.Add(this.linkLabel);
            this.Controls.Add(this.spouceLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SpouseComboBox);
            this.Controls.Add(this.emailTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.addPersonButton);
          
            this.Text = "Secret Sanata";
            ((System.ComponentModel.ISupportInitialize)(this.peoplGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addPersonButton;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox emailTextBox;
        private System.Windows.Forms.ComboBox SpouseComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label spouceLabel;
        private System.Windows.Forms.Label linkLabel;
        private System.Windows.Forms.ComboBox linkComboBox;
        private System.Windows.Forms.Button linkButton;
        private System.Windows.Forms.DataGridView peoplGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Spouce;
    }
}

