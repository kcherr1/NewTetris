using System;
using System.Drawing;
using System.Windows.Forms;

namespace NewTetris_Lib {
  /// <summary>
  /// Oracle game class controling the entire game
  /// </summary>
  public class Game {
    /// <summary>
    /// Current level the player is on - currently unused
    /// </summary>
    private int level;


    /// <summary>
    /// Game Over variable, false if a piece has not touched
    /// the upper border of the playing field
    /// </summary>
    private static bool isGameOver = false;


    /// <summary>
    /// Gets and sets the game over Variable
    /// </summary>
    public static bool IsGameOver { get => isGameOver; set => isGameOver = value; }


    /// <summary>
    /// Flag to see if player is currently playing the level
    /// and therefore level code should be running - currently unused
    /// </summary>
    private bool isPlaying;

    /// <summary>
    /// Current player score - currently unused
    /// </summary>
    private int score;

    /// <summary>
    /// Random object used to randomly select next shape
    /// to appear in level
    /// </summary>
    private Random random;

    /// <summary>
    /// Current shape dropping onto the playing field
    /// </summary>
    public static Shape curShape;
    

    /// <summary>
    /// Link to widget displaying the playing field. 
    /// Used to place pieces and shapes inside of it.
    /// </summary>
    public static Control field;

    /// <summary>
    /// Holds the image for a piece that is used to 
    /// compose a shape. This is used so the New Tetris Library
    /// can retrieve the image for a shape.
    /// </summary>
    public static Image imgPiece;
    public int nextNum;
        public int curNum;
        public bool shapeStored = false;
        public int storeNum;

    public static Control NextBox;
        public static Control StoreBox;
    /// <summary>
    /// Default constructor initializing random field and setting
    /// curShape to null
    /// </summary>
    public Game() {
      random = new Random();
      curShape = null;
    }

    /// <summary>
    /// Generates the next shape to be put into the playing field
    /// </summary>
    public void NextShape() {
            
      if(nextNum == null)
            {
                nextNum = random.Next(7);
                int shapeNum = random.Next(7);
                ShapeType shapetype = (ShapeType)shapeNum;
                curShape = ShapeFactory.MakeShape(shapetype);
                curNum = shapeNum;
                setNextImage(nextNum);
            }
      else
            {
                clearNextBox();
                ShapeType shapetype = (ShapeType)nextNum;
                curShape = ShapeFactory.MakeShape(shapetype);
                curNum = nextNum;
                nextNum = random.Next(7);
                setNextImage(nextNum);
            }    
     }

        public void storeShape()
        {
            if(shapeStored == false)
            {
                clearStoreBox();
                setStoreImage(curNum);
                storeNum = curNum;
                shapeStored = true;
                curShape.destroyShape();
                NextShape();
                curShape.storePressed = true;
            }
            else if(curShape.storePressed == false)
            {
                clearStoreBox();
                setStoreImage(curNum);
                curShape.destroyShape();
                ShapeType shapetype = (ShapeType)storeNum;
                curShape = ShapeFactory.MakeShape(shapetype);
                storeNum = curNum;
                curShape.storePressed = true;
            }
        }
        public void clearNextBox()
        {
            NextBox.Controls.Clear();
        }
        public void clearStoreBox()
        {
            StoreBox.Controls.Clear();
        }
        public void setNextImage(int t)
        {
            //Line
            if(t == 0)
            {
                for(int i = 0; i <= 4; i++)
                {
                    createNextBlock(1,i);
                }
            }
            //Square
            if(t == 1)
            {
                createNextBlock(1,1);
                createNextBlock(2,2);
                createNextBlock(1,2);
                createNextBlock(2,1);
            }
            //L Block
            if(t == 2)
            {
                createNextBlock(1,1);
                createNextBlock(1,2);
                createNextBlock(1,3);
                createNextBlock(2,3);
            }
            // reverse L Block
            if(t == 3)
            {
                createNextBlock(2,1);
                createNextBlock(2,2);
                createNextBlock(2,3);
                createNextBlock(1,3);
            }
            //Z block
            if(t == 4)
            {
                createNextBlock(1,1);
                createNextBlock(1,2);
                createNextBlock(2,2);
                createNextBlock(0,1);
            }
            //T block
            if(t == 5)
            {
                createNextBlock(0,2);
                createNextBlock(1,2);
                createNextBlock(2,2);
                createNextBlock(1,1);
            }
            //reverse Z block
            if(t == 6)
            {
                createNextBlock(0,2);
                createNextBlock(1,2);
                createNextBlock(1,1);
                createNextBlock(2,1);
            }
            
            
        }
        public void setStoreImage(int t)
        {
            //Line
            if(t == 0)
            {
                for(int i = 0; i <= 4; i++)
                {
                    createStoreBlock(1,i);
                }
            }
            //Square
            if(t == 1)
            {
                createStoreBlock(1,1);
                createStoreBlock(2,2);
                createStoreBlock(1,2);
                createStoreBlock(2,1);
            }
            //L Block
            if(t == 2)
            {
                createStoreBlock(1,1);
                createStoreBlock(1,2);
                createStoreBlock(1,3);
                createStoreBlock(2,3);
            }
            // reverse L Block
            if(t == 3)
            {
                createStoreBlock(2,1);
                createStoreBlock(2,2);
                createStoreBlock(2,3);
                createStoreBlock(1,3);
            }
            //Z block
            if(t == 4)
            {
                createStoreBlock(1,1);
                createStoreBlock(1,2);
                createStoreBlock(2,2);
                createStoreBlock(0,1);
            }
            //T block
            if(t == 5)
            {
                createStoreBlock(0,2);
                createStoreBlock(1,2);
                createStoreBlock(2,2);
                createStoreBlock(1,1);
            }
            //reverse Z block
            if(t == 6)
            {
                createStoreBlock(0,2);
                createStoreBlock(1,2);
                createStoreBlock(1,1);
                createStoreBlock(2,1);
            }
        }
        public void createNextBlock(int x, int y)
        {
            PictureBox pic;
                pic = new PictureBox();
                pic.BackgroundImage = Game.imgPiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(30, 30);
                Game.NextBox.Controls.Add(pic);
                pic.Left = 30*x;
                pic.Top = 30*y;
        }
        public void createStoreBlock(int x, int y)
        {
            PictureBox pic;
            pic = new PictureBox();
            pic.BackgroundImage = Game.imgPiece;
            pic.BackgroundImageLayout = ImageLayout.Stretch;
            pic.Size = new System.Drawing.Size(30, 30);
            Game.StoreBox.Controls.Add(pic);
            pic.Left = 30*x;
            pic.Top = 30*y;
        }
  }
}
