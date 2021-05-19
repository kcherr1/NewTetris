using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System.Windows.Forms;

namespace NewTetris_Lib {
  /// <summary>
  /// Encodes information about the playing
  /// field of the game. Uses a grid of rows
  /// and cols storing 1 for occupied and 0
  /// for vacant
  /// </summary>
  public class PlayingField {
    /// <summary>
    /// Singleton pattern instance
    /// </summary>
    private static PlayingField instance = null;

    /// <summary>
    /// Grid holding 1 for occupied, 0 for vacant
    /// </summary>
    public int[,] field;

        public static Control lvlLabel;
        public int level = 0;
        public static Control scoreing;
        public int score = 0;

    /// <summary>
    /// Observer pattern event for when a row is 
    /// cleared - currently unused
    /// </summary>
    public event Action OnRowClear;

    /// <summary>
    /// Default constructor initializing the field
    /// to 22 rows and 15 columns
    /// </summary>
    private PlayingField() {
      field = new int[22, 15];
    }

    /// <summary>
    /// Retrieves the Singleton pattern instance
    /// </summary>
    /// <returns>The Singleton instance</returns>
    public static PlayingField GetInstance() {
      if (instance == null) {
        instance = new PlayingField();
      }
      return instance;
    }

    /// <summary>
    /// Checks if a location in the field is empty (i.e. vacant)
    /// </summary>
    /// <param name="r">Row</param>
    /// <param name="c">Column</param>
    /// <returns>True if empty, False otherwise</returns>
    public bool IsEmpty(int r, int c) {
      if (r < 0 || r >= field.GetLength(0) || c < 0 || c >= field.GetLength(1)) {
        return false;
      }
     
      return field[r, c] == 0;
    }

    /// <summary>
    /// Obtains the row numbers of the rows to be cleared
    /// Goes through the appropriate rows and Removes the pieces
    /// It also moves any pieces above the row down
    /// </summary>
    public async Task clearRow() {

      List<int> rows = CheckClearAllRows();

      for (int i = 0; i < rows.Count; i++) {
        for (int j = 0; j < 15; j++) {
         
            Game.field.Controls.Remove(Shape.DissolvedPictureArray[rows[i], j].Pic);

            // Set that position to 0 and remove it
            Shape.DissolvedPictureArray[rows[i], j] = null;
            this.field[rows[i], j] = 0;

            // Animation in ms
            await Task.Delay(10);
          
          // Removes the Pieces
         

        }
      }
     movePiecesDown(rows, rows.Min());
     increaseLevel(rows.Count);
     increasescore(rows.Count);
    }

        public void increaseLevel(int i)
        {
            level += i;
            lvlLabel.Text = level.ToString();
        }

        public void increasescore(int i)
        {
            if (i == 1){
                score += 1;
            }
            if (i == 2)
            {
                score += 2;
            }
            if (i == 3)
            {
                score += 5;
            }
            if (i == 4)
            {
                score += 10;
            }
            scoreing.Text = score.ToString();
        }

    /// <summary>
    /// Moves pieces down by recursively going from the row above the cleared row
    /// all the way to the top
    /// </summary>
    public async void movePiecesDown(List<int> rows, int limit) {
      int pieceMoveCounter = 0;

      if (limit == 0) {
        return;
      }

      int i = limit;

          for (int j = 0; j < 15; j++) {

            if (this.field[i, j] == 1) {


          for (int k = 0; k < rows.Count; k++) {

          
            if(Shape.DissolvedPictureArray[i, j].CanMoveDown()) {
            Shape.DissolvedPictureArray[i, j].MoveDown();
            await Task.Delay(10);
            pieceMoveCounter++;

            }
          }

          Shape.DissolvedPictureArray[i + pieceMoveCounter, j] = Shape.DissolvedPictureArray[i, j];
              this.field[i + pieceMoveCounter, j] = 1;

              Shape.DissolvedPictureArray[i, j] = null;
              this.field[i, j] = 0;
              pieceMoveCounter = 0;

            }



          }

        
      movePiecesDown(rows, limit - 1);
    }

    /// <summary>
    /// Checks each row to see if any of them are filled and
    /// needs to be cleared, then clears those rows
    /// </summary>
    public List<int> CheckClearAllRows() {
      
      // Counts rows with all 1s in it
      // int count = 0;
      int count1s;
      List<int> rows = new List<int>();

      for (int i = 0; i < 22; i++) {
        count1s = 0;
        for (int j = 0; j < 15; j++) {

          if(this.field[i,j] == 1){

            count1s++;
              
          } 

          if(count1s == 15){

            rows.Add(i);

          }
          
        }
        
      }

      return rows;

    }


  }
}
