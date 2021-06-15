using System;
using System.Windows.Forms;


namespace NewTetris_Lib {
  /// <summary>
  /// The class holds a single cube that can be used to compose a Tetris shape
  /// </summary>
  public class Piece {
    /// <summary>
    /// Size of piece, i.e the width and height in pixels
    /// </summary>
    public const int SIZE = 30;


    /// <summary>
    /// Current position of piece
    /// </summary>
    private Position pos;

    /// <summary>
    /// Control used to hold the image of the piece so GUI can display it
    /// </summary>
    private PictureBox pic;

    /// <summary>
    /// Getter and Setter
    /// </summary>
    public PictureBox Pic { get => pic; set => pic = value; }

    /// <summary>
    /// Getter and Setter
    /// </summary>
    public Position Pos { get => pos; set => pos = value; }

    /// <summary>
    /// typical explicit constructor
    /// </summary>
    /// <param name="pos">This gives the position of the piece</param>
    public Piece(Position pos,int shapeNum) {
            
            if(shapeNum == 0)
            {
                this.Pos = pos;
                pic = new PictureBox();
                pic.BackgroundImage = Game.cyanPiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(SIZE, SIZE);
                Game.field.Controls.Add(pic);
                UpdateImgPos();
            }
            if(shapeNum == 1)
            {
                this.Pos = pos;
                pic = new PictureBox();
                pic.BackgroundImage = Game.yellowPiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(SIZE, SIZE);
                Game.field.Controls.Add(pic);
                UpdateImgPos();
            }
            if(shapeNum == 2)
            {
                this.Pos = pos;
                pic = new PictureBox();
                pic.BackgroundImage = Game.bluePiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(SIZE, SIZE);
                Game.field.Controls.Add(pic);
                UpdateImgPos();
            }
            if(shapeNum == 3)
            {
                this.Pos = pos;
                pic = new PictureBox();
                pic.BackgroundImage = Game.orangePiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(SIZE, SIZE);
                Game.field.Controls.Add(pic);
                UpdateImgPos();
            }
            if(shapeNum == 4)
            {
                this.Pos = pos;
                pic = new PictureBox();
                pic.BackgroundImage = Game.redPiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(SIZE, SIZE);
                Game.field.Controls.Add(pic);
                UpdateImgPos();
            }
            if(shapeNum == 5)
            {
                this.Pos = pos;
                pic = new PictureBox();
                pic.BackgroundImage = Game.imgPiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(SIZE, SIZE);
                Game.field.Controls.Add(pic);
                UpdateImgPos();
            }
            if(shapeNum == 6)
            {
                this.Pos = pos;
                pic = new PictureBox();
                pic.BackgroundImage = Game.greenPiece;
                pic.BackgroundImageLayout = ImageLayout.Stretch;
                pic.Size = new System.Drawing.Size(SIZE, SIZE);
                Game.field.Controls.Add(pic);
                UpdateImgPos();
            }
      
    }
    
    /// <summary>
    /// Sets the position of the piece
    /// </summary>
    /// <param name="pos">New position of the piece</param>
    public void SetPos(Position pos) {
      this.Pos = pos;
      UpdateImgPos();
    }

    /// <summary>
    /// Allows the Picture Box control to be updated to the
    /// position of the piece, meaning the visual representation
    /// of the piece will now match the coding position of the piece.
    /// </summary>
    private void UpdateImgPos() {
      pic.Left = Pos.x;
      pic.Top = Pos.y;
      pic.Refresh();
    }

    /// <summary>
    /// Check to see if the piece can move down.
    /// </summary>
    /// <returns>True if moving down will not cause a collision, False otherwise</returns>
    public bool CanMoveDown() {
      Position posMoveTo = Pos;
      posMoveTo.y += SIZE;
      return !IsCollision(posMoveTo);
    }

    /// <summary>
    /// Check to see if the piece can move left.
    /// </summary>
    /// <returns>True if moving left will not cause a collision, False otherwise</returns>
    public bool CanMoveLeft() {
      Position posMoveTo = Pos;
      posMoveTo.x -= SIZE;
      return !IsCollision(posMoveTo);
    }

    /// <summary>
    /// Check to see if the piece can move right.
    /// </summary>
    /// <returns>True if moving right will not cause a collision, False otherwise</returns>
    public bool CanMoveRight() {
      Position posMoveTo = Pos;
      posMoveTo.x += SIZE;
      return !IsCollision(posMoveTo);
    }

    /// <summary>
    /// Puts this piece into the playing field. This takes the current position of the piece
    /// and puts a 1 in the playing field at that location, signify it is now occupied
    /// </summary>
    public void DissolveIntoField() {
      int r = Pos.y / SIZE;
      int c = Pos.x / SIZE;
        
      PlayingField.GetInstance().field[r, c] = 1;

    }

        

    /// <summary>
    /// Moves the piece down, updating the visual representation as well
    /// </summary>
    /// <returns>True if moving down was successful (i.e. no collision occurred), False otherwise</returns>
    public bool MoveDown() {
      Position posMoveTo = Pos;
      posMoveTo.y += SIZE;
      if (!IsCollision(posMoveTo)) {
        this.Pos = posMoveTo;
        UpdateImgPos();
        return true;
      }
      else {
        return false;
      }
    }

    /// <summary>
    /// Finds the lowest point a piece can drop
    /// </summary>
    /// <returns>The number of times it can fall</returns>
    public int FindLowestPoint() {

      Position posMoveTo = Pos;
      int counter = 0;
      while (!IsCollision(posMoveTo)) {
        posMoveTo.y += SIZE;
        counter++;
      }

      return counter - 1;

    }
    /// <summary>
    /// Moves the piece down to the point provided by the counter
    /// </summary>
    /// <param name="counter">The lowest point a piece can drop to preserve the shape still</param>
    public void MoveCompletelyDown(int counter) {

      for (int i = 0; i < counter; i++) {
        this.pos.y += SIZE;
        UpdateImgPos();

      }
    }

    /// <summary>
    /// Moves the piece left, updating the visual representation as well
    /// </summary>
    public void MoveLeft() {
      Position posMoveTo = Pos;
      posMoveTo.x -= SIZE;
      if (!IsCollision(posMoveTo)) {
        this.Pos = posMoveTo;
        UpdateImgPos();
      }
    }

    /// <summary>
    /// Moves the piece right, updating the visual representation as well
    /// </summary>
    public void MoveRight() {
      Position posMoveTo = Pos;
      posMoveTo.x += SIZE;
      if (!IsCollision(posMoveTo)) {
        this.Pos = posMoveTo;
        UpdateImgPos();
      }
    }

    /// <summary>
    /// Checks if this piece's position is already occupied in the playing field
    /// </summary>
    /// <returns>
    /// True if a collision occurred (i.e. playing field already has a 1 in the piece's current position),
    /// False otherwise
    /// </returns>
    public bool IsCollision() {
      return IsCollision(this.Pos);
    }

    /// <summary>
    /// Checks a given position to see if it is already occupied in the playing field.
    /// Used to specutively move a piece and see if a collision would occur, without actually
    /// modifying its current position
    /// </summary>
    /// <param name="pos">Position to check</param>
    /// <returns>True if a collision does occur at the given position, False otherwise</returns>
    public bool IsCollision(Position pos) {
      int r = pos.y / SIZE;
      int c = pos.x / SIZE;
      return !PlayingField.GetInstance().IsEmpty(r, c);
    }
  }
}
