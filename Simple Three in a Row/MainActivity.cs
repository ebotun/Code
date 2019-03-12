using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Threeinarow
{
    [Activity(Label = "ThreeInARow", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public static Button btn;
        public static int[] table;
        public static TextView txtNumber1;
        public static TextView txtNumber2;
        public static TextView txtNumber3;
        public static TextView txtNumber4;
        public static TextView txtNumber5;
        public static TextView txtNumber6;
        public static TextView txtNumber7;
        public static TextView txtNumber8;
        public static TextView txtNumber9;
        public static TextView player;
        public static Button btnData;
        public static Machine machine;
        public static TextView winner;
        public static TextView scorex;
        public static TextView scoreo;
        public static bool playwinner = false;
        public static int rewardx = 0;
        public static int rewardo = 0;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            table = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            machine = new Machine();
            txtNumber1 = FindViewById<TextView>(Resource.Id.txt1);
            txtNumber2 = FindViewById<TextView>(Resource.Id.txt2);
            txtNumber3 = FindViewById<TextView>(Resource.Id.txt3);
            txtNumber4 = FindViewById<TextView>(Resource.Id.txt4);
            txtNumber5 = FindViewById<TextView>(Resource.Id.txt5);
            txtNumber6 = FindViewById<TextView>(Resource.Id.txt6);
            txtNumber7 = FindViewById<TextView>(Resource.Id.txt7);
            txtNumber8 = FindViewById<TextView>(Resource.Id.txt8);
            txtNumber9 = FindViewById<TextView>(Resource.Id.txt9);
            scorex = FindViewById<TextView>(Resource.Id.scorex);
            scoreo = FindViewById<TextView>(Resource.Id.scoreo);
            winner = FindViewById<TextView>(Resource.Id.winner);
            player = FindViewById<TextView>(Resource.Id.player);
            btn = FindViewById<Button>(Resource.Id.btn);
            //btnData = FindViewById<Button>(Resource.Id.btnData);
            //player.Click += (o, e) => player.Text = NxtPlayer(player.Text);
            txtNumber1.Click += (o, e) => ChosePos(ref txtNumber1, player.Text, 0, 1);
            txtNumber2.Click += (o, e) => ChosePos(ref txtNumber2, player.Text, 1, 1);
            txtNumber3.Click += (o, e) => ChosePos(ref txtNumber3, player.Text, 2, 1);
            txtNumber4.Click += (o, e) => ChosePos(ref txtNumber4, player.Text, 3, 1);
            txtNumber5.Click += (o, e) => ChosePos(ref txtNumber5, player.Text, 4, 1);
            txtNumber6.Click += (o, e) => ChosePos(ref txtNumber6, player.Text, 5, 1);
            txtNumber7.Click += (o, e) => ChosePos(ref txtNumber7, player.Text, 6, 1);
            txtNumber8.Click += (o, e) => ChosePos(ref txtNumber8, player.Text, 7, 1);
            txtNumber9.Click += (o, e) => ChosePos(ref txtNumber9, player.Text, 8, 1);
            btn.Click += (o, e) => ResetBtn(ref txtNumber1, ref txtNumber2, ref txtNumber3, ref txtNumber4, ref txtNumber5, ref txtNumber6, ref txtNumber7, ref txtNumber8, ref txtNumber9);

        }
        public static void ResetBtn(ref TextView txt1, ref TextView txt2, ref TextView txt3, ref TextView txt4, ref TextView txt5, ref TextView txt6, ref TextView txt7, ref TextView txt8, ref TextView txt9)
        {
            txt1.Text = "";
            txt1.Enabled = true;
            txt2.Text = "";
            txt2.Enabled = true;
            txt3.Text = "";
            txt3.Enabled = true;
            txt4.Text = "";
            txt4.Enabled = true;
            txt5.Text = "";
            txt5.Enabled = true;
            txt6.Text = "";
            txt6.Enabled = true;
            txt7.Text = "";
            txt7.Enabled = true;
            txt8.Text = "";
            txt8.Enabled = true;
            txt9.Text = "";
            txt9.Enabled = true;
            table = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            winner.Text = "";
            playwinner = false;
            //btn.Enabled = false;
        }

        /*public static string NxtPlayer(string player)
        {
            if (player == "x")
            {
                return "o";
            }
            else
            {
                return "x";
            }

        }*/
        public static void ChosePos(ref TextView txt, string player, int placement, int who)
        {
            if (playwinner != true)
            {
                txt.Text = player;
                table[placement] = who;
                txt.Enabled = false;
                
                if (who == 1 && playwinner != true)
                {
                    Winner();
                    if(playwinner != true)
                    {
                        table = machine.MachineChoice(table);
                        updateTable();
                    }
                    
                    Winner();
                }
            }



        }
        public static void Winner()
        {
            
            int[] i = table;
            int player = 0;
            if (i[0] == i[1] && i[1] == i[2] && i[0] != 0)
            {
                player = i[0];
            }
            else if (i[3] == i[4] && i[4] == i[5] && i[3] != 0)
            {
                player = i[3];
            }
            else if (i[6] == i[7] && i[7] == i[8] && i[6] != 0)
            {
                player = i[6];
            }
            else if (i[0] == i[3] && i[3] == i[6] && i[0] != 0)
            {
                player = i[0];
            }
            else if (i[1] == i[4] && i[4] == i[7] && i[1] != 0)
            {
                player = i[1];
            }
            else if (i[2] == i[5] && i[5] == i[8] && i[2] != 0)
            {
                player = i[2];
            }
            else if (i[0] == i[4] && i[4] == i[8] && i[0] != 0)
            {
                player = i[0];
            }
            else if (i[2] == i[4] && i[4] == i[6] && i[2] != 0)
            {
                player = i[2];
            }
            if (!table.Contains(0) || player > 0)
            {
                txtNumber1.Enabled = false;
                txtNumber2.Enabled = false;
                txtNumber3.Enabled = false;
                txtNumber4.Enabled = false;
                txtNumber5.Enabled = false;
                txtNumber6.Enabled = false;
                txtNumber7.Enabled = false;
                txtNumber8.Enabled = false;
                txtNumber9.Enabled = false;
                if (player == 1)
                {
                    winner.Text = "Player X Won";
                    scorex.Text = (++rewardx).ToString();
                    playwinner = true;
                }
                else if (player == 2)
                {
                    winner.Text = "Player O Won";
                    scoreo.Text = (++rewardo).ToString();
                    playwinner = true;
                }
                else
                {
                    winner.Text = "Draw";
                    playwinner = true;
                }
                
           
            }
                

            
        }
        public static void updateTable()
        {
            for (int i = 0; i < table.Length; i++)
            {

                if (table[i] == 2)
                {
                    if (i == 0)
                    {
                        ChosePos(ref txtNumber1, "o", i, 2);
                    }
                    if (i == 1)
                    {
                        ChosePos(ref txtNumber2, "o", i, 2);
                    }
                    if (i == 2)
                    {
                        ChosePos(ref txtNumber3, "o", i, 2);
                    }
                    if (i == 3)
                    {
                        ChosePos(ref txtNumber4, "o", i, 2);
                    }
                    if (i == 4)
                    {
                        ChosePos(ref txtNumber5, "o", i, 2);
                    }
                    if (i == 5)
                    {
                        ChosePos(ref txtNumber6, "o", i, 2);
                    }
                    if (i == 6)
                    {
                        ChosePos(ref txtNumber7, "o", i, 2);

                    }
                    if (i == 7)
                    {
                        ChosePos(ref txtNumber8, "o", i, 2);
                    }
                    if (i == 8)
                    {
                        ChosePos(ref txtNumber9, "o", i, 2);
                    }
                }
            }
        }
                

    }


    public class Machine
    {
        
        public Machine()
        {

        }


        public int[] MachineChoice(int[] playerChoice)
        {

            Random ran = new Random();
            if(playerChoice.Contains(0)){
                int rand = ran.Next(0, playerChoice.Length-1);
                if(playerChoice[rand] == 1 || playerChoice[rand] == 2)
                {
                    MachineChoice(playerChoice);
                }
                else
                {
                    playerChoice[rand] = 2;
                }
            }



            int[] updatedTable = playerChoice;

            return updatedTable;


        }

    }
}