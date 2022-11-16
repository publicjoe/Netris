using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Publicjoe.Windows;

namespace Netris
{
  public partial class Form1 : Form
  {
    private const int PLAYAREAX = 9;
    private const int PLAYAREAY = 18;

    private Block CurrentBlock;
    private Block NextBlock;
    private int[,] InternalPlayArea = new int[11, 20];
    private bool Locked = false;
    private bool Paused = false;
    private int Score = 0;
    private int Lines = 0;
    private int Level = 0;

    private HighScoreTable highScoreTable = new HighScoreTable();

    public Form1()
    {
      InitializeComponent();

      // Enable Double Buffering to remove flicker
      this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      this.SetStyle(ControlStyles.UserPaint, true);
      this.SetStyle(ControlStyles.DoubleBuffer, true);

      // Load high score table...
      highScoreTable.Load(Application.StartupPath + @"\score.txt");

      CreateNextBlock();

      // Game Initialisation
      InitGame();
    }

    protected override void OnKeyDown(KeyEventArgs e)
    {
      switch (e.KeyCode)
      {
        case Keys.Left:
        {
          if (CanMove(CurrentBlock, -1, 0) == true)
          {
            DrawBlock(CurrentBlock, "Clear");
            CurrentBlock.MoveLeft();
            DrawBlock(CurrentBlock, "Draw");
          }
        }
        break;

        case Keys.Right:
        {
          if (CanMove(CurrentBlock, 1, 0) == true)
          {
            DrawBlock(CurrentBlock, "Clear");
            CurrentBlock.MoveRight();
            DrawBlock(CurrentBlock, "Draw");
          }
        }
        break;

        case Keys.Up:
        {
          DrawBlock(CurrentBlock, "Clear");
          CurrentBlock.Rotate();
          if (CanMove(CurrentBlock, 0, 0) == true)
          {
            DrawBlock(CurrentBlock, "Draw");
          }
          else
          {
            CurrentBlock.Unrotate();
            DrawBlock(CurrentBlock, "Draw");
          }
        }
        break;

        case Keys.Down:
        {
          for (int i = CurrentBlock.CurrentY; i <= PLAYAREAY; i++)
          {
            if (CanMove(CurrentBlock, 0, 1) == true)
            {
              DrawBlock(CurrentBlock, "Clear");
              CurrentBlock.MoveDown();
              DrawBlock(CurrentBlock, "Draw");
            }
          }

          Locked = false;   // Override Locked
        }
        break;

        default:
          break;
      }
    }

    private void highScoresToolStripMenuItem_Click(object sender, EventArgs e)
    {
      HighScoreForm HighScoreForm = new HighScoreForm(highScoreTable);
      HighScoreForm.StartPosition = FormStartPosition.CenterScreen;
      HighScoreForm.Show();
    }

    private void rulesToolStripMenuItem_Click(object sender, EventArgs e)
    {
      (new RulesForm()).ShowDialog();
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      Close();
    }

    private void CheckHighScore()
    {
      highScoreTable.Load(Application.StartupPath + @"\score.txt");

      int scoreIndex = highScoreTable.GetIndexOfScore(Score);

      if (scoreIndex > -1)
      {
        string name = "";
        using (EntryForm aForm = new EntryForm())
        {
          aForm.StartPosition = FormStartPosition.CenterScreen;

          if (aForm.ShowDialog() == DialogResult.OK)
          {
            name = aForm.textBox1.Text;

            highScoreTable.Update(name, Score);
          }
        }
      }
    }

    private void cmdStart_Click(object sender, EventArgs e)
    {
      InitGame();

      CreateNewBlock();
      Timer1.Interval = 1000;
      Timer1.Enabled = true;
      cmdStart.Enabled = false;
      cmdPause.Enabled = true;
      CreateNextBlock();
      DrawBlock(CurrentBlock, "Draw");
    }

    private void cmdPause_Click(object sender, EventArgs e)
    {
      if (Paused == false)
      {
        Paused = true;
        Timer1.Stop();
        txtPaused.Visible = true;
      }
      else
      {
        Timer1.Start();
        Paused = false;
        txtPaused.Visible = false;
      }
    }

    private void Timer1_Tick(object sender, EventArgs e)
    {
      //Check if we can go down - else create new block
      if (CanMove(CurrentBlock, 0, 1) == true)
      {
        DrawBlock(CurrentBlock, "Clear");
        CurrentBlock.MoveDown();
        DrawBlock(CurrentBlock, "Draw");
        Locked = false;
      }
      else
      {
        if (Locked == true)
        {
          //Game Over
          GameOver.Visible = true;
          Timer1.Enabled = false;
          cmdStart.Text = "Play Again";
          cmdStart.Enabled = true;
          cmdPause.Enabled = false;
          CheckHighScore();
        }
        else
        {
          DrawBlock(CurrentBlock, "Lock");
          CheckForLine();
          CurrentBlock = NextBlock;
          CurrentBlock.CurrentX = 3;
          CreateNextBlock();
          DrawBlock(CurrentBlock, "Draw");
          Locked = true;
        }
      }
    }

    #region graphics
    // Graphical Routines (Draw / Clear )
    public void ClearBox(int intX, int intY)
    {
      Graphics g = PlayArea.CreateGraphics();
      SolidBrush B = new SolidBrush(Color.White);
      Rectangle rect = new Rectangle(4 + intX * 20, 4 + intY * 20, 19, 19);

      g.FillRectangle(B, rect);
    }

    public void DrawBox(int intX, int intY, Color intColor)
    {
      Graphics g = PlayArea.CreateGraphics();
      Pen P = new Pen(Color.Black);
      SolidBrush B = new SolidBrush(intColor);

      Rectangle rect = new Rectangle(4 + intX * 20, 4 + intY * 20, 18, 18);

      g.FillRectangle(B, rect);
      g.DrawRectangle(P, rect);
    }

    // Block Manipulation Routines
    public void DrawBlock(Block theBlock, string Directive)
    {
      int[,] WorkArray = new int[4, 2];
      string[] WorkArray2;
      string[] WorkArray3;

      int i;

      WorkArray2 = System.Text.RegularExpressions.Regex.Split(theBlock.ReturnBlock(), "#");

      for (i = 0; i <= 3; i++)
      {
        WorkArray3 = System.Text.RegularExpressions.Regex.Split(WorkArray2[i], ",");
        WorkArray[i, 0] = Convert.ToInt16(WorkArray3[0]);
        WorkArray[i, 1] = Convert.ToInt16(WorkArray3[1]);
      }

      for (i = 0; i <= 3; i++)
      {
        switch (Directive)
        {
          case "Clear":
            ClearBox(WorkArray[i, 0], WorkArray[i, 1]);
            InternalPlayArea[WorkArray[i, 0], WorkArray[i, 1]] = 0;
            break;
          case "Draw":
            DrawBox(WorkArray[i, 0], WorkArray[i, 1], theBlock.BlockColour);
            break;
          case "Lock":
            DrawBox(WorkArray[i, 0], WorkArray[i, 1], theBlock.BlockColour);
            InternalPlayArea[WorkArray[i, 0], WorkArray[i, 1]] = theBlock.BlockType;
            break;
        }
      }

      // Draw Stationary Blocks
      for (i = 0; i <= PLAYAREAX; i++)
      {
        for (int j = 0; j <= PLAYAREAY; j++)
        {
          if (InternalPlayArea[i, j] == 1)
            DrawBox(i, j, Color.Blue);

          if (InternalPlayArea[i, j] == 2)
            DrawBox(i, j, Color.Red);

          if (InternalPlayArea[i, j] == 3)
            DrawBox(i, j, Color.Green);

          if (InternalPlayArea[i, j] == 4)
            DrawBox(i, j, Color.Yellow);

          if (InternalPlayArea[i, j] == 5)
            DrawBox(i, j, Color.Purple);

          if (InternalPlayArea[i, j] == 6)
            DrawBox(i, j, Color.DarkSalmon);

          if (InternalPlayArea[i, j] == 7)
            DrawBox(i, j, Color.YellowGreen);
        }
      }

      DrawNextBlock();
    }

    private bool CanMove(Block theblock, int intXdir, int intYdir)
    {
      int[,] WorkArray = new int[4, 2];
      bool bCanMove;

      // Push coordinated to proposed ones
      string[] WorkArray2;
      string[] WorkArray3;

      WorkArray2 = System.Text.RegularExpressions.Regex.Split(theblock.ReturnBlock(), "#");

      int i;

      for (i = 0; i <= 3; i++)
      {
        WorkArray3 = System.Text.RegularExpressions.Regex.Split(WorkArray2[i], ",");
        WorkArray[i, 0] = Convert.ToInt16(WorkArray3[0]);
        WorkArray[i, 1] = Convert.ToInt16(WorkArray3[1]);
      }

      for (i = 0; i <= 3; i++)
      {
        WorkArray[i, 0] = WorkArray[i, 0] + intXdir;
        WorkArray[i, 1] = WorkArray[i, 1] + intYdir;
      }

      // Perform Checks
      bCanMove = true;

      // First check screen left/right boundaries
      if (bCanMove == true)
      {
        for (i = 0; i <= 3; i++)
        {
          if ((WorkArray[i, 0] < 0) || (WorkArray[i, 0] > PLAYAREAX))
          {
            bCanMove = false;
          }
        }
      }

      // Next check screen up/down boundaries
      if (bCanMove == true)
      {
        for (i = 0; i <= 3; i++)
        {
          if ((WorkArray[i, 1] < 0) || (WorkArray[i, 1] > PLAYAREAY))
          {
            bCanMove = false;
          }
        }
      }

      // Finally check if we trying to occupy a space which is already full
      if (bCanMove == true)
      {
        for (i = 0; i <= 3; i++)
        {
          if (InternalPlayArea[WorkArray[i, 0], WorkArray[i, 1]] != 0)
          {
            bCanMove = false;
          }
        }
      }
      return bCanMove;
    }

    private void CheckForLine()
    {
      // Check lines by working from bottom up
      int i;
      int j;
      int k;
      int BoxCount;
      int LineCount;

      // Color NewColor;
      i = PLAYAREAY;
      LineCount = 0;

      while (i > 0)
      {
        BoxCount = 0;
        for (j = 0; j <= PLAYAREAX; j++)
        {
          if (InternalPlayArea[j, i] != 0)
          {
            BoxCount++;
          }
        }

        if (BoxCount == 10)
        {
          LineCount++;

          // Clear Line
          for (k = i; k >= 1; k--)
          {
            for (j = 0; j <= PLAYAREAX; j++)
            {
              InternalPlayArea[j, k] = InternalPlayArea[j, k - 1];

              if (InternalPlayArea[j, k] == 0)
              {
                ClearBox(j, k);
              }
              else
              {
                DrawBox(j, k, Color.FromArgb(InternalPlayArea[j, k]));
              }
            }
          }
        }
        else
        {
          i--;
        }
      }

      switch (LineCount)
      {
        case 1: Score += 10; break;
        case 2: Score += 30; break;
        case 3: Score += 60; break;
        case 4: Score += 100; break;
      }

      Lines += LineCount;

      //Increase the speed every ten lines, down to 200ms
      if ((Lines > 0) && (Timer1.Interval > 200))
      {
        if (Lines >= ((Level * 10) + 10))
        {
          Level++;
          Timer1.Interval = Timer1.Interval - 50;
        }
      }

      txtScore.Text = System.String.Format(Score.ToString(), "#,##0");
      txtLines.Text = System.String.Format(Lines.ToString(), "#,##0");
    }

    private void InitGame()
    {
      GameOver.Visible = false;
      Timer1.Enabled = false;

      for (int i = 0; i <= PLAYAREAX; i++)
      {
        for (int j = 0; j <= PLAYAREAY; j++)
        {
          InternalPlayArea[i, j] = 0;
        }
      }

      PlayArea.CreateGraphics().Clear(Color.White);

      Score = 0;
      Lines = 0;
      txtScore.Text = 0.ToString();
      txtLines.Text = 0.ToString();

      this.KeyPreview = true;
    }

    private void CreateNewBlock()
    {
      CurrentBlock = new Block();
      CurrentBlock.Create();
      CurrentBlock.CurrentX = 3;
      CurrentBlock.CurrentY = 0;
    }

    private void CreateNextBlock()
    {
      NextBlock = new Block();
      NextBlock.Create();
      NextBlock.CurrentX = 0;
      NextBlock.CurrentY = 0;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      if (CurrentBlock != null)
        DrawBlock(CurrentBlock, "Draw");

      base.OnPaint(e);
    }

    private void DrawNextBlock()
    {
      // Clear box
      Graphics g = NextView.CreateGraphics();
      SolidBrush B = new SolidBrush(Color.White);

      Rectangle rect = new Rectangle(0, 0, 100, 100);

      g.FillRectangle(B, rect);

      // Now draw next block
      int[,] WorkArray = new int[4, 2];

      string[] WorkArray2 = System.Text.RegularExpressions.Regex.Split(NextBlock.ReturnBlock(), "#");

      for (int i = 0; i <= 3; i++)
      {
        string[] WorkArray3 = System.Text.RegularExpressions.Regex.Split(WorkArray2[i], ",");
        WorkArray[i, 0] = Convert.ToInt16(WorkArray3[0]);
        WorkArray[i, 1] = Convert.ToInt16(WorkArray3[1]);

        Pen P = new Pen(Color.Black);
        B = new SolidBrush(NextBlock.BlockColour);

        rect = new Rectangle(8 + WorkArray[i, 0] * 20, 1 + WorkArray[i, 1] * 20, 18, 18);

        g.FillRectangle(B, rect);
        g.DrawRectangle(P, rect);
      }
    }
    #endregion
  }
}