using System.Windows.Forms;

namespace LOI
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ExecuteButton = new System.Windows.Forms.Button();
            this.InputExpressionTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.InputPanel = new System.Windows.Forms.Panel();
            this.SetsPanelBase = new System.Windows.Forms.Panel();
            this.RemoveSetButton = new System.Windows.Forms.Button();
            this.AddSetButton = new System.Windows.Forms.Button();
            this.SetsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.Status = new System.Windows.Forms.Label();
            this.renderPanel = new System.Windows.Forms.Panel();
            this.ResultPanel = new System.Windows.Forms.Panel();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InputPanel.SuspendLayout();
            this.SetsPanelBase.SuspendLayout();
            this.renderPanel.SuspendLayout();
            this.ResultPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ExecuteButton
            // 
            this.ExecuteButton.AutoSize = true;
            this.ExecuteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ExecuteButton.Location = new System.Drawing.Point(6, 516);
            this.ExecuteButton.Name = "ExecuteButton";
            this.ExecuteButton.Size = new System.Drawing.Size(349, 51);
            this.ExecuteButton.TabIndex = 0;
            this.ExecuteButton.Text = "Рассчитать и Построить";
            this.ExecuteButton.UseVisualStyleBackColor = true;
            this.ExecuteButton.Click += new System.EventHandler(this.ExecuteButton_Click);
            // 
            // InputExpressionTextBox
            // 
            this.InputExpressionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InputExpressionTextBox.Location = new System.Drawing.Point(6, 482);
            this.InputExpressionTextBox.MaxLength = 60;
            this.InputExpressionTextBox.Name = "InputExpressionTextBox";
            this.InputExpressionTextBox.Size = new System.Drawing.Size(349, 28);
            this.InputExpressionTextBox.TabIndex = 1;
            this.InputExpressionTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.InputExpressionTextBox_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.1F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(89, 459);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Логическое выражение";
            // 
            // InputPanel
            // 
            this.InputPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.InputPanel.Controls.Add(this.SetsPanelBase);
            this.InputPanel.Controls.Add(this.Status);
            this.InputPanel.Controls.Add(this.label1);
            this.InputPanel.Controls.Add(this.InputExpressionTextBox);
            this.InputPanel.Controls.Add(this.ExecuteButton);
            this.InputPanel.Location = new System.Drawing.Point(12, 13);
            this.InputPanel.Name = "InputPanel";
            this.InputPanel.Size = new System.Drawing.Size(370, 650);
            this.InputPanel.TabIndex = 0;
            this.InputPanel.Click += new System.EventHandler(this.InputPanel_Click);
            // 
            // SetsPanelBase
            // 
            this.SetsPanelBase.Controls.Add(this.RemoveSetButton);
            this.SetsPanelBase.Controls.Add(this.AddSetButton);
            this.SetsPanelBase.Controls.Add(this.SetsPanel);
            this.SetsPanelBase.Location = new System.Drawing.Point(6, 3);
            this.SetsPanelBase.Name = "SetsPanelBase";
            this.SetsPanelBase.Size = new System.Drawing.Size(349, 430);
            this.SetsPanelBase.TabIndex = 18;
            // 
            // RemoveSetButton
            // 
            this.RemoveSetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RemoveSetButton.Location = new System.Drawing.Point(179, 3);
            this.RemoveSetButton.Name = "RemoveSetButton";
            this.RemoveSetButton.Size = new System.Drawing.Size(167, 36);
            this.RemoveSetButton.TabIndex = 1;
            this.RemoveSetButton.Text = "-";
            this.RemoveSetButton.UseVisualStyleBackColor = true;
            this.RemoveSetButton.Click += new System.EventHandler(this.RemoveSetButton_Click_1);
            // 
            // AddSetButton
            // 
            this.AddSetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddSetButton.Location = new System.Drawing.Point(3, 3);
            this.AddSetButton.Name = "AddSetButton";
            this.AddSetButton.Size = new System.Drawing.Size(170, 36);
            this.AddSetButton.TabIndex = 0;
            this.AddSetButton.Text = "+";
            this.AddSetButton.UseVisualStyleBackColor = true;
            this.AddSetButton.Click += new System.EventHandler(this.AddSetButton_Click_1);
            // 
            // SetsPanel
            // 
            this.SetsPanel.AutoScroll = true;
            this.SetsPanel.Location = new System.Drawing.Point(0, 45);
            this.SetsPanel.Name = "SetsPanel";
            this.SetsPanel.Size = new System.Drawing.Size(349, 385);
            this.SetsPanel.TabIndex = 0;
            // 
            // Status
            // 
            this.Status.AutoSize = true;
            this.Status.Location = new System.Drawing.Point(3, 622);
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(78, 16);
            this.Status.TabIndex = 17;
            this.Status.Text = "status: none";
            // 
            // renderPanel
            // 
            this.renderPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.renderPanel.Controls.Add(this.label2);
            this.renderPanel.Location = new System.Drawing.Point(388, 13);
            this.renderPanel.Name = "renderPanel";
            this.renderPanel.Size = new System.Drawing.Size(860, 587);
            this.renderPanel.TabIndex = 1;
            // 
            // ResultPanel
            // 
            this.ResultPanel.Controls.Add(this.ResultLabel);
            this.ResultPanel.Location = new System.Drawing.Point(389, 607);
            this.ResultPanel.Name = "ResultPanel";
            this.ResultPanel.Size = new System.Drawing.Size(859, 56);
            this.ResultPanel.TabIndex = 2;
            // 
            // ResultLabel
            // 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultLabel.Location = new System.Drawing.Point(4, 16);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(209, 24);
            this.ResultLabel.TabIndex = 19;
            this.ResultLabel.Text = "Итоговое множество:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "label2";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.ResultPanel);
            this.Controls.Add(this.renderPanel);
            this.Controls.Add(this.InputPanel);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LOI (Logical Operations Illustrator)";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.InputPanel.ResumeLayout(false);
            this.InputPanel.PerformLayout();
            this.SetsPanelBase.ResumeLayout(false);
            this.renderPanel.ResumeLayout(false);
            this.renderPanel.PerformLayout();
            this.ResultPanel.ResumeLayout(false);
            this.ResultPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button ExecuteButton;
        private System.Windows.Forms.TextBox InputExpressionTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel InputPanel;
        private System.Windows.Forms.Panel renderPanel;
        private System.Windows.Forms.Label Status;
        private Panel SetsPanelBase;
        private FlowLayoutPanel SetsPanel;
        private Button AddSetButton;
        private Button RemoveSetButton;
        private Panel ResultPanel;
        private Label ResultLabel;
        private Label label2;
    }
}

