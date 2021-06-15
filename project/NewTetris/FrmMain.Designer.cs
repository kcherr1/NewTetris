namespace NewTetris {
  partial class FrmMain {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      this.lblPlayingField = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.lblLevel = new System.Windows.Forms.Label();
      this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
      this.grpNextBlock = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.grpStoreBlock = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
      this.tmrCurrentPieceFall = new System.Windows.Forms.Timer(this.components);
      this.GameOverText = new System.Windows.Forms.Label();
      this.Quit = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // lblPlayingField
      // 
      this.lblPlayingField.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
      this.lblPlayingField.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.lblPlayingField.Location = new System.Drawing.Point(397, 89);
      this.lblPlayingField.Name = "lblPlayingField";
      this.lblPlayingField.Size = new System.Drawing.Size(450, 660);
      this.lblPlayingField.TabIndex = 7;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.label2.Location = new System.Drawing.Point(18, 165);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(76, 25);
      this.label2.TabIndex = 8;
      this.label2.Text = "Lines Cleared:";
      // 
      // lblLevel
      // 
      this.lblLevel.AutoSize = true;
      this.lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblLevel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.lblLevel.Location = new System.Drawing.Point(185, 165);
      this.lblLevel.Name = "lblLevel";
      this.lblLevel.Size = new System.Drawing.Size(42, 25);
      this.lblLevel.TabIndex = 10;
      this.lblLevel.Text = "0";
      //
      //label5 is our actually score points, and where they are displayed and updated to.
      //
      this.label5.AutoSize = true;
      this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.label5.Location = new System.Drawing.Point(970, 165);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(76, 25);
      this.label5.TabIndex = 8;
      this.label5.Text = "0";
      //
      //label6 is our Score label
      //
      this.label6.AutoSize = true;
      this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.label6.Location = new System.Drawing.Point(860, 165);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(76, 25);
      this.label6.TabIndex = 8;
      this.label6.Text = "Score:";
       //
       //Contorls label that displays the controls
       //
       this.label7.AutoSize = true;
       this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
       this.label7.ForeColor = System.Drawing.SystemColors.ActiveCaption;
       this.label7.Location = new System.Drawing.Point(0,0);
       this.label7.Name = "label7";
       this.label7.Size = new System.Drawing.Size(76, 25);
       this.label7.TabIndex = 8;
       this.label7.Text = "Contorls:\r\nArrow keys = Movement\r\nStore Block = X\r\nRotate Block = S\r\nInstant Drop = Space Bar";
      //
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.label3.Location = new System.Drawing.Point(48, 231);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(132, 25);
      this.label3.TabIndex = 11;
      this.label3.Text = "Next Block:";
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
      this.label4.Location = new System.Drawing.Point(862, 231);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(132, 25);
      this.label4.TabIndex = 11;
      this.label4.Text = "Store Block:";
      // 
      // grpNextBlock
      // 
      this.grpNextBlock.BackColor = System.Drawing.Color.DimGray;
      this.grpNextBlock.Location = new System.Drawing.Point(186, 231);
      this.grpNextBlock.Name = "grpNextBlock";
      this.grpNextBlock.Size = new System.Drawing.Size(120, 550);
      this.grpNextBlock.TabIndex = 13;
      this.grpNextBlock.TabStop = false;
            //
            // grpStoreBlock
            //
            this.grpStoreBlock.BackColor = System.Drawing.Color.DimGray;
      this.grpStoreBlock.Location = new System.Drawing.Point(1000, 231);
      this.grpStoreBlock.Name = "grpStoreBlock";
      this.grpStoreBlock.Size = new System.Drawing.Size(120, 120);
      this.grpStoreBlock.TabIndex = 13;
      this.grpStoreBlock.TabStop = false;
      // 
      // tmrCurrentPieceFall
      // 
      this.tmrCurrentPieceFall.Enabled = true;
      this.tmrCurrentPieceFall.Interval = 500;
      this.tmrCurrentPieceFall.Tick += new System.EventHandler(this.tmrCurrentPieceFall_Tick);
      // 
      // GameOverText
      // 
      this.GameOverText.BackColor = System.Drawing.Color.DeepSkyBlue;
      this.GameOverText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
      this.GameOverText.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.GameOverText.Location = new System.Drawing.Point(454, 256);
      this.GameOverText.Name = "GameOverText";
      this.GameOverText.Size = new System.Drawing.Size(334, 339);
      this.GameOverText.TabIndex = 14;
      this.GameOverText.Text = "Game Over\r\nScore: TODO";
      this.GameOverText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      this.GameOverText.Visible = false;
      // 
      // Quit
      // 
      this.Quit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.Quit.Location = new System.Drawing.Point(547, 526);
      this.Quit.Name = "Quit";
      this.Quit.Size = new System.Drawing.Size(146, 38);
      this.Quit.TabIndex = 15;
      this.Quit.Text = "Quit";
      this.Quit.UseVisualStyleBackColor = true;
      this.Quit.Visible = false;
      this.Quit.Click += new System.EventHandler(this.Quit_Click);
      // 
      // FrmMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.Color.Black;
      this.ClientSize = new System.Drawing.Size(1183, 803);
      this.Controls.Add(this.Quit);
      this.Controls.Add(this.GameOverText);
      this.Controls.Add(this.grpNextBlock);
            this.Controls.Add(this.grpStoreBlock);
      this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
      this.Controls.Add(this.lblLevel);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.lblPlayingField);
      this.Name = "FrmMain";
      this.Text = "New Tetris 3.0";
      this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
      this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyUp);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion
    private System.Windows.Forms.Label lblPlayingField;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label lblLevel;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.GroupBox grpNextBlock;
        private System.Windows.Forms.GroupBox grpStoreBlock;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7; 
    private System.Windows.Forms.Timer tmrCurrentPieceFall;
    private System.Windows.Forms.Label GameOverText;
    private System.Windows.Forms.Button Quit;
  }
}

