using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace IT111_MP
{
    class GamePlay : Records
    {
        //QUERY
        //objects
        private Form winQuery = new Form();
        private Label lbl_query = new Label();
        private Button btn_restart = new Button();
        private Button btn_ToLevels = new Button();
        private PictureBox prize = new PictureBox();

        //GAMEPLAY
        //objects
        private Form winGamePlay = new Form();
        private Timer mainTimer = new Timer();
        private Timer clockTimer = new Timer();
        private PictureBox player = new PictureBox();
        private ProgressBar healthBar = new ProgressBar();
        private Label lbl_hp = new Label();
        private Label lbl_ammo = new Label();
        private Label lbl_kills = new Label();
        private PictureBox logo = new PictureBox();
        private Label lbl_clock = new Label();
        private Random randNum = new Random();
        private List<PictureBox> enemyList = new List<PictureBox>();

        //Font
        PrivateFontCollection Ancient = new PrivateFontCollection();
        PrivateFontCollection Logo = new PrivateFontCollection();
        PrivateFontCollection Ui = new PrivateFontCollection();
        PrivateFontCollection Title = new PrivateFontCollection();

        //Clock variables
        private int seconds = 0;
        private int minutes = 0;

        //Control variables
        private bool goLeft, goRight, goUp, goDown;
        private string facing = "up";

        //Enemy variables
        private int enemyLimit = 0;
        private int enemySpeed = 0;
        private int enemyIngame = 0;

        //Player variables
        private int playerHealth = 0;
        private int speed = 0;

        //Items
        private int ammo = 0;
        private int kills = 0;
        private int killGoal = 0;

        //Set
        private int _Elimit;
        private int _Espeed;
        private int _Kgoal;
        private int _Acount;
        private int _min;
        private Form _win;
        public int _index;
        private List<string> enemy_skin = new List<string>();

        //Antagonist
        private static List<string> monster = new List<string>() { "gallery/enemies/aleft.png", "gallery/enemies/aright.png", "gallery/enemies/aup.png", "gallery/enemies/adown.png" };
        private static List<string> reptile = new List<string>() { "gallery/enemies/bleft.png", "gallery/enemies/bright.png", "gallery/enemies/bup.png", "gallery/enemies/bdown.png" };
        private static List<string> alien = new List<string>() { "gallery/enemies/cleft.png", "gallery/enemies/cright.png", "gallery/enemies/cup.png", "gallery/enemies/cdown.png" };
        private static List<string> sword = new List<string>() { "gallery/enemies/dleft.png", "gallery/enemies/dright.png", "gallery/enemies/dup.png", "gallery/enemies/ddown.png" };
        private static List<string> wizard = new List<string>() { "gallery/enemies/eleft.png", "gallery/enemies/eright.png", "gallery/enemies/eup.png", "gallery/enemies/edown.png" };
        private List<List<string>> skin_list = new List<List<string>> { monster, reptile, alien, sword, wizard };
    


        protected void SetGame(int Elimit, int Espeed, int Kgoal, int Acount, int min, Form win, int index)
        {
            _Elimit = Elimit;
            _Espeed = Espeed;
            _Kgoal = Kgoal;
            _Acount = Acount;
            _min = min;
            _win = win;
            _index = index;
            enemy_skin = skin_list[randNum.Next(0, 4)];

            StartGame();


            winGamePlay.Show();
        }

        private void StartGame()
        {
            //player
            playerHealth = 100;
            speed = 10;
            ammo = _Acount;
            goLeft = false;
            goRight = false;
            goDown = false;
            goUp = false;
            facing = "up";
            player.Image = new Bitmap("gallery/up.png");

            //enemy
            enemyLimit = _Elimit;
            enemySpeed = _Espeed;
            enemyIngame = 0;

            for (int i = 1; i <= enemyLimit; i++)
            {
                MakeEnemy();
            }

            //goals
            kills = 0;
            killGoal = _Kgoal;

            //time
            seconds = 0;
            minutes = _min;
            mainTimer.Enabled = true;
            clockTimer.Enabled = true;
        }

        private void Restart(object sender, EventArgs e)
        {
            winQuery.Hide();
            clockTimer.Enabled = false;
            mainTimer.Start();
            ClearEnemy();
            StartGame();
        }

        private void TimedOut()
        {
            clockTimer.Stop();
            mainTimer.Stop();
            Query("Timed Out");
        }

        private void PlayerDead()
        {
            clockTimer.Stop();
            mainTimer.Stop();
            healthBar.Value = 0;
            player.Image = new Bitmap("gallery/dead.png");
            Query("Game Over");
        }

        private void LevelComplete()
        {
            clockTimer.Stop();
            mainTimer.Stop();
            Query("Level Complete");
            AddTo_currP($"{minutes}:{seconds}", _index);
            LevelProgress();
        }

        protected virtual void LevelProgress()
        {

        }

        private void BackToLevels(object sender, EventArgs e)
        {
            winQuery.Hide();
            winGamePlay.Hide();
            _win.Show();
        }




        //GUI FUNCTIONS---------------------------------------
        //GamePlay
        protected void InGame()
        {
            Application.EnableVisualStyles();
            AddFont();

            //winGamePlay
            winGamePlay.Text = "ARMAGEDDON";
            winGamePlay.Width = 1400;
            winGamePlay.Height = 750;
            winGamePlay.StartPosition = FormStartPosition.CenterScreen;
            winGamePlay.FormBorderStyle = FormBorderStyle.FixedSingle;
            winGamePlay.MinimizeBox = true;
            winGamePlay.MaximizeBox = false;
            winGamePlay.BackColor = Color.FromArgb(30, 30, 30);
            winGamePlay.FormClosed += new FormClosedEventHandler(Exit);

            //mainTimer
            mainTimer.Interval = 20;
            mainTimer.Tick += new EventHandler(mainTimer_tick);

            //clockTimer
            clockTimer.Interval = 1000;
            clockTimer.Tick += new EventHandler(clockTimer_tick);

            //healthBar
            healthBar.Location = new Point(winGamePlay.Width - 300, 10);
            healthBar.Size = new Size(250, 30);
            healthBar.Parent = winGamePlay;
            

            //lbl_hp
            lbl_hp.Text = "HP";
            lbl_hp.ForeColor = Color.White;
            lbl_hp.Location = new Point(winGamePlay.Width - 350, 7);
            lbl_hp.Font = new Font(Ui.Families[0], 25);
            lbl_hp.Size = new Size(60, 40);
            lbl_hp.Parent = winGamePlay;

            //lbl_ammo
            lbl_ammo.Text = $"AMMO: {ammo}";
            lbl_ammo.ForeColor = Color.White;
            lbl_ammo.Location = new Point(25, 7);
            lbl_ammo.Font = new Font(Ui.Families[0], 25);
            lbl_ammo.Size = new Size(160, 40);
            lbl_ammo.Parent = winGamePlay;

            //lbl_kills
            lbl_kills.Text = $"KILLS: {kills}";
            lbl_kills.ForeColor = Color.White;
            lbl_kills.Location = new Point(180, 7);
            lbl_kills.Font = new Font(Ui.Families[0], 25);
            lbl_kills.Size = new Size(200, 40);
            lbl_kills.Parent = winGamePlay;

            //lbl_clock
            lbl_clock.Text = $">>{minutes:00}:00<<";
            lbl_clock.ForeColor = Color.White;
            lbl_clock.Location = new Point(630, 5);
            lbl_clock.Font = new Font(Ui.Families[0], 25);
            lbl_clock.Size = new Size(200, 30);
            lbl_clock.Parent = winGamePlay;

            //logo
            logo.Image = new Bitmap("gallery/logo.png");
            logo.SizeMode = PictureBoxSizeMode.StretchImage;
            logo.Width = 200;
            logo.Height = 30;
            logo.Location = new Point(600, 40);
            logo.Parent = winGamePlay;

            //player
            player.Image = new Bitmap("gallery/up.png");
            player.Location = new Point((winGamePlay.Width / 2), (winGamePlay.Height / 2));
            player.SizeMode = PictureBoxSizeMode.AutoSize;
            player.Parent = winGamePlay;

            //Events
            winGamePlay.KeyDown += new KeyEventHandler(KeyIsDown);
            winGamePlay.KeyUp += new KeyEventHandler(KeyIsUp);
            winGamePlay.MouseDown += new MouseEventHandler(MouseIsClicked);

        }

        //Query
        private void Query(string status)
        {
            //winQuery
            winQuery.Text = "ARMAGEDDON";
            winQuery.Width = 300;
            winQuery.Height = 400;
            winQuery.StartPosition = FormStartPosition.CenterScreen;
            winQuery.FormBorderStyle = FormBorderStyle.FixedSingle;
            winQuery.MinimizeBox = false;
            winQuery.MaximizeBox = false;
            winQuery.ControlBox = false;
            winQuery.BackColor = Color.FromArgb(30, 30, 70);
            winQuery.FormBorderStyle = FormBorderStyle.None;
            winQuery.Owner = winGamePlay;

            //lbl_query
            lbl_query.Text = $"{status}";
            lbl_query.ForeColor = Color.White;
            lbl_query.Dock = DockStyle.Top;
            lbl_query.TextAlign = ContentAlignment.TopCenter;
            lbl_query.Font = new Font(Ui.Families[0], 25);
            lbl_query.Size = new Size(160, 40);
            lbl_query.Parent = winQuery;

            //btn_restart
            btn_restart.Text = "Restart";
            btn_restart.Location = new Point(60, 300);
            btn_restart.Size = new Size(180, 40);
            btn_restart.Font = new Font(Logo.Families[0], 10);
            btn_restart.ForeColor = Color.FromArgb(255, 255, 255);
            btn_restart.BackColor = Color.FromArgb(150, 0, 0);
            btn_restart.TabStop = false;
            btn_restart.TabIndex = 0;
            btn_restart.Click += new EventHandler(Restart);
            btn_restart.Parent = winQuery;

            //btn_ToLevels
            btn_ToLevels.Text = "Levels";
            btn_ToLevels.Location = new Point(60, 350);
            btn_ToLevels.Size = new Size(180, 40);
            btn_ToLevels.Font = new Font(Logo.Families[0], 10);
            btn_ToLevels.ForeColor = Color.FromArgb(255, 255, 255);
            btn_ToLevels.BackColor = Color.FromArgb(150, 0, 0);
            btn_ToLevels.TabStop = false;
            btn_ToLevels.TabIndex = 0;
            btn_ToLevels.Click += new EventHandler(BackToLevels);
            btn_ToLevels.Parent = winQuery;

            int progress = 0;
            foreach(string i  in currP)
            {
                if(i != null) { progress++; }
            }

            //prize
            if (status == "Level Complete" || progress-2 >= _index)
            {
                prize.Image = new Bitmap("gallery/prize.png");
            }
            else
            {
                prize.Image = new Bitmap("gallery/locked.png");
            }
            prize.SizeMode = PictureBoxSizeMode.StretchImage;
            prize.Size = new Size(250, 200);
            prize.Location = new Point(25, 70);
            prize.Parent = winQuery;




            //show
            winQuery.Show();
        }




        //TIMER TICK FUNCTIONS---------------------------------------
        //clockTimer_tick
        private void clockTimer_tick(object sender, EventArgs e)
        {

            lbl_clock.Text = $">>{minutes:00}:{seconds:00}<<";

            if (minutes == 0 && seconds == 0)
            {
                TimedOut();
            }
            else if (seconds == 0)
            {
                minutes--;
                seconds = 59;
            }
            else
            {
                seconds--;
            }
        }




        //mainTimer_tick
        private void mainTimer_tick(object sender, EventArgs e)
        {
            if (kills == killGoal)
            {
                ClearEnemy();
                LevelComplete();
            }


            //Ammo Count
            lbl_ammo.Text = $"AMMO: {ammo}";

            //Kill Count
            lbl_kills.Text = $"KILLS: {kills}";


            //Player Health
            if (playerHealth > 1)
            {
                healthBar.Value = playerHealth;
            }
            else
            {
                player.Image = new Bitmap("gallery/dead.png");

                ClearEnemy();
                PlayerDead();
            }


            //Player Movement
            if (goLeft == true && player.Left > 0)
            {
                player.Left -= speed;
            }
            if (goRight == true && player.Left + player.Width < winGamePlay.Width - 20)
            {
                player.Left += speed;
            }
            if (goUp == true && player.Top > 100)
            {
                player.Top -= speed;
            }
            if (goDown == true && player.Top + player.Height + 40 < winGamePlay.Height)
            {
                player.Top += speed;
            }


            foreach (Control x in winGamePlay.Controls)
            {

                //Ammo Collision
                if (x is PictureBox && (string)x.Tag == "ammo")
                {
                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        winGamePlay.Controls.Remove(x);
                        ((PictureBox)x).Dispose();
                        ammo += _Acount;
                    }
                }



                //Enemy Collision and Movement
                if (x is PictureBox && (string)x.Tag == "enemy")
                {

                    if (player.Bounds.IntersectsWith(x.Bounds))
                    {
                        playerHealth -= 1;
                    }

                    if (x.Left > player.Left)
                    {
                        x.Left -= enemySpeed;
                        ((PictureBox)x).Image = new Bitmap(enemy_skin[0]);
                    }
                    if (x.Left < player.Left)
                    {
                        x.Left += enemySpeed;
                        ((PictureBox)x).Image = new Bitmap(enemy_skin[1]);
                    }
                    if (x.Top > player.Top)
                    {
                        x.Top -= enemySpeed;
                        ((PictureBox)x).Image = new Bitmap(enemy_skin[2]);
                    }
                    if (x.Top < player.Top)
                    {
                        x.Top += enemySpeed;
                        ((PictureBox)x).Image = new Bitmap(enemy_skin[3]);
                    }



                    //EnemyAmmo Collision
                    foreach (Control j in winGamePlay.Controls)
                    {
                        if (j is PictureBox && (string)j.Tag == "bullet" && x is PictureBox && (string)x.Tag == "enemy")
                        {
                            if (x.Bounds.IntersectsWith(j.Bounds))
                            {
                                kills++;
                                enemyIngame--;

                                winGamePlay.Controls.Remove(j);
                                ((PictureBox)j).Dispose();
                                winGamePlay.Controls.Remove(x);
                                ((PictureBox)x).Dispose();
                                enemyList.Remove(((PictureBox)x));

                                if (enemyIngame <= enemyLimit && (kills + enemyIngame) < killGoal)
                                {
                                    MakeEnemy();
                                }
                            }
                        }
                    }
                }
            }
        }




        //KEY/MOUSE EVENTS---------------------------------------
        //KeyIsDown
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (clockTimer.Enabled == true)
            {
                if (e.KeyCode == Keys.A)
                {
                    goLeft = true;
                    facing = "left";
                    player.Image = new Bitmap("gallery/left.png");
                }
                if (e.KeyCode == Keys.D)
                {
                    goRight = true;
                    facing = "right";
                    player.Image = new Bitmap("gallery/right.png");
                }
                if (e.KeyCode == Keys.W)
                {
                    goUp = true;
                    facing = "up";
                    player.Image = new Bitmap("gallery/up.png");
                }
                if (e.KeyCode == Keys.S)
                {
                    goDown = true;
                    facing = "down";
                    player.Image = new Bitmap("gallery/down.png");
                }
            }
        }
        //KeyIsUp
        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                goLeft = false;
            }
            if (e.KeyCode == Keys.D)
            {
                goRight = false;
            }
            if (e.KeyCode == Keys.W)
            {
                goUp = false;
            }
            if (e.KeyCode == Keys.S)
            {
                goDown = false;
            }

        }
        //MouseIsClicked
        private void MouseIsClicked(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && ammo > 0)
            {
                ammo--;
                if (clockTimer.Enabled == true)
                {
                    ShootBullet();

                }

                if (ammo < 1)
                {
                    DropAmmo();
                }
            }
        }




        //GAMEPLAY FUNCTIONS---------------------------------------
        //ShootBullets
        private void ShootBullet()
        {
            Bullet shootBullet = new Bullet();
            shootBullet.direction = facing;
            shootBullet.bulletLeft = player.Left + (player.Width / 2);
            shootBullet.bulletTop = player.Top + (player.Height / 2);
            shootBullet.MakeBullet(winGamePlay);
        }

        //DropAmmo
        private void DropAmmo()
        {
            PictureBox ammoDrop = new PictureBox();

            ammoDrop.Image = new Bitmap("gallery/crate.png");
            ammoDrop.SizeMode = PictureBoxSizeMode.StretchImage;
            ammoDrop.Width = 100;
            ammoDrop.Height = 90;
            ammoDrop.Left = randNum.Next(100, winGamePlay.Width - 200);
            ammoDrop.Top = randNum.Next(100, winGamePlay.Height - 200);
            ammoDrop.Tag = "ammo";
            ammoDrop.Parent = winGamePlay;

        }

        //MakeEnemey
        private void MakeEnemy()
        {
            string[] enemies = { "" };

            PictureBox enemy = new PictureBox();
            enemy.Tag = "enemy";
            enemy.Image = new Bitmap(enemy_skin[3]);
            enemy.Left = randNum.Next(10, winGamePlay.Width - enemy.Width);
            enemy.Top = randNum.Next(100, winGamePlay.Height - enemy.Height);
            enemy.SizeMode = PictureBoxSizeMode.AutoSize;
            enemyList.Add(enemy);
            enemy.Parent = winGamePlay;
            enemyIngame++;
        }

        //ClearEnemy
        private void ClearEnemy()
        {
            if (enemyIngame > 0)
            {
                foreach (Control i in enemyList)
                {
                    i.Dispose();
                }

            }
            foreach (Control i in winGamePlay.Controls)
            {
                if ((string)i.Tag == "ammo")
                {
                    i.Dispose();
                }
            }

        }




        //OTHER FUNCTIONS---------------------------------------
        //Exit
        protected virtual void Exit(object sender, FormClosedEventArgs e)
        {

        }
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

    }
}
