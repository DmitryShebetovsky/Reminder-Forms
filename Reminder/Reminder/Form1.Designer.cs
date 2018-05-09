namespace Reminder
{
    partial class Reminder
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
            this.Calendar = new System.Windows.Forms.MonthCalendar();
            this.EventBox = new System.Windows.Forms.GroupBox();
            this.CencelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.IsRemind = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Repeat = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.DateEvent = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.NameEvent = new System.Windows.Forms.TextBox();
            this.Events = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DelButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.EventBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Calendar
            // 
            this.Calendar.BackColor = System.Drawing.Color.PaleGreen;
            this.Calendar.Location = new System.Drawing.Point(13, 28);
            this.Calendar.Name = "Calendar";
            this.Calendar.TabIndex = 0;
            this.Calendar.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.Calendar_DateSelected);
            // 
            // EventBox
            // 
            this.EventBox.Controls.Add(this.CencelButton);
            this.EventBox.Controls.Add(this.OKButton);
            this.EventBox.Controls.Add(this.IsRemind);
            this.EventBox.Controls.Add(this.label3);
            this.EventBox.Controls.Add(this.Repeat);
            this.EventBox.Controls.Add(this.label2);
            this.EventBox.Controls.Add(this.DateEvent);
            this.EventBox.Controls.Add(this.label1);
            this.EventBox.Controls.Add(this.NameEvent);
            this.EventBox.Enabled = false;
            this.EventBox.ForeColor = System.Drawing.Color.Maroon;
            this.EventBox.Location = new System.Drawing.Point(380, 28);
            this.EventBox.Name = "EventBox";
            this.EventBox.Size = new System.Drawing.Size(343, 129);
            this.EventBox.TabIndex = 1;
            this.EventBox.TabStop = false;
            this.EventBox.Text = "Событие";
            // 
            // CencelButton
            // 
            this.CencelButton.ForeColor = System.Drawing.Color.Brown;
            this.CencelButton.Location = new System.Drawing.Point(236, 98);
            this.CencelButton.Name = "CencelButton";
            this.CencelButton.Size = new System.Drawing.Size(101, 23);
            this.CencelButton.TabIndex = 8;
            this.CencelButton.Text = "Cancel";
            this.CencelButton.UseVisualStyleBackColor = true;
            this.CencelButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // OKButton
            // 
            this.OKButton.ForeColor = System.Drawing.Color.ForestGreen;
            this.OKButton.Location = new System.Drawing.Point(105, 98);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(97, 23);
            this.OKButton.TabIndex = 7;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // IsRemind
            // 
            this.IsRemind.AutoSize = true;
            this.IsRemind.ForeColor = System.Drawing.Color.Red;
            this.IsRemind.Location = new System.Drawing.Point(10, 98);
            this.IsRemind.Name = "IsRemind";
            this.IsRemind.Size = new System.Drawing.Size(89, 17);
            this.IsRemind.TabIndex = 6;
            this.IsRemind.Text = "Напоминать";
            this.IsRemind.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label3.Location = new System.Drawing.Point(5, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Повторять";
            // 
            // Repeat
            // 
            this.Repeat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Repeat.FormattingEnabled = true;
            this.Repeat.Items.AddRange(new object[] {
            "Один раз",
            "Каждый месяц",
            "Каждый год"});
            this.Repeat.Location = new System.Drawing.Point(72, 71);
            this.Repeat.Name = "Repeat";
            this.Repeat.Size = new System.Drawing.Size(265, 21);
            this.Repeat.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label2.Location = new System.Drawing.Point(7, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Время";
            // 
            // DateEvent
            // 
            this.DateEvent.AllowDrop = true;
            this.DateEvent.Cursor = System.Windows.Forms.Cursors.Default;
            this.DateEvent.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.DateEvent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.DateEvent.Location = new System.Drawing.Point(72, 45);
            this.DateEvent.Name = "DateEvent";
            this.DateEvent.ShowUpDown = true;
            this.DateEvent.Size = new System.Drawing.Size(265, 20);
            this.DateEvent.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название";
            // 
            // NameEvent
            // 
            this.NameEvent.Location = new System.Drawing.Point(72, 19);
            this.NameEvent.Name = "NameEvent";
            this.NameEvent.Size = new System.Drawing.Size(265, 20);
            this.NameEvent.TabIndex = 0;
            // 
            // Events
            // 
            this.Events.FormattingEnabled = true;
            this.Events.Location = new System.Drawing.Point(189, 30);
            this.Events.Name = "Events";
            this.Events.Size = new System.Drawing.Size(167, 160);
            this.Events.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.DelButton);
            this.panel1.Controls.Add(this.EditButton);
            this.panel1.Controls.Add(this.AddButton);
            this.panel1.Location = new System.Drawing.Point(380, 161);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(343, 29);
            this.panel1.TabIndex = 3;
            // 
            // DelButton
            // 
            this.DelButton.Enabled = false;
            this.DelButton.ForeColor = System.Drawing.Color.Firebrick;
            this.DelButton.Location = new System.Drawing.Point(236, 3);
            this.DelButton.Name = "DelButton";
            this.DelButton.Size = new System.Drawing.Size(101, 23);
            this.DelButton.TabIndex = 2;
            this.DelButton.Text = "Удалить";
            this.DelButton.UseVisualStyleBackColor = true;
            this.DelButton.Click += new System.EventHandler(this.DelButton_Click);
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Location = new System.Drawing.Point(121, 3);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(109, 23);
            this.EditButton.TabIndex = 1;
            this.EditButton.Text = "Редактировать";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(5, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(110, 23);
            this.AddButton.TabIndex = 0;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(52, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Календарь";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(235, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "События";
            // 
            // Reminder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(735, 199);
            this.Controls.Add(this.Events);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Calendar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.EventBox);
            this.ForeColor = System.Drawing.Color.ForestGreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Reminder";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reminder";
            this.EventBox.ResumeLayout(false);
            this.EventBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MonthCalendar Calendar;
        private System.Windows.Forms.GroupBox EventBox;
        private System.Windows.Forms.DateTimePicker DateEvent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NameEvent;
        private System.Windows.Forms.Button CencelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.CheckBox IsRemind;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Repeat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox Events;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button DelButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

