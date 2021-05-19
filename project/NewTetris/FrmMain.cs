using NewTetris.Properties;
using NewTetris_Lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewTetris {
  public partial class FrmMain : Form {
    public Game game;

    public FrmMain() {
      InitializeComponent();
      Game.imgPiece = Resources.block_piece;
            Game.bluePiece = Resources.blue;
            Game.redPiece = Resources.red;
            Game.orangePiece = Resources.orange;
            Game.yellowPiece = Resources.yellow;
            Game.greenPiece = Resources.green;
            Game.cyanPiece = Resources.cyan;
      game = new Game();
      Game.field = lblPlayingField;
      Game.NextBox = grpNextBlock;
            PlayingField.lvlLabel = lblLevel;
            PlayingField.scoreing = label5;
            Game.StoreBox = grpStoreBlock;
            
            game.NextShape();
    }

    private void tmrCurrentPieceFall_Tick(object sender, EventArgs e) {
      if (Game.curShape != null) {
                tmrCurrentPieceFall.Interval = PlayingField.GetInstance().lvlspeed;
        if (!Game.curShape.TryMoveDown()) {
          Game.curShape.DissolveIntoField();
          Game.curShape = null;
          if (!Game.IsGameOver) {
            game.NextShape();
          } else {


            tmrCurrentPieceFall.Enabled = false;
            Quit.Visible = true;
            GameOverText.Visible = true;
                        GameOverText.Text = String.Concat("Game Over\r\n Score:",PlayingField.GetInstance().score.ToString());
          }
        }
      }
    }
    /// <summary>
    /// Events that involve the key being down
    /// Speeding up the game, moving
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FrmMain_KeyDown(object sender, KeyEventArgs e) {
      if (Game.IsGameOver) {
        return;
      }
      if (e.KeyCode == Keys.Down) {

         tmrCurrentPieceFall.Interval = 100;

      }
      else if (e.KeyCode == Keys.Left) {
         Game.curShape.TryMoveLeft();
      }
      else if (e.KeyCode == Keys.Right) {
         Game.curShape.TryMoveRight();
      }

      


     }
    /// <summary>
    /// Events that involve the keys to go up
    /// Normal speed, Rotations
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FrmMain_KeyUp(object sender, KeyEventArgs e) {
      if (Game.IsGameOver) {
        return;
      }
      if (e.KeyCode == Keys.A) {
        Game.curShape.RotateCCW();
      }
      else if (e.KeyCode == Keys.S) {
        Game.curShape.RotateCW();
      }
      
      else if(e.KeyCode == Keys.Down) {

         tmrCurrentPieceFall.Interval = 500;

      }

      else if (e.KeyCode == Keys.Space) {

        Game.curShape.DropShapeInstantly();
        game.NextShape();

      }
      else if (e.KeyCode == Keys.X)
            {
                game.storeShape();
            }

    }
    private void Quit_Click(object sender, EventArgs e) {

      this.Close();

    }
  }
}
