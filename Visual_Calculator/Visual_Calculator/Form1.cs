using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection.Emit;
using System.Resources;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Windows.Input;
using Visual_Calculator.Properties;
using NAudio.Wave;
namespace Visual_Calculator
{
    //--------------------------------------------------------------------

    //--------------------------------------------------------------------

    enum Calculator_Opertaions
    {
        none = -1,
        add = 0,
        subtract = 1,
        multiplicate = 2,
        divide = 3,
    }//Calculator_Opertaions
    enum Calculator_Current_Number
    {
        leftNumber = 0,
        rightNumber = 1,
    }//Calculator_Current_Number
    public partial class FrmCalculator : Form
    {
        double dblNum1, dblNum2, dblResult;
        Calculator_Opertaions _operation;
        Calculator_Current_Number ccn;
        bool numlock;
        private bool protectKeys;
        private void btnNumeric_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            apply_key(btn.Text);
        }//btnNumeric_Click
        private void apply_key(string t)
        {
            if (explosionactive)
            {
                lblNum1.Text += t;
            }
            else
            {
                lblDisplay.Text += t;
            }
        }//apply_key
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ccn == Calculator_Current_Number.leftNumber)
            {
                dblNum1 = double.Parse(lblDisplay.Text);
                lblNum1.Text = lblDisplay.Text;
                lblDisplay.Text = "";
                ccn = Calculator_Current_Number.rightNumber;
                _operation = Calculator_Opertaions.add;
                lblOperation.Text = "+";
            }//if left number
            else if (ccn == Calculator_Current_Number.rightNumber)
            {

            }//else if it is not left number
        }//btnAdd_Click

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (explosionactive == true)
            {
                if(lblNum1.Text == "25565")
                {
                    explosionactive = false;
                }
            }
            else
            {
                if (ccn == Calculator_Current_Number.rightNumber)
                {
                    dblNum2 = double.Parse(lblDisplay.Text);
                    lblNum2.Text = lblDisplay.Text;
                    switch (_operation)
                    {
                        case Calculator_Opertaions.none:
                            break;
                        case Calculator_Opertaions.add:
                            dblResult = dblNum1 + dblNum2;
                            break;
                        case Calculator_Opertaions.subtract:
                            dblResult = dblNum1 - dblNum2;
                            break;
                        case Calculator_Opertaions.multiplicate:
                            dblResult = dblNum1 * dblNum2;
                            break;
                        case Calculator_Opertaions.divide:
                            dblResult = dblNum1 / dblNum2;
                            break;
                        default:
                            break;
                    }//case

                    lblDisplay.Text = dblResult.ToString();
                    restartCalculator();
                }//if second number is entered 
            }
        }//btnEnter_Click

        private void restartCalculator()
        {
            dblNum1 = 0;
            dblNum2 = 0;
            dblResult = 0;
            ccn = Calculator_Current_Number.leftNumber;
            _operation = Calculator_Opertaions.none;
        }//restartCalculator

        private void btnMinus_Click(object sender, EventArgs e)
        {
            if (ccn == Calculator_Current_Number.leftNumber)
            {
                dblNum1 = double.Parse(lblDisplay.Text);
                lblNum1.Text = lblDisplay.Text;
                lblDisplay.Text = "";
                ccn = Calculator_Current_Number.rightNumber;
                _operation = Calculator_Opertaions.subtract;
                lblOperation.Text = "-";
            }//if left number
            else if (ccn == Calculator_Current_Number.rightNumber)
            {

            }//else if it is not left number
        }//btnMinus_Click

        private void btnMultiplicate_Click(object sender, EventArgs e)
        {
            if (ccn == Calculator_Current_Number.leftNumber)
            {
                dblNum1 = double.Parse(lblDisplay.Text);
                lblNum1.Text = lblDisplay.Text;
                lblDisplay.Text = "";
                ccn = Calculator_Current_Number.rightNumber;
                _operation = Calculator_Opertaions.multiplicate;
                lblOperation.Text = "X";
            }//if left number
            else if (ccn == Calculator_Current_Number.rightNumber)
            {

            }//else if it is not left number
        }//btnMultiplicate_Click

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (ccn == Calculator_Current_Number.leftNumber)
            {
                dblNum1 = double.Parse(lblDisplay.Text);
                lblNum1.Text = lblDisplay.Text;
                lblDisplay.Text = "";
                ccn = Calculator_Current_Number.rightNumber;
                _operation = Calculator_Opertaions.divide;
                lblOperation.Text = "/";
            }//if left number
            else if (ccn == Calculator_Current_Number.rightNumber)
            {

            }//else if it is not left number
        }//btnDivide_Click

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (explosionactive == false)
            {
                lblDisplay.Text = "";
                lblNum1.Text = "";
                lblNum2.Text = "";
                lblOperation.Text = "";
                restartCalculator();
            }
            else {
                lblNum1.Text = "";
                lblNum2.Text = "";
                lblOperation.Text = "";
                restartCalculator();
            }
        }//btnClear_Click

        private void FrmCalculator_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {

                case Keys.Back:
                    btnBackSpace_Click(sender, e);
                    break;
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    btnEnter_Click(sender, e);
                    break;
                case Keys.Escape:
                    btnClear_Click(sender, e);
                    break;
                case Keys.D0:
                    apply_key("0");
                    break;
                case Keys.D1:
                    apply_key("1");
                    break;
                case Keys.D2:
                    apply_key("2");
                    break;
                case Keys.D3:
                    apply_key("3");
                    break;
                case Keys.D4:
                    apply_key("4");
                    break;
                case Keys.D5:
                    apply_key("5");
                    break;
                case Keys.D6:
                    apply_key("6");
                    break;
                case Keys.D7:
                    apply_key("7");
                    break;
                case Keys.D8:
                    apply_key("8");
                    break;
                case Keys.D9:
                    apply_key("9");
                    break;
                case Keys.NumPad0:
                    apply_key("0");
                    break;
                case Keys.NumPad1:
                    apply_key("1");
                    break;
                case Keys.NumPad2:
                    apply_key("2");
                    break;
                case Keys.NumPad3:
                    apply_key("3");
                    break;
                case Keys.NumPad4:
                    apply_key("4");
                    break;
                case Keys.NumPad5:
                    apply_key("5");
                    break;
                case Keys.NumPad6:
                    apply_key("6");
                    break;
                case Keys.NumPad7:
                    apply_key("7");
                    break;
                case Keys.NumPad8:
                    apply_key("8");
                    break;
                case Keys.NumPad9:
                    apply_key("0");
                    break;
                case Keys.Multiply:
                    break;
                case Keys.Add:
                    btnAdd_Click(sender, e);
                    break;
                case Keys.Subtract:
                    btnMinus_Click(sender, e);
                    break;
                case Keys.Decimal:
                    break;
                case Keys.Divide:
                    break;
                case Keys.NumLock:
                    if (numlock)
                    {
                        btnNumLock.BackColor = btn0.BackColor;
                        numlock = false;
                    }//if num lock is on 
                    else
                    {
                        btnNumLock.BackColor = Color.Green;
                        numlock = true;
                    }//else if numLock is off
                    break;
                case Keys.Oem1:
                    break;
                case Keys.Oem2:
                    break;
                case Keys.Oem3:
                    break;
                case Keys.Oem4:
                    break;
                case Keys.Oem5:
                    break;
                case Keys.Oem6:
                    break;
                case Keys.Oem7:
                    break;
                case Keys.Oem8:
                    break;
                default:
                    break;
            }
        }//FrmCalculator_KeyDown


        private void btnNumLock_Click(object sender, EventArgs e)
        {
            if (protectKeys)
                return;
            protectKeys = true;
            NativeMethods.SimulateKeyPress(NativeMethods.VK_NUMLOCK);
            protectKeys = false;
        }//btnNumLock_Click

        private void btnBackSpace_Click(object sender, EventArgs e)
        {
            if (explosionactive == false)
            {
                if (lblDisplay.Text.Length > 0)
                {
                    string strTmp = "";
                    for (int i = 0; i < lblDisplay.Text.Length - 1; i++)
                    {
                        strTmp += lblDisplay.Text[i];
                    }//for
                    lblDisplay.Text = strTmp;
                }//if there is number in lblDisplay
            }
            else
            {
                if (lblNum1.Text.Length > 0)
                {
                    string strTmp = "";
                    for (int i = 0; i < lblNum1.Text.Length - 1; i++)
                    {
                        strTmp += lblNum1.Text[i];
                    }//for
                    lblNum1.Text = strTmp;
                }//if there is number in lblNum1
            }
        }//btnBackSpace_Click

        private void FrmCalculator_Enter(object sender, EventArgs e)
        {

        }//FrmCalculator_EnterFrmCalculator_Enter

        private void FrmCalculator_KeyPress(object sender, KeyPressEventArgs e)
        {

        }//FrmCalculator_KeyPress

        public class LoopStream : WaveStream
        {
            WaveStream sourceStream;

            /// <summary>
            /// Creates a new Loop stream
            /// </summary>
            /// <param name="sourceStream">The stream to read from. Note: the Read method of this stream should return 0 when it reaches the end
            /// or else we will not loop to the start again.</param>
            public LoopStream(WaveStream sourceStream)
            {
                this.sourceStream = sourceStream;
                this.EnableLooping = true;
            }

            /// <summary>
            /// Use this to turn looping on or off
            /// </summary>
            public bool EnableLooping { get; set; }

            /// <summary>
            /// Return source stream's wave format
            /// </summary>
            public override WaveFormat WaveFormat
            {
                get { return sourceStream.WaveFormat; }
            }

            /// <summary>
            /// LoopStream simply returns
            /// </summary>
            public override long Length
            {
                get { return sourceStream.Length; }
            }

            /// <summary>
            /// LoopStream simply passes on positioning to source stream
            /// </summary>
            public override long Position
            {
                get { return sourceStream.Position; }
                set { sourceStream.Position = value; }
            }

            public override int Read(byte[] buffer, int offset, int count)
            {
                int totalBytesRead = 0;

                while (totalBytesRead < count)
                {
                    int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                    if (bytesRead == 0)
                    {
                        if (sourceStream.Position == 0 || !EnableLooping)
                        {
                            // something wrong with the source stream
                            break;
                        }
                        // loop
                        sourceStream.Position = 0;
                    }
                    totalBytesRead += bytesRead;
                }
                return totalBytesRead;
            }
        }


        private System.Windows.Forms.Timer countdownTimer;
        private System.Windows.Forms.Timer countdownTimer2;
        private int timeRemaining;
        private int timeRemaining2;
        //audio
        private WaveOut waveOut;
        private WaveOut waveOut2;
        private WaveOut waveOut3;

        bool explosionactive = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (explosionactive == false)
            {
                explosionactive = true;
                //colors and display
                lblDisplay.ForeColor = Color.Red;
                lblDisplay.Font = new Font(lblDisplay.Font, FontStyle.Bold);
                lblNum1.ForeColor = Color.Lime;
                lblNum1.Font = new Font(lblNum1.Font, FontStyle.Bold);
                lblNum1.Text = "";
                //disable uneeded stuff
                lblNum2.Visible = false;
                lblOperation.Visible = false;

                countdownTimer = new System.Windows.Forms.Timer();
                countdownTimer.Interval = 1000; // 1000 ms = 1 second
                countdownTimer.Tick += CountdownTimer_Tick;

                timeRemaining = 60;
                lblDisplay.Text = timeRemaining.ToString();
                countdownTimer.Start();

                //audio
                if (waveOut == null)
                {
                    WaveFileReader reader = new WaveFileReader(Resources.tick);
                    LoopStream loop = new LoopStream(reader);
                    waveOut = new WaveOut();
                    waveOut.Init(loop);
                    waveOut.Play();
                }
                else
                {
                    waveOut.Stop();
                    waveOut.Dispose();
                    waveOut = null;
                }
                if (waveOut2 == null)
                {
                    WaveFileReader reader2 = new WaveFileReader(Resources.nuclearsiren);
                    LoopStream loop2 = new LoopStream(reader2);
                    waveOut2 = new WaveOut();
                    waveOut2.Init(loop2);
                    waveOut2.Play();
                }
                else
                {
                    waveOut2.Stop();
                    waveOut2.Dispose();
                    waveOut2 = null;
                }

            }
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            if (timeRemaining > 0)
            {
                if (explosionactive == true)
                {
                    timeRemaining--;
                    lblDisplay.Text = timeRemaining.ToString();
                }
                else
                {
                    //audiostop
                    waveOut.Stop();
                    waveOut.Dispose();
                    waveOut = null;
                    waveOut2.Stop();
                    waveOut2.Dispose();
                    waveOut2 = null;

                    //audiodefuse
                    WaveFileReader reader3 = new WaveFileReader(Resources.defuse);
                    waveOut3 = new WaveOut();
                    waveOut3.Init(reader3);
                    waveOut3.Play();
                    //timerstop
                    countdownTimer.Stop();
                    //seteverythingback
                    lblDisplay.ForeColor = Color.Black;
                    lblDisplay.Font = new Font(lblDisplay.Font, FontStyle.Regular);
                    lblNum1.ForeColor = Color.Black;
                    lblNum1.Font = new Font(lblNum1.Font, FontStyle.Regular);

                    lblDisplay.Text = "";
                    lblNum1.Text = "";
                    lblNum2.Visible = true;
                    lblOperation.Visible = true;
                }
            }
            else
            {
                //audiostop
                waveOut.Stop();
                waveOut.Dispose();
                waveOut = null;
                waveOut2.Stop();
                waveOut2.Dispose();
                waveOut2 = null;

                //audioexplode
                WaveFileReader reader3 = new WaveFileReader(Resources.nukeexplode);
                waveOut3 = new WaveOut();
                waveOut3.Init(reader3);
                waveOut3.Play();

                countdownTimer.Stop();
                // show explode
                Form2 frm = new Form2();

                frm.Show();
                //close after 5 seconds
                timeRemaining2 = 5;
                countdownTimer2 = new System.Windows.Forms.Timer();
                countdownTimer2.Interval = 1000; // 1000 ms = 1 second
                countdownTimer2.Tick += CountdownTimer_Closer;
                countdownTimer2.Start();


            }
        }
        private void CountdownTimer_Closer(object sender, EventArgs e) {
            if (timeRemaining2 > 0)
            {
                timeRemaining2--;
            }
            else {
                Application.Exit();
            }
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Resources.emojis_com_nuke;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Resources.emojis_com_nukeshadow2;
        }

        private void FrmCalculator_Load(object sender, EventArgs e)
        {
            dblNum1 = 0;
            dblNum2 = 0;
            dblResult = 0;
            _operation = Calculator_Opertaions.none;
            ccn = Calculator_Current_Number.leftNumber;
            if (Control.IsKeyLocked(Keys.NumLock))
            {
                btnNumLock.BackColor = Color.Green;
                numlock = true;
            }//if  Num Lock is On 
            btnEnter.Focus();
        }//FrmCalculator_Load

        public FrmCalculator()
        {
            InitializeComponent();
        }//FrmCalculator
    }//Form

    public static class NativeMethods
    {
        public const byte VK_NUMLOCK = 0x90;
        public const uint KEYEVENTF_EXTENDEDKEY = 1;
        public const int KEYEVENTF_KEYUP = 0x2;

        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, int dwExtraInfo);

        public static void SimulateKeyPress(byte keyCode)
        {
            keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY, 0);
            keybd_event(VK_NUMLOCK, 0x45, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, 0);
        }
    }


}//Visual_Calculator