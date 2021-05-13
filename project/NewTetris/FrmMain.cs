﻿using NewTetris.Properties;
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
      game = new Game();
      Game.field = lblPlayingField;
      Game.NextBox = grpNextBlock;
      game.NextShape();
    }

    private void tmrCurrentPieceFall_Tick(object sender, EventArgs e) {
      if (Game.curShape != null) {
        if (!Game.curShape.TryMoveDown()) {
          Game.curShape.DissolveIntoField();
          Game.curShape = null;
          if (!Game.IsGameOver) {
            game.NextShape();
          } else {


            tmrCurrentPieceFall.Enabled = false;
            Quit.Visible = true;
            GameOverText.Visible = true;


            // TODO: HERE IS WHERE WE SET THE FINAL SCORE LATER
            // GameOverText.Text = Score;

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

    }
    private void Quit_Click(object sender, EventArgs e) {

      this.Close();

    }
  }
}
