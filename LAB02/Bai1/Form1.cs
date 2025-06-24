namespace Bai1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

/*        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Hello");
        }*/

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please fill in all the textboxes!", "hello", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                string[] str = {textBox1.Text, textBox2.Text};
                var lvwItem1 = new ListViewItem(str);
                listView1.Items.Add(lvwItem1);
                //MessageBox.Show($"Bạn đã thêm thành công {lvwItem1}");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                
                if(MessageBox.Show("Bạn có chắc muốn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)==DialogResult.Yes)
                {
                    foreach (ListViewItem item in listView1.SelectedItems)
                    {

                        listView1.Items.Remove(item);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một mục để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
