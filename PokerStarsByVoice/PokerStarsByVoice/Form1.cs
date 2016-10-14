using System;
using System.Speech.Recognition;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerStarsByVoice
{
    public partial class Form1 : Form
    {
        private const string Fold = "fold";
        private const string Check = "check";
        private const string Raise = "raise";

        public Form1()
        {
            InitializeComponent();

            InitializeSpeechRecognizer();
            
        }

        private void InitializeSpeechRecognizer()
        {
            SpeechRecognizer sr = new SpeechRecognizer();

            Choices actions = new Choices();
            actions.Add(new string[] { Fold, Check, Raise });

            GrammarBuilder gb = new GrammarBuilder ();
            gb.Append(actions);

            // Create the Grammar instance.
            Grammar g = new Grammar(gb);

            sr.LoadGrammar(g);

            sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);
        }

        void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var recognized = e.Result.Text;
            lblRecognizedString.Text = recognized;
            if(recognized == Fold)
            {
                this.Cursor = new Cursor(Cursor.Current.Handle);
                Cursor.Position = new Point(x: 200, y: 200);
                DoMouseClick();
                
            }
            if(recognized == Check)
            {
                this.Cursor = new Cursor(Cursor.Current.Handle);
                Cursor.Position = new Point(x: 300, y: 200);
                DoMouseClick();
            }
            if (recognized == Raise)
            {
                this.Cursor = new Cursor(Cursor.Current.Handle);
                Cursor.Position = new Point(x: 500, y: 200);
                DoMouseClick();
            }
        }

        public void DoMouseClick()
        {
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
            
        }
    }
}
