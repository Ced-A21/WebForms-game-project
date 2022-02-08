using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT111_MP
{
    class Game: GamePlay
    {
        #region


        //LOGIN
        public Form winLogin = new Form();
        private Label lbl_name = new Label();
        private TextBox txt_name = new TextBox();
        private Button btn_enter = new Button();
        private Label lbl_error = new Label();


        //MENU
        private Form winMenu = new Form();
        private PictureBox pic_logo = new PictureBox();
        private static Button btn_play = new Button();
        private static Button btn_level = new Button();
        private static Button btn_leader = new Button();
        private List<Button> menu_btns = new List<Button>() { btn_play, btn_level, btn_leader };

        //LEVELS
        private Form winLevels = new Form();
        private Label lbl_levels = new Label();
        private Button btn_backLevels = new Button();
        private static Button btn_lvl1 = new Button();
        private static Button btn_lvl2 = new Button();
        private static Button btn_lvl3 = new Button();
        private static Button btn_lvl4 = new Button();
        private static Button btn_lvl5 = new Button();
        private List<Button> levels = new List<Button>() { btn_lvl1, btn_lvl2, btn_lvl3, 
                                                           btn_lvl4, btn_lvl5 };

        //LEVEL 1
        private Form winL1 = new Form();
        private Label lbl_l1 = new Label();
        private Button btn_backl1 = new Button();
        private static Button btn_l1easy = new Button();
        private static Button btn_l1medium = new Button();
        private static Button btn_l1hard = new Button();
        private List<Button> diff1 = new List<Button>() { btn_l1easy, btn_l1medium, btn_l1hard };
        //LEVEL 2
        private Form winL2 = new Form();
        private Label lbl_l2 = new Label();
        private Button btn_backl2 = new Button();
        private static Button btn_l2easy = new Button();
        private static Button btn_l2medium = new Button();
        private static Button btn_l2hard = new Button();
        private List<Button> diff2 = new List<Button>() { btn_l2easy, btn_l2medium, btn_l2hard };
        //LEVEL 3
        private Form winL3 = new Form();
        private Label lbl_l3 = new Label();
        private Button btn_backl3 = new Button();
        private static Button btn_l3easy = new Button();
        private static Button btn_l3medium = new Button();
        private static Button btn_l3hard = new Button();
        private List<Button> diff3 = new List<Button>() { btn_l3easy, btn_l3medium, btn_l3hard };
        //LEVEL 4
        private Form winL4 = new Form();
        private Label lbl_l4 = new Label();
        private Button btn_backl4 = new Button();
        private static Button btn_l4easy = new Button();
        private static Button btn_l4medium = new Button();
        private static Button btn_l4hard = new Button();
        private List<Button> diff4 = new List<Button>() { btn_l4easy, btn_l4medium, btn_l4hard };
        //LEVEL 5
        private Form winL5 = new Form();
        private Label lbl_l5 = new Label();
        private Button btn_backl5 = new Button();
        private static Button btn_l5easy = new Button();
        private static Button btn_l5medium = new Button();
        private static Button btn_l5hard = new Button();
        private List<Button> diff5 = new List<Button>() { btn_l5easy, btn_l5medium, btn_l5hard };

        //all levels
        private List<Button> all_diff = new List<Button>() { btn_l1easy, btn_l1medium, btn_l1hard,
                                                             btn_l2easy, btn_l2medium, btn_l2hard,
                                                             btn_l3easy, btn_l3medium, btn_l3hard,
                                                             btn_l4easy, btn_l4medium, btn_l4hard,
                                                             btn_l5easy, btn_l5medium, btn_l5hard};



        //LEADERBOARD
        private Form winLeader = new Form();
        private Label lbl_leader = new Label();
        private static Label l1 = new Label();
        private static Label l2 = new Label();
        private static Label l3 = new Label();
        private static Label l4 = new Label();
        private static Label l5 = new Label();
        private static Label l6 = new Label();
        private static Label l7 = new Label();
        private static Label l8 = new Label();
        private static Label l9 = new Label();
        private static Label l10 = new Label();
        private static Label l11 = new Label();
        private static Label l12 = new Label();
        private static Label l13 = new Label();
        private static Label l14 = new Label();
        private static Label l15 = new Label();
        private static Label l16 = new Label();
        private static Label l17 = new Label();
        private static Label l18 = new Label();
        private static Label l19 = new Label();
        private static Label l20 = new Label();
        private static List<Label> labels = new List<Label> { l1, l2, l3, l4, l5, l6, l7, l8, l9, l10,
                                                              l11,l12,l13,l14,l15,l16,l17,l18,l19,l20};
        private Button btn_clear = new Button();
        private Button btn_backLeader = new Button();


        //FONT
        PrivateFontCollection Ancient = new PrivateFontCollection();
        PrivateFontCollection Logo = new PrivateFontCollection();
        PrivateFontCollection Ui = new PrivateFontCollection();
        PrivateFontCollection Title = new PrivateFontCollection();

        
        //variables
        private string Player = "";
        #endregion

        //WINDOWS---------------------------------------
        //LOGIN---
        public void Login()
        {
            AddFont();

            //winLogin
            SetWindow(winLogin, 500, 200, false, false);

            //lbl_name
            lbl_name.Text = "enter playername";
            lbl_name.Font = new Font(Logo.Families[0], 13);
            lbl_name.ForeColor = Color.FromArgb(255, 255, 255);
            lbl_name.Location = new Point(120, 20);
            lbl_name.Size = new Size(260, 20);
            lbl_name.Parent = winLogin;

            //txt_name
            txt_name.Name = "Player_name";
            txt_name.Font = new Font(Ancient.Families[0], 20);
            txt_name.TextAlign = HorizontalAlignment.Center;
            txt_name.Location = new Point(40, 50);
            txt_name.Size = new Size(400, 25);
            txt_name.MaxLength = 10;
            txt_name.Parent = winLogin;

            //btn_enter
            btn_enter.Location = new Point(175, 110);
            btn_enter.Size = new Size(130, 30);
            btn_enter.Text = "ENTER";
            btn_enter.Font = new Font(Logo.Families[0], 10);
            btn_enter.ForeColor = Color.FromArgb(255, 255, 255);
            btn_enter.BackColor = Color.FromArgb(150, 0, 0);
            btn_enter.TabStop = false;
            btn_enter.TabIndex = 0;
            btn_enter.Click += new EventHandler(EnterGame);
            btn_enter.Parent = winLogin;

            //label_error
            lbl_error.Text = "Invalid Input";
            lbl_error.Font = new Font(Ancient.Families[0], 7);
            lbl_error.ForeColor = Color.FromArgb(255, 0, 0);
            lbl_error.Location = new Point(190, 95);
            lbl_error.Size = new Size(110, 15);
            lbl_error.Visible = false;
            lbl_error.Parent = winLogin;
        }

        
        //MENU---
        private void Menu()
        {
            AddFont();

            //winMenu
            SetWindow(winMenu, 900, 600, true, false);

            //pic_logo
            pic_logo.Image = new Bitmap("gallery/logo.png");
            pic_logo.SizeMode = PictureBoxSizeMode.StretchImage;
            pic_logo.Height = 150;
            pic_logo.Width = 700;
            pic_logo.Location = new Point(90,80);
            pic_logo.Parent = winMenu;

            //menu_btns
            MenuButtons(menu_btns, winMenu);
            btn_level.Click += new EventHandler(MenuToLevels);
            btn_leader.Click += new EventHandler(MenuToLeaderboard);
            btn_play.Click += new EventHandler(PlayClicked);

        }
        
        

        //LEVELS---
        private void Levels()
        {
            AddFont();

            //winLevels
            SetWindow(winLevels, 800, 750, true, false);

            //lbl_levels
            lbl_levels.Text = "LEVELS";
            lbl_levels.Font = new Font(Title.Families[0], 60);
            lbl_levels.ForeColor = Color.FromArgb(150, 0, 0);
            lbl_levels.Location = new Point(300, 20);
            lbl_levels.Size = new Size(200, 80);
            lbl_levels.Parent = winLevels;

            //btn_backLevels
            btn_backLevels.Location = new Point(45, 50);
            btn_backLevels.Size = new Size(140, 30);
            btn_backLevels.Text = "BACK";
            btn_backLevels.Font = new Font(Logo.Families[0], 15);
            btn_backLevels.ForeColor = Color.FromArgb(255, 255, 255);
            btn_backLevels.BackColor = Color.FromArgb(150, 0, 0);
            btn_backLevels.TabStop = false;
            btn_backLevels.TabIndex = 0;
            btn_backLevels.Click += new EventHandler(BackFromLevels);
            btn_backLevels.Parent = winLevels;

            DisplayLevels();

            btn_lvl1.Click += new EventHandler(ToLevel1);
            btn_lvl2.Click += new EventHandler(ToLevel2);
            btn_lvl3.Click += new EventHandler(ToLevel3);
            btn_lvl4.Click += new EventHandler(ToLevel4);
            btn_lvl5.Click += new EventHandler(ToLevel5);
        }

        private void Level1()
        {
            //winL1
            SetWindow(winL1, 600, 400, true, false);

            SetWinLevelContent(winL1, lbl_l1, btn_backl1, 1);

            btn_backl1.Click += new EventHandler(BackFromLevel1);

            DiffButtons(diff1, winL1);

            btn_l1easy.Click += new EventHandler(play);
            btn_l1medium.Click += new EventHandler(play);
            btn_l1hard.Click += new EventHandler(play);
        }

        private void Level2()
        {
            //winL2
            SetWindow(winL2, 600, 400, true, false);

            SetWinLevelContent(winL2, lbl_l2, btn_backl2, 2);

            btn_backl2.Click += new EventHandler(BackFromLevel2);

            DiffButtons(diff2, winL2);

            btn_l2easy.Click += new EventHandler(play);
            btn_l2medium.Click += new EventHandler(play);
            btn_l2hard.Click += new EventHandler(play);
        }

        private void Level3()
        {
            //winL3
            SetWindow(winL3, 600, 400, true, false);

            SetWinLevelContent(winL3, lbl_l3, btn_backl3, 3);

            btn_backl3.Click += new EventHandler(BackFromLevel3);

            DiffButtons(diff3, winL3);

            btn_l3easy.Click += new EventHandler(play);
            btn_l3medium.Click += new EventHandler(play);
            btn_l3hard.Click += new EventHandler(play);
        }

        private void Level4()
        {
            //winL4
            SetWindow(winL4, 600, 400, true, false);

            SetWinLevelContent(winL4, lbl_l4, btn_backl4, 4);

            btn_backl4.Click += new EventHandler(BackFromLevel4);

            DiffButtons(diff4, winL4);

            btn_l4easy.Click += new EventHandler(play);
            btn_l4medium.Click += new EventHandler(play);
            btn_l4hard.Click += new EventHandler(play);
        }

        private void Level5()
        {
            //winL5
            SetWindow(winL5, 600, 400, true, false);

            SetWinLevelContent(winL5, lbl_l5, btn_backl5, 5);

            btn_backl5.Click += new EventHandler(BackFromLevel5);

            DiffButtons(diff5, winL5);

            btn_l5easy.Click += new EventHandler(play);
            btn_l5medium.Click += new EventHandler(play);
            btn_l5hard.Click += new EventHandler(play);
        }


        //LEADERBOARD---
        private void Leaderboard()
        {
            AddFont();
            
            //winLeader
            SetWindow(winLeader, 800, 750, true, false);

            //lbl_leader
            lbl_leader.Text = "LEADERBOARD";
            lbl_leader.Font = new Font(Title.Families[0], 60);
            lbl_leader.ForeColor = Color.FromArgb(150, 0, 0);
            lbl_leader.Location = new Point(235, 20);
            lbl_leader.Size = new Size(330, 90);
            lbl_leader.Parent = winLeader;

            //UpdateLeaders
            UpdateLeaders();

            //btn_clear
            btn_clear.Location = new Point(600, 50);
            btn_clear.Size = new Size(140, 30);
            btn_clear.Text = "CLEAR";
            btn_clear.Font = new Font(Logo.Families[0], 15);
            btn_clear.ForeColor = Color.FromArgb(255, 255, 255);
            btn_clear.BackColor = Color.FromArgb(150, 0, 0);
            btn_clear.TabStop = false;
            btn_clear.TabIndex = 0;
            btn_clear.Click += new EventHandler(ClearLeaders);
            btn_clear.Parent = winLeader;

            //btn_backLeader
            btn_backLeader.Location = new Point(45, 50);
            btn_backLeader.Size = new Size(140, 30);
            btn_backLeader.Text = "BACK";
            btn_backLeader.Font = new Font(Logo.Families[0], 15);
            btn_backLeader.ForeColor = Color.FromArgb(255, 255, 255);
            btn_backLeader.BackColor = Color.FromArgb(150, 0, 0);
            btn_backLeader.TabStop = false;
            btn_backLeader.TabIndex = 0;
            btn_backLeader.Click += new EventHandler(BackFromLeaders);
            btn_backLeader.Parent = winLeader;
        }

        
        





        //TRANSITIONS---------------------------------------
        //EnterGame
        private void EnterGame(object sender, EventArgs e)
        {
            Validation val = new Validation();

            bool isGood = val.GoodInput(txt_name.Text);

            if (isGood == true)
            {
                Player = txt_name.Text.Replace(" ", "");
                currP[0] = Player.ToUpper();
                LoadPLayer();
                winLogin.Hide();
                GetTopTen();
                InitializeAll();
                winMenu.Show();
                
                
            }
            else
            {
                lbl_error.Visible = true;
                txt_name.Text = "";
            }
        }

        //MenuToLeaderborad
        private void MenuToLeaderboard(object sender, EventArgs e)
        {
            GetTopTen();
            UpdateLeaders();
            winMenu.Hide();
            winLeader.Show();

        }
        //BackFromLeaders
        private void BackFromLeaders(object sender, EventArgs e)
        {
            winLeader.Hide();
            winMenu.Show();
        }
        
        //MenuToLevels
        private void MenuToLevels(object sender, EventArgs e)
        {
            winMenu.Hide();
            winLevels.Show();
        }
        //BackFromLevels
        private void BackFromLevels(object sender, EventArgs e)
        {
            winLevels.Hide();
            winMenu.Show();
        }

        //ToLevel1
        private void ToLevel1(object sender, EventArgs e)
        {
            winLevels.Hide();
            winL1.Show();
        }
        //BackFromLevel1
        private void BackFromLevel1(object sender, EventArgs e)
        {
            winL1.Hide();
            winLevels.Show();
        }

        //ToLevel2
        private void ToLevel2(object sender, EventArgs e)
        {
            winLevels.Hide();
            winL2.Show();
        }
        //BackFromLevel2
        private void BackFromLevel2(object sender, EventArgs e)
        {
            winL2.Hide();
            winLevels.Show();
        }

        //ToLevel3
        private void ToLevel3(object sender, EventArgs e)
        {
            winLevels.Hide();
            winL3.Show();
        }
        //BackFromLevel3
        private void BackFromLevel3(object sender, EventArgs e)
        {
            winL3.Hide();
            winLevels.Show();
        }

        //ToLevel4
        private void ToLevel4(object sender, EventArgs e)
        {
            winLevels.Hide();
            winL4.Show();
        }
        //BackFromLevel4
        private void BackFromLevel4(object sender, EventArgs e)
        {
            winL4.Hide();
            winLevels.Show();
        }
        
        //ToLevel5
        private void ToLevel5(object sender, EventArgs e)
        {

            winLevels.Hide();
            winL5.Show();
        }
        //BackFromLevel5
        private void BackFromLevel5(object sender, EventArgs e)
        {
            winL5.Hide();
            winLevels.Show();
        }



        //PLAY FUNCTIONS---------------------------------------
        //PLAY CLICKED
        private void PlayClicked(object sender, EventArgs e)
        {
            winMenu.Hide();

            int index = 0;
            foreach (string i in currP)
            {
                if (i != null) { index++; }
            }


            if (index == 1)
            {
                play(all_diff[index-1], e);
            }
            else if (index == 17)
            {
                play(all_diff[14], e);
            }
            else
            {
                play(all_diff[index - 2], e);
            }

        }

        private void play(object sender, EventArgs e)
        {

            //Level 1 | Elimit, Espeed, Kgoal, Acount, min
            if (sender == btn_l1easy)
            {
                winL1.Hide();
                SetGame(3, 2, 10, 50, 5, winLevels, 1);
            }
            if (sender == btn_l1medium)
            {
                winL1.Hide();
                SetGame(4, 2, 20, 20, 5, winLevels, 2);
            }
            if (sender == btn_l1hard)
            {
                winL1.Hide();
                SetGame(6, 2, 30, 20, 5, winLevels, 3);
            }

            //Level 2 | Elimit, Espeed, Kgoal, Acount, min
            if (sender == btn_l2easy)
            {
                winL2.Hide();
                SetGame(3, 2, 10, 15, 5, winLevels, 4);
            }
            if (sender == btn_l2medium)
            {
                winL2.Hide();
                SetGame(4, 2, 20, 15, 5, winLevels, 5);
            }
            if (sender == btn_l2hard)
            {
                winL2.Hide();
                SetGame(6, 2, 30, 15, 5, winLevels, 6);
            }

            //Level 3 | Elimit, Espeed, Kgoal, Acount, min
            if (sender == btn_l3easy)
            {
                winL3.Hide();
                SetGame(3, 2, 10, 10, 3, winLevels, 7);
            }
            if (sender == btn_l3medium)
            {
                winL3.Hide();
                SetGame(4, 2, 20, 10, 3, winLevels, 8);
            }
            if (sender == btn_l3hard)
            {
                winL3.Hide();
                SetGame(6, 2, 30, 10, 3, winLevels, 9);
            }

            //Level 4 | Elimit, Espeed, Kgoal, Acount, min
            if (sender == btn_l4easy)
            {
                winL4.Hide();
                SetGame(3, 2, 10, 8, 3, winLevels, 10);
            }
            if (sender == btn_l4medium)
            {
                winL4.Hide();
                SetGame(4, 2, 20, 8, 3, winLevels, 11);
            }
            if (sender == btn_l4hard)
            {
                winL4.Hide();
                SetGame(6, 2, 30, 8, 3, winLevels, 12);
            }

            //Level 5 | Elimit, Espeed, Kgoal, Acount, min
            if (sender == btn_l5easy)
            {
                winL5.Hide();
                SetGame(3, 2, 10, 5, 2, winLevels, 13);
            }
            if (sender == btn_l5medium)
            {
                winL5.Hide();
                SetGame(4, 2, 20, 5, 2, winLevels, 14);
            }
            if (sender == btn_l5hard)
            {
                winL5.Hide();
                SetGame(6, 2, 30, 5, 2, winLevels, 15);
            }
        }





        //GUI FUNCTIONS---------------------------------------
        //AddFont
        private void AddFont()
        {
        Ancient.AddFontFile("font/EternalAncient-JROVj.ttf");
        //Ancient.Families[0]

        Logo.AddFontFile("font/EternalLogo-MVO7Y.ttf");
        //Logo.Families[0]   

        Ui.AddFontFile("font/EternalUiRegular-1Gap2.ttf");
        //Ui.Families[0]

        Title.AddFontFile("font/Amazdoomright-o1B0.ttf");
        //Title.Families[0]

        }

        //InitializeAll
        private void InitializeAll()
        {
            Menu();
            InGame();
            Leaderboard();
            Levels();
            Level1();
            Level2();
            Level3();
            Level4();
            Level5();
            LevelProgress();

        }

        //Exit
        protected override void Exit(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //DisplayLevels
        private void DisplayLevels()
        {
            int y = 160;
            for (int i = 0; i < 5; i++)
            {
                levels[i].Text = $"LEVEL {i + 1}";
                levels[i].Location = new Point(200, y);
                levels[i].Size = new Size(400, 80);
                levels[i].Font = new Font(Ancient.Families[0], 25);
                levels[i].ForeColor = Color.FromArgb(255, 255, 255);
                levels[i].BackColor = Color.FromArgb(150, 0, 0);
                levels[i].TabStop = false;
                levels[i].TabIndex = 0;
                levels[i].Parent = winLevels;

                y += 100;
            }
        }

        //DiffButtons
        private void DiffButtons(List<Button> diff, Form parent)
        {
            int y = 125;
            List<string> title = new List<string> { "piece of cake", "medium", "insane" };
            for (int i = 0; i < 3; i++)
            {
                diff[i].Text = $"{title[i]}";
                diff[i].Location = new Point(125, y);
                diff[i].Size = new Size(350, 50);
                diff[i].Font = new Font(Ancient.Families[0], 15);
                diff[i].ForeColor = Color.FromArgb(255, 255, 255);
                diff[i].BackColor = Color.FromArgb(150, 0, 0);
                diff[i].TabStop = false;
                diff[i].TabIndex = 0;
                diff[i].Parent = parent;
                diff[i].Enabled = false;

                y += 80;
            }
        }
        
        //SetWindow
        private void SetWindow(Form parent, int width, int height, bool mini, bool max)
        {
            parent.Text = "ARMAGEDDON";
            parent.Width = width;
            parent.Height = height;
            parent.StartPosition = FormStartPosition.CenterScreen;
            parent.FormBorderStyle = FormBorderStyle.FixedSingle;
            parent.MinimizeBox = mini;
            parent.MaximizeBox = max;
            parent.BackColor = Color.FromArgb(30, 30, 30);
            parent.FormClosed += new FormClosedEventHandler(Exit);
        }

        //SetWinLevelContent
        private void SetWinLevelContent(Form win, Label lbl, Button btn_back, int level)
        {
            //lbl
            lbl.Text = $"LEVEL {level}";
            lbl.Font = new Font(Title.Families[0], 60);
            lbl.ForeColor = Color.FromArgb(150, 0, 0);
            lbl.Location = new Point(200, 20);
            lbl.Size = new Size(250, 80);
            lbl.Parent = win;

            //btn_back
            btn_back.Location = new Point(30, 40);
            btn_back.Size = new Size(120, 30);
            btn_back.Text = "BACK";
            btn_back.Font = new Font(Logo.Families[0], 15);
            btn_back.ForeColor = Color.FromArgb(255, 255, 255);
            btn_back.BackColor = Color.FromArgb(150, 0, 0);
            btn_back.TabStop = false;
            btn_back.TabIndex = 0;
            btn_back.Parent = win;
        }

        //MenuButtons
        private void MenuButtons(List<Button> btn, Form parent)
        {
            int y = 250;
            List<string> buttons = new List<string> { "PLAY", "LEVELS", "LEADERBOARD" };

            for (int i = 0; i < 3; i++)
            {
                btn[i].Text = $"{buttons[i]}";
                btn[i].Location = new Point(300, y);
                btn[i].Size = new Size(300, 60);
                btn[i].Font = new Font(Ancient.Families[0], 15);
                btn[i].ForeColor = Color.FromArgb(255, 255, 255);
                btn[i].BackColor = Color.FromArgb(150, 0, 0);
                btn[i].TabStop = false;
                btn[i].TabIndex = 0;
                btn[i].Parent = parent;

                y += 80;
            }

        }





        //FILE FUNCTIONS---------------------------------------
        //ClearLeaders
        private void ClearLeaders(object sender, EventArgs e)
        {
            ClearTop();
            GetTopTen();
            UpdateLeaders();
        }

        //UpdateLeaders
        private void UpdateLeaders()
        {
            if (sorted.Count() <= 0)
            {
                btn_clear.Enabled = false;
            }
            else
            {
                btn_clear.Enabled = true;
            }

            int y = 125;
            int x = 40;

            for (int i = 0; i < 5; i++)
            {
                try
                {
                    DisplayPlayer(labels[i], labels[i + 10], sorted[i], y, x);
                    y += 50;
                }
                catch
                {
                    labels[i].Text = "";
                    labels[i + 10].Text = "";
                }
            }
        }

        //DisplayPlayer
        private void DisplayPlayer(Label l, Label s, string text, int y, int x)
        {
            string[] v = text.Split('|');

            l.Text = $"{v[0]}";
            l.Font = new Font(Logo.Families[0], 25);
            l.ForeColor = Color.FromArgb(255, 255, 255);
            l.Location = new Point(x, y);
            l.Size = new Size(400, 35);
            l.Parent = winLeader;
            
            s.Text = $"{v[1]}";
            s.Font = new Font(Ui.Families[0], 30);
            s.ForeColor = Color.FromArgb(255, 255, 255);
            s.Location = new Point(x+550, y);
            s.Size = new Size(200, 35);
            s.Parent = winLeader;
        }

        //LevelProgress
        protected override void LevelProgress()
        {
            for(int i = 0; i<15; i++)
            {
                if(currP[i] != null)
                {
                    all_diff[i].Enabled = true;
                }
            }
        }
        
       



    }
}
