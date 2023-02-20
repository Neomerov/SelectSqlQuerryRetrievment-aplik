using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;

namespace aplik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string connection_string = "Data Source=.\\SQLEXPRESS;Initial Catalog=DrugaVjezba;Integrated Security=True";
        private void btnShow_Click(object sender, EventArgs e)
        {
            var upit = textBox1.Text;

            using (SqlConnection sql = new SqlConnection(connection_string))
            {
                SqlCommand command = new SqlCommand(
                    upit,
                  //"SELECT * FROM products;",
                  sql);
                sql.Open();

                try
                {
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {

                        dataGridView1.Visible = true;
                        DataTable dt = new DataTable();
                        dt.Load(reader);
                        //MessageBox.Show(dt.ToString());
                        dataGridView1.DataSource = dt;

                        //if (sb.Length > 0) sb.Append("___");
                        //while (reader.Read())
                        //{
                        //    for (int i = 0; i < reader.FieldCount; i++)
                        //        if (reader.GetValue(i) != DBNull.Value)
                        //            label1.Text = (reader[i].ToString());

                        //sb.AppendFormat("{0}-", Convert.ToString(reader.GetValue(i)));

                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Unesite ispravno Vaš upit");
                }
    
            }
   
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}