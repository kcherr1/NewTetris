using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;

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
    /// Here we are setting all the different color images to a value.
    public static Image imgPiece;
        public static Image bluePiece;
        public static Image redPiece;
        public static Image orangePiece;
        public static Image yellowPiece;
        public static Image greenPiece;
        public static Image cyanPiece;
        /// <summary>
        /// These are all the variables that are used relating to storing and the next block functions.
        /// </summary>
    public int nextNum;
        public int curNum = 0;
        public bool shapeStored = false;
        public int storeNum;
        public Queue nextQueue = new Queue();
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
            
      if(nextQueue.Count == 0)
            {
                for(int j = 0; j < 4; j++)
                {
                    int MakeQ = random.Next(7);
                    nextQueue.Enqueue(MakeQ);
                }
                //nextNum = random.Next(7);
                int d = 0;
                foreach(int bNum in nextQueue)
                {
                    setNextImage(bNum,d);
                    d += 4;
                }
                int shapeNum = random.Next(7);
                ShapeType shapetype = (ShapeType)shapeNum;
                curShape = ShapeFactory.MakeShape(shapetype);
                curNum = shapeNum;
                //setNextImage(nextNum);
            }
      else
            {
                clearNextBox();                
                int shapeNum = random.Next(7);
                nextNum = (int)nextQueue.Dequeue();
                nextQueue.Enqueue(shapeNum);
                int d = 0;
                foreach(int bNum in nextQueue)
                {
                    setNextImage(bNum,d);
                    d += 5;
                }
                ShapeType shapetype = (ShapeType)nextNum;
                curShape = ShapeFactory.MakeShape(shapetype);
                curNum = nextNum;
                //nextNum = random.Next(7);
                //setNextImage(nextNum);
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
        public void setNextImage(int t, int distance)
        {
            //Line
            if(t == 0)
            {
                
                createNextBlock(1,0+distance,0);
                createNextBlock(1,1+distance,0);
                createNextBlock(1,2+distance,0);
                createNextBlock(1,3+distance,0);
                
            }
            //Square
            if(t == 1)
            {
                createNextBlock(1,0+distance,1);
                createNextBlock(2,1+distance,1);
                createNextBlock(1,1+distance,1);
                createNextBlock(2,0+distance,1);
            }
            //L Block
            if(t == 2)
            {
                createNextBlock(1,0+distance,2);
                createNextBlock(1,1+distance,2);
                createNextBlock(1,2+distance,2);
                createNextBlock(2,2+distance,2);
            }
            // reverse L Block
            if(t == 3)
            {
                createNextBlock(2,0+distance,3);
                createNextBlock(2,1+distance,3);
                createNextBlock(2,2+distance,3);
                createNextBlock(1,2+distance,3);
            }
            //Z block
            if(t == 4)
            {
                createNextBlock(1,0+distance,4);
                createNextBlock(1,1+distance,4);
                createNextBlock(2,1+distance,4);
                createNextBlock(0,0+distance,4);
            }
            //T block
            if(t == 5)
            {
                createNextBlock(0,1+distance,5);
                createNextBlock(1,1+distance,5);
                createNextBlock(2,1+distance,5);
                createNextBlock(1,0+distance,5);
            }
            //reverse Z block
            if(t == 6)
            {
                createNextBlock(0,1+distance,6);
                createNextBlock(1,1+distance,6);
                createNextBlock(1,0+distance,6);
                createNextBlock(2,0+distance,6);
            }
            
            
        }
        public void setStoreImage(int t)
        {
            //Line
            if(t == 0)
            {
                
                createStoreBlock(1,0,0);
                createStoreBlock(1,1,0);
                createStoreBlock(1,2,0);
                createStoreBlock(1,3,0);
                
            }
            //Square
            if(t == 1)
            {
                createStoreBlock(1,1,1);
                createStoreBlock(2,2,1);
                createStoreBlock(1,2,1);
                createStoreBlock(2,1,1);
            }
            //L Block
            if(t == 2)
            {
                createStoreBlock(1,1,2);
                createStoreBlock(1,2,2);
                createStoreBlock(1,3,2);
                createStoreBlock(2,3,2);
            }
            // reverse L Block
            if(t == 3)
            {
                createStoreBlock(2,1,3);
                createStoreBlock(2,2,3);
                createStoreBlock(2,3,3);
                createStoreBlock(1,3,3);
            }
            //Z block
            if(t == 4)
            {
                createStoreBlock(1,1,4);
                createStoreBlock(1,2,4);
                createStoreBlock(2,2,4);
                createStoreBlock(0,1,4);
            }
            //T block
            if(t == 5)
            {
                createStoreBlock(0,2,5);
                createStoreBlock(1,2,5);
                createStoreBlock(2,2,5);
                createStoreBlock(1,1,5);
            }
            //reverse Z block
            if(t == 6)
            {
                createStoreBlock(0,2,6);
                createStoreBlock(1,2,6);
                createStoreBlock(1,1,6);
                createStoreBlock(2,1,6);
            }
        }
        public void createNextBlock(int x, int y, int t)
        {
            if(t == 0)
            {
                PictureBox pic;
                pic = new PictureBox();
                pic.BackgroundImage = Game.cyanPiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(30, 30);
                Game.NextBox.Controls.Add(pic);
                pic.Left = 30*x;
                pic.Top = 30*y;
            }
           if(t == 1)
            {
                PictureBox pic;
                pic = new PictureBox();
                pic.BackgroundImage = Game.yellowPiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(30, 30);
                Game.NextBox.Controls.Add(pic);
                pic.Left = 30*x;
                pic.Top = 30*y;
            }
           if(t == 2)
            {
                PictureBox pic;
                pic = new PictureBox();
                pic.BackgroundImage = Game.bluePiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(30, 30);
                Game.NextBox.Controls.Add(pic);
                pic.Left = 30*x;
                pic.Top = 30*y;
            }
           if(t == 3)
            {
                PictureBox pic;
                pic = new PictureBox();
                pic.BackgroundImage = Game.orangePiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(30, 30);
                Game.NextBox.Controls.Add(pic);
                pic.Left = 30*x;
                pic.Top = 30*y;
            }
           if(t == 4)
            {
                PictureBox pic;
                pic = new PictureBox();
                pic.BackgroundImage = Game.redPiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(30, 30);
                Game.NextBox.Controls.Add(pic);
                pic.Left = 30*x;
                pic.Top = 30*y;
            }
           if(t == 5)
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
           if(t == 6)
            {
                PictureBox pic;
                pic = new PictureBox();
                pic.BackgroundImage = Game.greenPiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(30, 30);
                Game.NextBox.Controls.Add(pic);
                pic.Left = 30*x;
                pic.Top = 30*y;
            }
        }
        public void createStoreBlock(int x, int y, int t)
        {
           if(t == 0)
            {
                PictureBox pic;
                pic = new PictureBox();
                pic.BackgroundImage = Game.cyanPiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(30, 30);
                Game.StoreBox.Controls.Add(pic);
                pic.Left = 30*x;
                pic.Top = 30*y;
            }
           if(t == 1)
            {
                PictureBox pic;
                pic = new PictureBox();
                pic.BackgroundImage = Game.yellowPiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(30, 30);
                Game.StoreBox.Controls.Add(pic);
                pic.Left = 30*x;
                pic.Top = 30*y;
            }
           if(t == 2)
            {
                PictureBox pic;
                pic = new PictureBox();
                pic.BackgroundImage = Game.bluePiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(30, 30);
                Game.StoreBox.Controls.Add(pic);
                pic.Left = 30*x;
                pic.Top = 30*y;
            }
           if(t == 3)
            {
                PictureBox pic;
                pic = new PictureBox();
                pic.BackgroundImage = Game.orangePiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(30, 30);
                Game.StoreBox.Controls.Add(pic);
                pic.Left = 30*x;
                pic.Top = 30*y;
            }
           if(t == 4)
            {
                PictureBox pic;
                pic = new PictureBox();
                pic.BackgroundImage = Game.redPiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(30, 30);
                Game.StoreBox.Controls.Add(pic);
                pic.Left = 30*x;
                pic.Top = 30*y;
            }
           if(t == 5)
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
           if(t == 6)
            {
                PictureBox pic;
                pic = new PictureBox();
                pic.BackgroundImage = Game.greenPiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(30, 30);
                Game.StoreBox.Controls.Add(pic);
                pic.Left = 30*x;
                pic.Top = 30*y;
            }
        }
  }
}
