using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsInput;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace ConsoleApplication
{
    public class PokerPlayer
    {
        private const string Fold = "fold";
        private const string Check = "check";
        private const string Call = "call";
        private const string Raise = "raise";
        private const string processName = "Pokerstars";

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        public PokerPlayer()
        {
            InitializeSpeechRecognizer();
        }

        
        private void InitializeSpeechRecognizer()
        {
            SpeechRecognizer sr = new SpeechRecognizer();

            Choices actions = new Choices();
            actions.Add(new string[] { Fold, Check, Call, Raise });

            GrammarBuilder gb = new GrammarBuilder();
            gb.Append(actions);

            // Create the Grammar instance.
            Grammar g = new Grammar(gb);

            sr.LoadGrammar(g);

            sr.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(sr_SpeechRecognized);
        }

        void sr_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            var recognized = e.Result.Text ;

            Console.WriteLine(recognized + " " + e.Result.Confidence.ToString());
            if(e.Result.Confidence<0.8)
            {
                Console.WriteLine("not sure enough...");
                return;
            }
            var currentMousePosition = MouseOperations.GetCursorPosition();
            if (recognized == Fold)
            {
                MouseOperations.SetCursorPosition(450, 530);
                DoMouseClick();
            }
            else if (recognized == Check || recognized == Call)
            {
                MouseOperations.SetCursorPosition(550, 530);
                DoMouseClick();
            }
            else if (recognized == Raise)
            {
                MouseOperations.SetCursorPosition(750, 530);
                DoMouseClick();
            }
            else
            {
                Console.WriteLine("wtf: " + recognized);
            }
            //MouseOperations.SetCursorPosition(currentMousePosition);
        }

        public void DoMouseClick()
        {
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
        }
    }
}
