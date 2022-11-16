using System;
using System.Drawing;

namespace Netris
{
  /// <summary>
  /// Summary description for Blocks.
  /// </summary>
  public class Block
  {
    public Block()
    {
    }

    public int BlockType;
    public Color BlockColour;
    public int CurrentX;
    public int CurrentY;
    private int[,] BlockMatrix = {{0, 0, 0, 0},
                                  {0, 0, 0, 0},
                                  {0, 0, 0, 0},
                                  {0, 0, 0, 0}};

    public void Create()
    {
      System.Random randomNumber = new System.Random();

      BlockType = randomNumber.Next(1,8);

      switch( BlockType )
      {
        case 1:
        {
          BlockColour = Color.Blue;
          BlockMatrix[1, 0] = 1;
          BlockMatrix[1, 1] = 1;
          BlockMatrix[1, 2] = 1;
          BlockMatrix[1, 3] = 1;
        }
        break;
        
        case 2:
        {
          BlockColour = Color.Red;
          BlockMatrix[2, 1] = 1;
          BlockMatrix[1, 1] = 1;
          BlockMatrix[1, 2] = 1;
          BlockMatrix[2, 2] = 1;
        }
        break;
        
        case 3:
        {
          BlockColour = Color.Green;
          BlockMatrix[1, 0] = 1;
          BlockMatrix[1, 1] = 1;
          BlockMatrix[1, 2] = 1;
          BlockMatrix[2, 0] = 1;
        }
        break;
        
        case 4:
        {
          BlockColour = Color.Yellow;
          BlockMatrix[1, 0] = 1;
          BlockMatrix[1, 1] = 1;
          BlockMatrix[1, 2] = 1;
          BlockMatrix[2, 2] = 1;
        }
        break;
        
        case 5:
        {
          BlockColour = Color.Purple;
          BlockMatrix[1, 0] = 1;
          BlockMatrix[1, 1] = 1;
          BlockMatrix[2, 1] = 1;
          BlockMatrix[2, 2] = 1;
        }
        break;
        
        case 6:
        {
          BlockColour = Color.DarkSalmon;
          BlockMatrix[1, 1] = 1;
          BlockMatrix[1, 2] = 1;
          BlockMatrix[2, 1] = 1;
          BlockMatrix[2, 0] = 1;
        }
        break;
        
        case 7:
        {
          BlockColour = Color.YellowGreen;
          BlockMatrix[1, 1] = 1;
          BlockMatrix[1, 2] = 1;
          BlockMatrix[1, 0] = 1;
          BlockMatrix[2, 1] = 1;
        }
        break;
        
        default:
        break;
      }
    }

    public void Rotate()
    {
      int[,] TempMatrix= {{0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}};

      for( int q = 0; q <= 3; q++ )
      {
        for( int w = 0; w <= 3; w++ )
        {
          TempMatrix[q, w] = BlockMatrix[w, 3 - q];
        }
      }
      
      BlockMatrix = TempMatrix;
    }

    public void Unrotate()
    {
      for( int q = 1; q <= 3; q++ )
      {
        Rotate();
      }
    }

    public string ReturnBlock()
    {
      //Return String with block coordinates delimited by //#//
      string ReturnString = "";

      for( int q = 0; q <= 3; q++ )
      {
        for( int w = 0; w <= 3; w++ )
        {
          if (BlockMatrix[q, w] == 1)
          {
            if (ReturnString != "")
            {
              ReturnString = ReturnString + "#";
            }

            ReturnString += (q + CurrentX).ToString() + "," + (w + CurrentY).ToString();
          }
        }
      }

      return ReturnString;
    }

    public void MoveLeft()
    {
      CurrentX = CurrentX - 1;
    }

    public void MoveRight()
    {
      CurrentX = CurrentX + 1;
    }

    public void MoveDown()
    {
      CurrentY = CurrentY + 1;
    }
  }
}
