namespace BilgeAdam.Async
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            source = new CancellationTokenSource();
        }

        private CancellationTokenSource source;

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value == progressBar1.Maximum)
            {
                timer1.Stop();
                return;
            }
            progressBar1.Value++;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            LongRunningProcess();
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            var result = await LongRunningCalculation();
            this.Text = result;
        }

        private async Task<string> LongRunningCalculation()
        {
            source = new CancellationTokenSource();
            var result = string.Empty;
            await Task.Run(() =>
            {
                var a = 0;
                for (int i = 0; i < int.MaxValue; i++)
                {
                    if (source.IsCancellationRequested)
                    {
                        return;
                    }
                    a = i / 2;
                }
                result = a.ToString();
            }, source.Token);

            return string.IsNullOrEmpty(result) ? "Cancelled" : result;
        }

        private Task LongRunningProcess()
        {
            return Task.Delay(5000);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            source.Cancel();
        }
    }
}