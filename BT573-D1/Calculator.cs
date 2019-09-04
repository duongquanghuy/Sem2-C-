using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BT573_D1
{
    public partial class Calculator : Form
    {
        string exp, resultString;
        double result;

        public Calculator()
        {
            InitializeComponent();
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                txtOperation.AppendText("1");
            }
        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                txtOperation.AppendText("2");
            }
        }

        private void Btn3_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                txtOperation.AppendText("3");
            }
        }

        private void Btn4_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                txtOperation.AppendText("4");
            }
        }

        private void Btn5_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                txtOperation.AppendText("5");
            }
        }

        private void Btn6_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                txtOperation.AppendText("6");
            }
        }

        private void Btn7_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                txtOperation.AppendText("7");
            }
        }

        private void Btn8_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                txtOperation.AppendText("8");

            }
        }

        private void Btn9_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                txtOperation.AppendText("9");
            }
        }

        private void Btn0_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                txtOperation.AppendText("0");
            }
        }

        private void BtnLPrt_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                txtOperation.AppendText("(");
            }
        }

        private void BtnRPrt_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                txtOperation.AppendText(")");
            }
        }

        private void BtnDot_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                if (txtOperation.Text.Equals(""))
                {
                    MessageBox.Show("Phép tính không thể khởi đầu với ký tự Thập phân (.)! Vui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtOperation.AppendText(".");
                }
            }
        }

        private void BtnAc_Click(object sender, EventArgs e)
        {
            txtOperation.Text = "";
            txtResult.Text = "= 0";
        }

        private void BtnDel_Click(object sender, EventArgs e)
        {
            if (txtOperation.Text.Length > 0)
            {
                txtOperation.Text = txtOperation.Text.Remove(txtOperation.Text.Length - 1);
            }
        }

        private void BtnPlus_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                txtOperation.AppendText("+");
            }
        }

        private void BtnSub_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                txtOperation.AppendText("-");
            }
        }

        private void BtnMul_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                if (txtOperation.Text.Equals(""))
                {
                    MessageBox.Show("Phép tính không thể khởi đầu với ký tự Nhân (×)! Vui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtOperation.AppendText("×");
                }
            }
        }

        private void BtnDiv_Click(object sender, EventArgs e)
        {
            if (!CheckFullOperation())
            {
                if (txtOperation.Text.Equals(""))
                {
                    MessageBox.Show("Phép tính không thể khởi đầu với ký tự Chia (÷)! Vui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    txtOperation.AppendText("÷");
                }
            }
        }

        private void BtnEqual_Click(object sender, EventArgs e)
        {
            exp = txtOperation.Text;

            if (exp.Equals(""))
            {
                MessageBox.Show("Bạn chưa nhập Phép tính nào! Vui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                exp = exp.Replace("×", "*");
                exp = exp.Replace("÷", "/");

                try
                {
                    result = Convert.ToDouble(new DataTable().Compute(exp, null));

                    resultString = String.Format("{0:0,0.#######}", result);

                    if (resultString.Length > 11)
                    {
                        resultString = resultString.Remove(11);
                    }

                    SendToCalculationHistory(txtOperation.Text, resultString);

                    txtResult.Text = ("= " + resultString);
                }
                catch
                {
                    txtResult.Text = "";
                    txtOperation.Text = "";
                    MessageBox.Show("Lỗi Cú pháp!\n Vui lòng nhập lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void Calculator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn thoát khỏi chương trình?", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
            else
            {
                e.Cancel = true;
            }
        }

        private Boolean CheckFullOperation()
        {
            if (txtOperation.Text.Length > 50)
            {
                MessageBox.Show("Bạn không thể nhập quá 50 ký tự cho phép tính!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return true;
            }
            else
            {
                return false;
            }
        }

        private void BtnHistory_Click(object sender, EventArgs e)
        {
            History historyForm = new History();
            historyForm.Show();
        }

        private void SendToCalculationHistory(string exp, string result)
        {
            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=calculator;";

            string insertQuery = "insert into calculation_history(calculation, result) values ('" + exp + "', '" + result + "')";

            MySqlConnection dbConn = new MySqlConnection(connectionString);

            MySqlCommand dbCmd = new MySqlCommand(insertQuery, dbConn);

            try
            {
                dbConn.Open();

                MySqlDataReader dbReader = dbCmd.ExecuteReader();

                dbConn.Close();
            }
            catch
            {
                MessageBox.Show("Có lỗi trong quá trình lưu lại phép tính!\nVui lòng thử lại!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
