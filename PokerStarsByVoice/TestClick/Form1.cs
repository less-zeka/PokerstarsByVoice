using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestClick
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoMouseClick();
        }

        private void DoMouseClick()
        {
            var mousePoint = new MouseOperations.MousePoint(int.Parse(txtX.Text), int.Parse(txtY.Text));
            MouseOperations.SetCursorPosition(mousePoint);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);

        }

        private void DoMouseClick(int x, int y)
        {
            MouseOperations.SetCursorPosition(x, y);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftDown);
            MouseOperations.MouseEvent(MouseOperations.MouseEventFlags.LeftUp);
        }

        private void foldButton_Click(object sender, EventArgs e)
        {
            var x = 450;
            var y = 530;
            DoMouseClick(x, y);
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            var x = 550;
            var y = 530;           
            DoMouseClick(x, y);
        }

        private void raise_Click(object sender, EventArgs e)
        {
            var x = 750;
            var y = 530;           
            DoMouseClick(x, y);
        }
    }
}
