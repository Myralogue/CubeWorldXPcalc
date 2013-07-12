using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CWxp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int Level;
        int LevelB;
        double Experience;
        int Experiencelvl;
        double TotalXP;
        int TotalXPlvl;
        double Power;
        int Powerlvl;
        double AtoB;
        int AtoBlvl;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Level = Convert.ToInt32(textBox1.Text);
                if (Level > 0) { Calc(); }
                else { MessageBox.Show("Your level can't be less then 1"); textBox1.Text = ""; }
                
            }
            catch
            {
                MessageBox.Show("Only fill in number'sss", "Error");
                textBox1.Text = "";
            }
        }
        public void Calc()
        {
            //Xp for this level
            Experience = (1050 * Level - 50) / (Level + 19);
            Experiencelvl = Convert.ToInt32(Experience);
            if (Experiencelvl < Experience) { Experiencelvl++; }
            label1.Text = ("XP in level (A):   " + Experiencelvl.ToString());
            
            //Total XP
            TotalXP = 50*(21*(Level-1)+400* Math.Log(20)-400*Math.Log(19 + Level));
            TotalXPlvl = Convert.ToInt32(TotalXP);
            if (TotalXPlvl < TotalXP) { TotalXPlvl++; }
            label2.Text = ("Total XP till (A):  " + TotalXPlvl.ToString());

            //Power level
            Power = 100 - 99 * ((1 + 0.0536) / (1 + 0.0536 * Level));
            Powerlvl = Convert.ToInt32(Power);
            if (Powerlvl < Power) { Powerlvl++; }    
            label3.Text = ("Power level (A):  " + Powerlvl.ToString());

            //(A) to (B)
            if (textBox2.Text != "")
            {
                try
                {

                    LevelB = Convert.ToInt32(textBox2.Text);
                    if (LevelB < 0) { MessageBox.Show("Your level can't be less then 1"); textBox2.Text = ""; }
                    AtoB = 50 * (21 * (LevelB - Level) + 400 * Math.Log(19 + Level) - 400 * Math.Log(19 + LevelB));
                    AtoBlvl = Convert.ToInt32(AtoB);
                    if (AtoBlvl < AtoB) { AtoBlvl++; } 
                    label6.Text = ("XP (A) to (B):      " + AtoBlvl.ToString()); 


                }                   
                catch
                {
                    MessageBox.Show("Only fill in number's", "Error");
                    textBox2.Text = "";
                }
                
            }
            else { label6.Text = ("XP (A) to (B): "); }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Level++;
            textBox1.Text = (Level.ToString());
            Calc();
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((Level - 1) > 1)
            {
                Level--;
                textBox1.Text = (Level.ToString());
                Calc();
            }
            else { MessageBox.Show("Your level can't be less then 1"); }

        }

    }
}
