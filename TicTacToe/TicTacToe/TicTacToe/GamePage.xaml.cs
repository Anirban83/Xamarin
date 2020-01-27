using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TicTacToe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GamePage : ContentPage
    {
        private bool turnO = true;
        private string[,] gridSelections = new string[3, 3];
        private int xwin, owin = 0;
        private int totalClicked = 0;
        public GamePage()
        {
            InitializeComponent();
            ResetAll();
        }

        private ImageSource CheckTurnForImage()
        {
            if (turnO)
            {
                turnO = false;
                return ImageSource.FromResource("TicTacToe.Images.ImageO.png");
            }
            else
            {
                turnO = true;
                return ImageSource.FromResource("TicTacToe.Images.ImageX.png");
            }
        }

        private void SetSelection(int rowIndex, int colIndex)
        {

            if (turnO)
            {
                gridSelections[rowIndex, colIndex] = "O";
            }
            else
            {
                gridSelections[rowIndex, colIndex] = "X";
            }
            Vibrate();
        }

        private void CheckWin()
        {
            bool win = false;
            //Check Rows
            if ((gridSelections[0, 0] == "X" && gridSelections[0, 1] == "X" && gridSelections[0, 2] == "X") ||
                (gridSelections[0, 0] == "O" && gridSelections[0, 1] == "O" && gridSelections[0, 2] == "O"))
            {
                win = true;
                imgBtn00.BackgroundColor = Color.LawnGreen;
                imgBtn01.BackgroundColor = Color.LawnGreen;
                imgBtn02.BackgroundColor = Color.LawnGreen;
            }
            if ((gridSelections[1, 0] == "X" && gridSelections[1, 1] == "X" && gridSelections[1, 2] == "X") ||
                (gridSelections[1, 0] == "O" && gridSelections[1, 1] == "O" && gridSelections[1, 2] == "O"))
            {
                win = true;
                imgBtn10.BackgroundColor = Color.LawnGreen;
                imgBtn11.BackgroundColor = Color.LawnGreen;
                imgBtn12.BackgroundColor = Color.LawnGreen;
            }
            if ((gridSelections[2, 0] == "X" && gridSelections[2, 1] == "X" && gridSelections[2, 2] == "X") ||
                (gridSelections[2, 0] == "O" && gridSelections[2, 1] == "O" && gridSelections[2, 2] == "O"))
            {
                win = true;
                imgBtn20.BackgroundColor = Color.LawnGreen;
                imgBtn21.BackgroundColor = Color.LawnGreen;
                imgBtn22.BackgroundColor = Color.LawnGreen;
            }

            //Check Columns
            if ((gridSelections[0, 0] == "X" && gridSelections[1, 0] == "X" && gridSelections[2, 0] == "X") ||
                (gridSelections[0, 0] == "O" && gridSelections[1, 0] == "O" && gridSelections[2, 0] == "O"))
            {
                win = true;
                imgBtn00.BackgroundColor = Color.LawnGreen;
                imgBtn10.BackgroundColor = Color.LawnGreen;
                imgBtn20.BackgroundColor = Color.LawnGreen;
            }
            if ((gridSelections[0, 1] == "X" && gridSelections[1, 1] == "X" && gridSelections[2, 1] == "X") ||
               (gridSelections[0, 1] == "O" && gridSelections[1, 1] == "O" && gridSelections[2, 1] == "O"))
            {
                win = true;
                imgBtn01.BackgroundColor = Color.LawnGreen;
                imgBtn11.BackgroundColor = Color.LawnGreen;
                imgBtn21.BackgroundColor = Color.LawnGreen;
            }
            if ((gridSelections[0, 2] == "X" && gridSelections[1, 2] == "X" && gridSelections[2, 2] == "X") ||
                (gridSelections[0, 2] == "O" && gridSelections[1, 2] == "O" && gridSelections[2, 2] == "O"))
            {
                win = true;
                imgBtn02.BackgroundColor = Color.LawnGreen;
                imgBtn12.BackgroundColor = Color.LawnGreen;
                imgBtn22.BackgroundColor = Color.LawnGreen;
            }

            //Check Diagonals
            if ((gridSelections[0, 0] == "X" && gridSelections[1, 1] == "X" && gridSelections[2, 2] == "X") ||
                (gridSelections[0, 0] == "O" && gridSelections[1, 1] == "O" && gridSelections[2, 2] == "O"))
            {
                win = true;
                imgBtn00.BackgroundColor = Color.LawnGreen;
                imgBtn11.BackgroundColor = Color.LawnGreen;
                imgBtn22.BackgroundColor = Color.LawnGreen;
            }
            if ((gridSelections[0, 2] == "X" && gridSelections[1, 1] == "X" && gridSelections[2, 0] == "X") ||
             (gridSelections[0, 2] == "O" && gridSelections[1, 1] == "O" && gridSelections[2, 0] == "O"))
            {
                win = true;
                imgBtn02.BackgroundColor = Color.LawnGreen;
                imgBtn11.BackgroundColor = Color.LawnGreen;
                imgBtn20.BackgroundColor = Color.LawnGreen;
            }

            if (win)
            {
                gridGame.IsEnabled = false;
                lblMsg.Text = "We have a winner !!";
                btnReset.IsVisible = true;

                if (turnO)
                {
                    xwin++;
                    lblPointX.Text = String.Format("Points for X : {0}" , xwin);
                }
                else
                {
                    owin++;
                    lblPointO.Text = String.Format("Points for O : {0}", owin);
                }

                Vibrate();
            }

            totalClicked++;
            if (totalClicked == 9)
            {
                gridGame.IsEnabled = false;
                lblMsg.Text = "Draw Game !!";
                btnReset.IsVisible = true;

                Vibrate();
            }

        }

        private void imgBtn00_Clicked(object sender, EventArgs e)
        {
            SetSelection(0, 0);
            imgBtn00.IsEnabled = false;
            imgBtn00.Source = CheckTurnForImage();
            CheckWin();
        }

        private void imgBtn01_Clicked(object sender, EventArgs e)
        {
            SetSelection(0, 1);
            imgBtn01.IsEnabled = false;
            imgBtn01.Source = CheckTurnForImage();
            CheckWin();
        }

        private void imgBtn02_Clicked(object sender, EventArgs e)
        {
            SetSelection(0, 2);
            imgBtn02.IsEnabled = false;
            imgBtn02.Source = CheckTurnForImage();
            CheckWin();
        }

        private void imgBtn10_Clicked(object sender, EventArgs e)
        {
            SetSelection(1, 0);
            imgBtn10.IsEnabled = false;
            imgBtn10.Source = CheckTurnForImage();
            CheckWin();
        }

        private void imgBtn11_Clicked(object sender, EventArgs e)
        {
            SetSelection(1, 1);
            imgBtn11.IsEnabled = false;
            imgBtn11.Source = CheckTurnForImage();
            CheckWin();
        }

        private void imgBtn12_Clicked(object sender, EventArgs e)
        {
            SetSelection(1, 2);
            imgBtn12.IsEnabled = false;
            imgBtn12.Source = CheckTurnForImage();
            CheckWin();
        }

        private void imgBtn20_Clicked(object sender, EventArgs e)
        {
            SetSelection(2, 0);
            imgBtn20.IsEnabled = false;
            imgBtn20.Source = CheckTurnForImage();
            CheckWin();
        }

        private void imgBtn21_Clicked(object sender, EventArgs e)
        {
            SetSelection(2, 1);
            imgBtn21.IsEnabled = false;
            imgBtn21.Source = CheckTurnForImage();
            CheckWin();
        }

        private void imgBtn22_Clicked(object sender, EventArgs e)
        {
            SetSelection(2, 2);
            imgBtn22.IsEnabled = false;
            imgBtn22.Source = CheckTurnForImage();
            CheckWin();
        }

        private void btnReset_Clicked(object sender, EventArgs e)
        {
            ResetAll();
        }

        private void ResetAll()
        {
            btnReset.IsVisible = false;
            gridGame.IsEnabled = true;
            lblMsg.Text = "Keep Calm and Play !!";
            totalClicked = 0;
            //turnO = true;
            gridSelections = new string[3, 3];

            imgBtn00.Source = ImageSource.FromResource("TicTacToe.Images.NoImage.png");
            imgBtn00.BackgroundColor = Color.Transparent;
            imgBtn00.IsEnabled = true;
            imgBtn01.Source = ImageSource.FromResource("TicTacToe.Images.NoImage.png");
            imgBtn01.BackgroundColor = Color.Transparent;
            imgBtn01.IsEnabled = true;
            imgBtn02.Source = ImageSource.FromResource("TicTacToe.Images.NoImage.png");
            imgBtn02.BackgroundColor = Color.Transparent;
            imgBtn02.IsEnabled = true;

            imgBtn10.Source = ImageSource.FromResource("TicTacToe.Images.NoImage.png");
            imgBtn10.BackgroundColor = Color.Transparent;
            imgBtn10.IsEnabled = true;
            imgBtn11.Source = ImageSource.FromResource("TicTacToe.Images.NoImage.png");
            imgBtn11.BackgroundColor = Color.Transparent;
            imgBtn11.IsEnabled = true;
            imgBtn12.Source = ImageSource.FromResource("TicTacToe.Images.NoImage.png");
            imgBtn12.BackgroundColor = Color.Transparent;
            imgBtn12.IsEnabled = true;

            imgBtn20.Source = ImageSource.FromResource("TicTacToe.Images.NoImage.png");
            imgBtn20.BackgroundColor = Color.Transparent;
            imgBtn20.IsEnabled = true;
            imgBtn21.Source = ImageSource.FromResource("TicTacToe.Images.NoImage.png");
            imgBtn21.BackgroundColor = Color.Transparent;
            imgBtn21.IsEnabled = true;
            imgBtn22.Source = ImageSource.FromResource("TicTacToe.Images.NoImage.png");
            imgBtn22.BackgroundColor = Color.Transparent;
            imgBtn22.IsEnabled = true;

            Vibrate();

        }

        private void Vibrate()
        {
            try
            {
                // Use default vibration length
                Vibration.Vibrate();

                // Or use specified time
                var duration = TimeSpan.FromSeconds(1);
                Vibration.Vibrate(duration);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }
    }
}