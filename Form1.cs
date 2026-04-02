using System;
using System.Drawing;
using System.Windows.Forms;
using XO_Game_Final.Properties;

namespace XO_Game_Final
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }

        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;

        enum enPlayer
        {
            Player1,
            Player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;

        }
      
        public bool CheckValues(Button btn1, Button btn2, Button btn3)
        {

            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {

                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

            }
            
            GameStatus.GameOver = false;
            return false;


        }

        void EndGame()
        {

            lblTurn.Text = "Game Over";
            
            switch (GameStatus.Winner)
            {
                case enWinner.Player1:
                       lblWinner.Text = "Player1";
                        break;
                   
                case enWinner.Player2:
                        lblWinner.Text = "Player2";
                        break;

                default:
                        lblWinner.Text = "Draw";
                        break;
            }
            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ButtonEnabled();
        }

        public void  CheckWinner()
        {
            if (CheckValues(button1, button2, button3))
             return;

            if (CheckValues(button4, button5, button6))
                return;

            if (CheckValues(button7, button8, button9))
                return;

            if (CheckValues(button1, button4, button7))
                return;

            if (CheckValues(button2, button5, button8))
                return;

            if (CheckValues(button3, button6, button9))
                return;

            if (CheckValues(button1, button5, button9))
                return;

            if (CheckValues(button3, button5, button7))
                return;

        }

        public void ChangeImage(Button btn)
        {

            if (btn.Tag.ToString()=="?")
            {
                switch (PlayerTurn)
                {
                    case enPlayer.Player1:
                        btn.Image = Resources.X;
                        PlayerTurn= enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatus.PlayCount++;
                        btn.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        btn.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        btn.Tag = "O";
                        CheckWinner();
                        break;
                }
            }
            
            else

            {
                MessageBox.Show("Wrong Choice","Wrong",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

            if(GameStatus.PlayCount ==9)
            {
                GameStatus.GameOver = true;
                GameStatus.Winner = enWinner.Draw;
                EndGame();
            }
           
          
        }

        void ButtonEnabled(bool Checked=false)
        {
            button1.Enabled=Checked;
            button2.Enabled=Checked;
            button3.Enabled=Checked;
            button4.Enabled=Checked;
            button5.Enabled=Checked;
            button6.Enabled=Checked;
            button7.Enabled=Checked;
            button8.Enabled=Checked;
            button9.Enabled=Checked;

        }

        private void button_Click(object sender, EventArgs e)
        {

            ChangeImage((Button)sender);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
              lblTurn.ForeColor = Color.BurlyWood; 
            
        }

        private void RestButton(Button btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;
            ButtonEnabled(true);
            
        }
        private void RestartGame()
        {

            RestButton(button1);
            RestButton(button2);
            RestButton(button3);
            RestButton(button4);
            RestButton(button5);
            RestButton(button6);
            RestButton(button7);
            RestButton(button8);
            RestButton(button9);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            GameStatus.PlayCount =0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            lblWinner.Text = "In Progress";

        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            RestartGame();

        }

       
        private void Form1_Paint(object sender, PaintEventArgs e)
        {

            Color white = Color.FromArgb(255, 180, 100,200);
            Pen whitePen = new Pen(white);
            whitePen.Width = 15;
            whitePen.StartCap = System.Drawing.Drawing2D.LineCap.Custom;
            whitePen.EndCap = System.Drawing.Drawing2D.LineCap.Custom;


            e.Graphics.DrawLine(whitePen, 586, 146, 586, 523);
            e.Graphics.DrawLine(whitePen, 760, 146, 760, 523);

            e.Graphics.DrawLine(whitePen, 420, 270, 927, 270);
            e.Graphics.DrawLine(whitePen, 420, 400, 927, 400);


        }

    
    }
}
