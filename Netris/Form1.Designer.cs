namespace Netris
{
  partial class Form1
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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.highScoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.rulesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.txtScore = new System.Windows.Forms.Label();
      this.groupBox2 = new System.Windows.Forms.GroupBox();
      this.txtLines = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.NextView = new System.Windows.Forms.Panel();
      this.textBox1 = new System.Windows.Forms.TextBox();
      this.PlayArea = new System.Windows.Forms.Panel();
      this.GameOver = new System.Windows.Forms.TextBox();
      this.txtPaused = new System.Windows.Forms.TextBox();
      this.cmdStart = new System.Windows.Forms.Button();
      this.cmdPause = new System.Windows.Forms.Button();
      this.Timer1 = new System.Windows.Forms.Timer(this.components);
      this.menuStrip1.SuspendLayout();
      this.groupBox1.SuspendLayout();
      this.groupBox2.SuspendLayout();
      this.SuspendLayout();
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(337, 24);
      this.menuStrip1.TabIndex = 2;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.highScoresToolStripMenuItem,
            this.rulesToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
      this.fileToolStripMenuItem.Text = "&File";
      // 
      // highScoresToolStripMenuItem
      // 
      this.highScoresToolStripMenuItem.Name = "highScoresToolStripMenuItem";
      this.highScoresToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.highScoresToolStripMenuItem.Text = "&High Scores";
      this.highScoresToolStripMenuItem.Click += new System.EventHandler(this.highScoresToolStripMenuItem_Click);
      // 
      // rulesToolStripMenuItem
      // 
      this.rulesToolStripMenuItem.Name = "rulesToolStripMenuItem";
      this.rulesToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.rulesToolStripMenuItem.Text = "&RulesForm";
      this.rulesToolStripMenuItem.Click += new System.EventHandler(this.rulesToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
      // 
      // exitToolStripMenuItem
      // 
      this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
      this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
      this.exitToolStripMenuItem.Text = "&Exit";
      this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.txtScore);
      this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox1.Location = new System.Drawing.Point(12, 27);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(95, 40);
      this.groupBox1.TabIndex = 3;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Score";
      // 
      // txtScore
      // 
      this.txtScore.AutoSize = true;
      this.txtScore.Location = new System.Drawing.Point(6, 16);
      this.txtScore.Name = "txtScore";
      this.txtScore.Size = new System.Drawing.Size(83, 13);
      this.txtScore.TabIndex = 0;
      this.txtScore.Text = "                   ";
      this.txtScore.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // groupBox2
      // 
      this.groupBox2.Controls.Add(this.txtLines);
      this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.groupBox2.Location = new System.Drawing.Point(12, 73);
      this.groupBox2.Name = "groupBox2";
      this.groupBox2.Size = new System.Drawing.Size(95, 40);
      this.groupBox2.TabIndex = 4;
      this.groupBox2.TabStop = false;
      this.groupBox2.Text = "Lines";
      // 
      // txtLines
      // 
      this.txtLines.AutoSize = true;
      this.txtLines.Location = new System.Drawing.Point(6, 16);
      this.txtLines.Name = "txtLines";
      this.txtLines.Size = new System.Drawing.Size(83, 13);
      this.txtLines.TabIndex = 5;
      this.txtLines.Text = "                   ";
      this.txtLines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.label2.Location = new System.Drawing.Point(18, 116);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(69, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Next Block";
      // 
      // NextView
      // 
      this.NextView.BackColor = System.Drawing.Color.White;
      this.NextView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.NextView.Location = new System.Drawing.Point(12, 132);
      this.NextView.Name = "NextView";
      this.NextView.Size = new System.Drawing.Size(95, 95);
      this.NextView.TabIndex = 6;
      // 
      // textBox1
      // 
      this.textBox1.Location = new System.Drawing.Point(136, 146);
      this.textBox1.Name = "textBox1";
      this.textBox1.Size = new System.Drawing.Size(100, 20);
      this.textBox1.TabIndex = 1;
      // 
      // PlayArea
      // 
      this.PlayArea.BackColor = System.Drawing.Color.White;
      this.PlayArea.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.PlayArea.Location = new System.Drawing.Point(117, 29);
      this.PlayArea.Name = "PlayArea";
      this.PlayArea.Size = new System.Drawing.Size(210, 390);
      this.PlayArea.TabIndex = 7;
      // 
      // GameOver
      // 
      this.GameOver.BackColor = System.Drawing.Color.Tan;
      this.GameOver.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.GameOver.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.GameOver.Location = new System.Drawing.Point(12, 268);
      this.GameOver.Multiline = true;
      this.GameOver.Name = "GameOver";
      this.GameOver.Size = new System.Drawing.Size(95, 62);
      this.GameOver.TabIndex = 8;
      this.GameOver.TabStop = false;
      this.GameOver.Text = "Game Over!";
      this.GameOver.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      // 
      // txtPaused
      // 
      this.txtPaused.BackColor = System.Drawing.Color.Tan;
      this.txtPaused.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.txtPaused.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.txtPaused.Location = new System.Drawing.Point(12, 233);
      this.txtPaused.Name = "txtPaused";
      this.txtPaused.Size = new System.Drawing.Size(95, 29);
      this.txtPaused.TabIndex = 9;
      this.txtPaused.TabStop = false;
      this.txtPaused.Text = "Paused";
      this.txtPaused.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txtPaused.Visible = false;
      // 
      // cmdStart
      // 
      this.cmdStart.Location = new System.Drawing.Point(12, 365);
      this.cmdStart.Name = "cmdStart";
      this.cmdStart.Size = new System.Drawing.Size(95, 23);
      this.cmdStart.TabIndex = 10;
      this.cmdStart.Text = "&Start";
      this.cmdStart.UseVisualStyleBackColor = true;
      this.cmdStart.Click += new System.EventHandler(this.cmdStart_Click);
      // 
      // cmdPause
      // 
      this.cmdPause.Location = new System.Drawing.Point(12, 394);
      this.cmdPause.Name = "cmdPause";
      this.cmdPause.Size = new System.Drawing.Size(95, 23);
      this.cmdPause.TabIndex = 11;
      this.cmdPause.Text = "&Pause";
      this.cmdPause.UseVisualStyleBackColor = true;
      this.cmdPause.Click += new System.EventHandler(this.cmdPause_Click);
      // 
      // Timer1
      // 
      this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Tan;
      this.ClientSize = new System.Drawing.Size(337, 429);
      this.Controls.Add(this.cmdPause);
      this.Controls.Add(this.cmdStart);
      this.Controls.Add(this.txtPaused);
      this.Controls.Add(this.GameOver);
      this.Controls.Add(this.PlayArea);
      this.Controls.Add(this.textBox1);
      this.Controls.Add(this.NextView);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.groupBox2);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.menuStrip1);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form1";
      this.Text = "Netris";
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.groupBox2.ResumeLayout(false);
      this.groupBox2.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem highScoresToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem rulesToolStripMenuItem;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.Label txtScore;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label txtLines;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Panel NextView;
    private System.Windows.Forms.TextBox textBox1;
    private System.Windows.Forms.Panel PlayArea;
    private System.Windows.Forms.TextBox GameOver;
    private System.Windows.Forms.TextBox txtPaused;
    private System.Windows.Forms.Button cmdStart;
    private System.Windows.Forms.Button cmdPause;
    private System.Windows.Forms.Timer Timer1;
  }
}

