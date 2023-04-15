namespace Nedeljni_planer
{
    public partial class Form1 : Form
    {
        private TextBox[,] tabela = new TextBox[10, 8];

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //640 sirina
            this.Size = new Size(640, 390);
            this.BackColor = Color.Gray;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    tabela[i, j] = new TextBox();
                    tabela[i, j].Size = new Size(60, 15);
                    tabela[i, j].Location = new Point(20 + j * 75, 40 + i * 30);

                    if (j == 0)
                    {
                        tabela[i, j].Text = (8 + i) + "h";
                    }

                    this.Controls.Add(tabela[i, j]);
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text|*.txt";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string[] linije = new string[10];
                for (int i = 0; i < linije.Length; i++)
                {
                    linije[i] = "";
                    for (int j = 1; j < 8; j++)
                    {
                        if (j < 7) linije[i] += tabela[i, j].Text + ',';
                        else linije[i] += tabela[i, j].Text;
                    }
                }
                System.IO.File.WriteAllLines(sfd.FileName, linije);
                MessageBox.Show("Dokument je uspesno snimljen");
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = ("Text|*.txt");
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string[] lin = System.IO.File.ReadAllLines(ofd.FileName);
                for (int i = 0; i < 10; i++)
                {
                    string[] polja = lin[i].Split(',');
                    tabela[i, 0].Text = (8 + i) + "h";
                    for (int j = 0; j < 7; j++)
                    {
                        tabela[i, j + 1].Text = polja[j];
                    }
                }
            }
        }
    }
}