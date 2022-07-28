using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public class Book
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

        public override string ToString()
        {
            return $"{Author}  -  {Title}  -  {Genre}";
        }
    }
    public partial class Form1 : Form
    {
        List<Book> books;
        public Form1()
        {
            InitializeComponent();
            books = new List<Book>
            {
                new Book
                {
                    Author="John",
                    Title="Book 1",
                    Genre="Dram"
                },
                new Book
                {
                    Author="John",
                    Title="Book 2",
                    Genre="Dram"
                },
                new Book
                {
                    Author="Leyla",
                    Title="Book 3",
                    Genre="Comedy"
                },
                    new Book{
                    Author="John",
                    Title="Book 4",
                    Genre="Sci-fi"

                },
                    new Book{
                    Author="Akif",
                    Title="Book 5",
                    Genre="Sci-fi"

                },
            };


            bookListbox.DataSource = books;

            var genres = books.Select(b => b.Genre).ToList().Distinct();
            genreCombox.Items.Add("All");
            genreCombox.Items.AddRange(genres.ToArray());

            genreCombox.SelectedIndex = 0;

            genreCombox.SelectedIndexChanged += GenreCombox_SelectedIndexChanged;

            //Book Title Author Genre

            //Books





            List<string> todos = new List<string>
            {
                "Read Book",
                "Drink Coffee",
                "Write Code",
                "Write more code",
                "Play Tennis"
            };

            //todos.Select(x => x.Trim()).ToList().Distinct();

            checkedListBox1.Items.AddRange(todos.ToArray());

            comboBox1.DataSource = todos;

            this.BackColor = Color.White;











        }

        private void GenreCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var currentGenre = genreCombox.SelectedItem as string;
            if (currentGenre == "All")
            {
                bookListbox.DataSource = books;
            }
            else
            {
                bookListbox.DataSource = books
                    .Where(b => b.Genre == currentGenre)
                    .ToList();
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var item = checkedListBox1.SelectedItem as string;
            label1.Text = item;
            var hasExist = checkedListBox1.CheckedItems.Contains(item);
            if (hasExist)
            {
                label1.BackColor = Color.SpringGreen;
            }
            else
            {
                label1.BackColor = Color.White;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkedListBox1.Items.Add(textBox1.Text);
        }
        

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            var list = checkedListBox1.Items;
            for (int i = 0; i < list.Count; i++)
            {
                var hasExists = checkedListBox1.CheckedItems.Contains(list[i]);
                if (hasExists)
                {
                    checkedListBox1.Items.Remove(list[i]);
                    --i;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label1.Text=comboBox1.SelectedItem.ToString();
        }
    }
}

