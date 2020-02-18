using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LittleGame
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public string LetztesZeichen = "o";

        public void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            // wenn das Feld schon ein Zeichen hat, dann abbrechen
            if (button.Text != null && button.Text != "")
                return;
            // wenn das letzte zeichen o ist, dann setzte ein x
            if(LetztesZeichen == "o")
            {
                // Macht das in einem Knopf x steht.
                button.Text = "x";
                //letztes zeichen ist ein x
                LetztesZeichen = "x";
            }
            else if(LetztesZeichen == "x")
            {
                // Macht das in einem Knopf O steht
                button.Text = "o";
                // Der macht, dass das Letztes zeichen, dass man gedrück hat ein O ist.
                LetztesZeichen = "o";
            }
            
            //Gewinnbedingung
            if(GewonnenVertikal() || GewonnenHorizontal() || GewonnenDiagonal())
            {
                Gewonnen.Text = "Spieler mit dem Zeichen " + LetztesZeichen + " hat gewonnen!";
                Gewonnen.IsVisible = true;
                Reset.IsVisible = true; ;
            } else if(FieldFull())
            {
                Gewonnen.Text = "Unentschieden";
                Gewonnen.IsVisible = true;
                Reset.IsVisible = true; ;
            }
        }

        private bool FieldFull()
        {
            if (!string.IsNullOrEmpty(btn0.Text)
                && !string.IsNullOrEmpty(btn1.Text)
                && !string.IsNullOrEmpty(btn2.Text)
                && !string.IsNullOrEmpty(btn3.Text)
                && !string.IsNullOrEmpty(btn4.Text)
                && !string.IsNullOrEmpty(btn5.Text)
                && !string.IsNullOrEmpty(btn6.Text)
                && !string.IsNullOrEmpty(btn7.Text)
                && !string.IsNullOrEmpty(btn8.Text))
            {
                return true;
            }
            return false;
        }

        private bool GewonnenDiagonal()
        {
            if(!string.IsNullOrEmpty(btn0.Text) && btn0.Text == btn4.Text && btn4.Text == btn8.Text)
            {
                return true;
            }
            else if(!string.IsNullOrEmpty(btn2.Text) && btn2.Text== btn4.Text && btn4.Text == btn6.Text)
            {
                return true;
            }
            return false;
        }

        private bool GewonnenVertikal()
        {
            if(!string.IsNullOrEmpty(btn0.Text) && btn0.Text == btn3.Text && btn3.Text == btn6.Text)
            {
                return true;
            }
            else if (!string.IsNullOrEmpty(btn1.Text) && btn1.Text == btn4.Text && btn4.Text == btn7.Text)
            {
                return true;
            }
            else if (!string.IsNullOrEmpty(btn2.Text) && btn2.Text == btn5.Text && btn5.Text == btn8.Text)
            {
                return true;
            }
            return false;
        }
        private bool GewonnenHorizontal()
        {
            if (!string.IsNullOrEmpty(btn0.Text) && btn0.Text == btn1.Text && btn1.Text == btn2.Text)
            {
                return true;
            }
            else if (!string.IsNullOrEmpty(btn3.Text) && btn3.Text == btn4.Text && btn4.Text == btn5.Text)
            {
                return true;
            }
            else if (!string.IsNullOrEmpty(btn6.Text) && btn6.Text == btn7.Text && btn7.Text == btn8.Text)
            {
                return true;
            }
            return false;
        }

        private void Reset_Clicked(object sender, EventArgs e)
        {
            btn0.Text = string.Empty;
            btn1.Text = string.Empty;
            btn2.Text = string.Empty;
            btn3.Text = string.Empty;
            btn4.Text = string.Empty;
            btn5.Text = string.Empty;
            btn6.Text = string.Empty;
            btn7.Text = string.Empty;
            btn8.Text = string.Empty;
            Gewonnen.IsVisible = false;
            Reset.IsVisible = false;
        }
    }
}
