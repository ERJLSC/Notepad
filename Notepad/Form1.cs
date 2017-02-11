// Program written by: Erik Johnson
//       Program date: 10 Feb 2017
//Program description:  Chapter 4  extra credit
// Encountered issues: learning how to use the file dialogue properly.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
   
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtb.Text = "";
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtb.Cut();
            
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtb.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtb.Paste();
        }
 
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream;
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream = openFileDialog1.OpenFile()) != null)
                {
                    string filename = openFileDialog1.FileName;//copies the path of the file into a variable
                    string readfiletext = File.ReadAllText(filename);//reads all the text from the opened file
                    rtb.Text = readfiletext;// places file data into the rich text box
                }
            }
        }

        private void saveToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.Filter = "*.txt(textfile)|*.txt";
            if (savefile.ShowDialog() == DialogResult.OK)
            {
                rtb.SaveFile(savefile.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                // Set FontMustExist to true, which causes message box error
                // if the user enters a font that does not exist. 
                FontDialog1.FontMustExist = true;

                // Associate the method handling the Apply event with the event.
                FontDialog1.Apply += new System.EventHandler(FontDialog1_Apply);

                // Show the Apply button in the dialog.
                FontDialog1.ShowApply = true;

                // Do not show effects such as Underline
                // and Bold.
                FontDialog1.ShowEffects = false;

                // Save the existing font.
                System.Drawing.Font oldFont = this.Font;

                //Show the dialog, and get the result
                DialogResult result = FontDialog1.ShowDialog();

                // If the OK button in the Font dialog box is clicked, 
                // set all the controls' fonts to the chosen font by calling
                // the FontDialog1_Apply method.
                if (result == DialogResult.OK)
                {
                    FontDialog1_Apply(this.rtb, new System.EventArgs());
                }
                // If Cancel is clicked, set the font back to
                // the original font.
                else if (result == DialogResult.Cancel)
                {
                    this.Font = oldFont;
                    foreach (Control containedControl in this.Controls)
                    {
                        containedControl.Font = oldFont;
                    }
                }
            }
        }

        private void FontDialog1_Apply(object sender, System.EventArgs e)
        {
            // Handle the Apply event by setting all controls' fonts to 
            // the chosen font. 
            this.Font = FontDialog1.Font;
            foreach (Control containedControl in this.Controls)
            {
                rtb.Font = FontDialog1.Font;
            }

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Notepad by Erik Johnson", "Notepad",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}
