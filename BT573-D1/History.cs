using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BT573_D1
{
    

    public partial class History : Form
    {
        static List<Calculation> calList = new List<Calculation>();

        public History()
        {
            InitializeComponent();
        }

        private void History_Load(object sender, EventArgs e)
        {
            calList.Clear();
            dgvHistory.DataSource = null;
            dgvHistory.Rows.Clear();

            string connectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=calculator;";

            string selectQuery = "Select * from Calculation_History";

            MySqlConnection dbConn = new MySqlConnection(connectionString);

            MySqlCommand dbCmd = new MySqlCommand(selectQuery, dbConn);

            MySqlDataReader reader;

            try
            {
                dbConn.Open();
                reader = dbCmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Calculation cal = new Calculation(reader.GetInt32(0), reader.GetString(1), reader.GetString(2));

                        calList.Add(cal);
                    }

                    foreach (Calculation cal in calList)
                    {
                        dgvHistory.Rows.Add(cal.CalId, cal.CalText, cal.CalResult);
                    }
                }
                else
                {
                    MessageBox.Show("Chưa có phép tính nào được lưu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                dbConn.Close();
            }
            catch
            { 
                MessageBox.Show("Đã xảy ra lỗi trong quá trình thực thi! Vui lòng thử lại sau!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    public class Calculation
    {
        int calId;
        string calText;
        string calResult;

        public int CalId { get => calId; set => calId = value; }
        public string CalText { get => calText; set => calText = value; }
        public string CalResult { get => calResult; set => calResult = value; }

        public Calculation(int calId, string calText, string calResult)
        {
            this.calId = calId;
            this.calText = calText;
            this.calResult = calResult;
        }

        public Calculation()
        {

        }
    }
}
