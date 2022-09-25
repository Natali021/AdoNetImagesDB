/*Допрацювати проект, створений в аудиторії.
На сторінці Display Book розробити механізм, який при виборі книги в комбобоксі cbBooks буде створювати
нову форму, та відображати в цій формі всю інформацію про вибрану книгу, включаючи зображення.
Обробити граничні випадки:
-при першому завантаженні цієї сторінки нова форма не має відображатись;
-якщо для вибраної книги малюнок відсутній в БД, код має просто відобразити решту інформації про книгу; */

using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdoNetImages3
{
    public partial class Form1 : Form
    {
        Image image = null;
        string connectionString = string.Empty;
        private SqlConnection conn = null;
        SqlDataAdapter adapter = null;//відповідає за підключення до бд
        
        bool firstSelected = false;
        public Form1()
        {
            InitializeComponent();            
            connectionString = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;  //в App.config треба прибирати екрануючий слеш
            conn = new SqlConnection(connectionString);
            FillAuthorCombobox();
            tabControl1.SelectedIndexChanged += TabControl1_SelectedIndexChanged;   
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.tabControl1.SelectedTab == tabPage2)
            {
                firstSelected = true;
                //заповнюємо cbBooks
                adapter = new SqlDataAdapter("select * from books", conn);
                DataSet set = new DataSet();
                SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
                adapter.Fill(set);
                
                
                //далі лише в такій черговості
                cbBooks.ValueMember = "id";  //щоб мати доступ до id з cbBooks
                cbBooks.DisplayMember = "title"; //те що ми хочемо бачити
                cbBooks.DataSource = set.Tables[0];                
            }

        }

        private void FillAuthorCombobox()
        {
            adapter = new SqlDataAdapter("select id, firstname + '' + lastname as author from authors", conn);
            //заглушки на остальні 3 властивості adapter
            SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
            DataSet set = new DataSet();
            //викликаємо метод Fill
            adapter.Fill(set);            
            //далі лише в такій черговості
            cbAuthor.ValueMember = "id";  //щоб мати доступ до id з cbAuthor
            cbAuthor.DisplayMember = "author"; //те що ми хочемо бачити (із запиту as author)
            cbAuthor.DataSource = set.Tables[0];

        }

        private void btSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            //фільтр на дадавання лише малюнків
            ofd.Filter = "jpeg files|*.jpg|png files|*.png"; //ліворуч від | - коментар, а праворуч від | - маска
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    image = Image.FromFile(ofd.FileName);  //ініціюємо глобальний об'єкт Image
                }
                catch (Exception ex)
                {
                    MessageBox.Show("From Select Image:"+ex.Message);
                }
            }
        }

        private void btClear_Click(object sender, EventArgs e)
        {
            tbTitle.Clear();
            cbAuthor.Text = "";
            tbPrice.Clear();
            tbPublishyear.Clear();
            image = null;
        }

        private void btAddBook_Click(object sender, EventArgs e)
        {
            try
            {
                //adapter = new SqlDataAdapter("select * from books", conn);
                //DataSet set = new DataSet();
                //SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
                //adapter.InsertCommand = comm;
                //adapter.Update(set);

                conn.Open();
                string myQuery = "insert into books (title, authorid, price, publishyear, picture) values" +
                    " (@title, @authorid, @price, @publishyear, @picture)";
                SqlCommand cmd = new SqlCommand(myQuery, conn);
                cmd.Parameters.Add("@title", SqlDbType.NVarChar, 128).Value = tbTitle.Text.Trim(); //Trim() Видаляє всі початкові та кінцеві символи пробілу з поточного рядка
                cmd.Parameters.Add("@authorid", SqlDbType.Int).Value = Convert.ToInt32(cbAuthor.SelectedValue); //конвертуємо текст в Int
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = Convert.ToInt32(tbPrice.Text.Trim());
                cmd.Parameters.Add("@publishyear", SqlDbType.Int).Value = Convert.ToInt32(tbPublishyear.Text.Trim());
                if (image != null)
                {
                    MemoryStream ms = new MemoryStream(); //для роботи з байтовими масивами
                    image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg); //зберігаємо малюнок в ms
                    ms.Flush(); //при записі в буферизований потік завжди викликати Flush() (навіть якщо буфер не переповнено цей метод все відправить в потік)
                    byte[] buf = ms.ToArray();
                    cmd.Parameters.Add("@picture", SqlDbType.Binary, buf.Length).Value = buf;
                    MessageBox.Show("Book is added");
                }
                else
                {
                    
                    //cmd.Parameters.Add("@picture", SqlDbType.Binary).Value = null;
                }

                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("From AddBook:" + ex.Message);
            }


        }

        private void cbBooks_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!firstSelected)
            {
                int index = Convert.ToInt32(cbBooks.SelectedValue);//витягуємо id книги
                adapter = new SqlDataAdapter("select b.title, a.firstName + ' ' + a.lastName as author, b.price, b.publishYear, b.picture " +
                                "from books as b join authors as a on b.authorid = a.id where b.id = @id", conn);
                //"select * from books where id=@id", conn);
                adapter.SelectCommand.Parameters.Add("@id", SqlDbType.Int).Value = index;
                SqlCommandBuilder cmd = new SqlCommandBuilder(adapter);
                DataSet setBook = new DataSet();            
                adapter.Fill(setBook);

                BookDatalis formBD = new BookDatalis();
                try
                {
                    DataRow rowBook = setBook.Tables[0].Rows[0];                    

                    formBD.lbTitle.Text = rowBook.ItemArray[0].ToString();                    
                    formBD.lbAuthor.Text = rowBook.ItemArray[1].ToString();
                    formBD.lbPrice.Text = rowBook.ItemArray[2].ToString();
                    formBD.lbPublishyear.Text = rowBook.ItemArray[3].ToString();
                    if (!DBNull.Value.Equals(rowBook.ItemArray[4]))
                    {                        
                        formBD.pbBook.Image = Image.FromStream(new MemoryStream((byte[])rowBook.ItemArray[4]));                        
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("From BookDatalis:" + ex.Message);
                }  

                formBD.Show();
            }
            else
            {
                firstSelected = false;
            }
        }


    }
}
