using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using System.Collections.Generic;

namespace Phan2
{
    public partial class Form1 : Form
    {

        public string conn = "Data Source=703-04\\SQLEXPRESS;Initial Catalog=Thu_nghiem;Integrated Security=True;Encrypt=False";
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            List<Customer> customers = GetAllCustomers();
            dgv1.DataSource = customers;  // Gán dữ liệu vào DataGridView
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> result = new List<Customer>();
            using (SqlConnection connection = new SqlConnection(conn))
            {
                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM [Customer]", connection);
                connection.Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.CustomerID = reader.GetInt32(0);
                    customer.CustomerName = reader.GetString(1);
                    customer.Address = reader.GetString(2);
                    customer.Amount = reader.GetInt32(3);
                    result.Add(customer);
                }
            }
            return result;
        }
    }
}
