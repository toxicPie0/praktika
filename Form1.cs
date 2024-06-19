using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;
using System.Xml;



namespace Praktika
{
    public partial class Form1 : Form
    {

        private string currentTable = "";
        static string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\\Users\\Seryo\\source\\repos\\Praktika\\database\\baza.accdb";

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            // Строка подключения к базе данных Access


            // Создание подключения к базе данных
            /* 
            using (connection)
            {
                // Создание команды для выборки данных
                OleDbCommand command = new OleDbCommand("SELECT * FROM car", connection);
                // Открытие подключения
                connection.Open();

                // Создание адаптера данных для заполнения набора данных
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);

                // Привязка набора данных к компоненту DataGridView
                dataGridView1.DataSource = dataset.Tables[0];
                connection.Close();
            }
            */
        }

        private void select_data_from_db_and_display_datagrid(string query)
        {
            OleDbConnection connection = new OleDbConnection(connectionString);
            using (connection)
            {
                // Создание команды для выборки данных
                OleDbCommand command = new OleDbCommand(query, connection);
                // Открытие подключения
                connection.Open();

                // Создание адаптера данных для заполнения набора данных
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);

                // Привязка набора данных к компоненту DataGridView
                dataGridView1.DataSource = dataset.Tables[0];
                // connection.Close();
            }

        }

        private void select_data_from_db_and_display_datagrid2()
        {
            string query = "SELECT TOP 1 * FROM " + currentTable;
            OleDbConnection connection = new OleDbConnection(connectionString);
            using (connection)
            {
                // connection.Open();
                // Создание команды для выборки данных
                OleDbCommand command = new OleDbCommand(query, connection);
                // Открытие подключения


                // Создание адаптера данных для заполнения набора данных
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                DataSet dataset = new DataSet();
                adapter.Fill(dataset);
                dataset.Clear();


                dataGridView2.DataSource = dataset.Tables[0];
            }

        }

        private void car_table_Click(object sender, EventArgs e)
        {

            string selectedTable = "car";
            currentTable = selectedTable;

            string query = "SELECT * FROM " + selectedTable; // твой супер мега запрос к базе данных
            select_data_from_db_and_display_datagrid(query);
            select_data_from_db_and_display_datagrid2();
        }

        private void crime_scene_report_table_Click(object sender, EventArgs e)
        {
            string selectedTable = "crime_scene_report";
            currentTable = selectedTable;
            string query = "SELECT * FROM crime_scene_report";
            select_data_from_db_and_display_datagrid(query);
        }

        private void education_table_Click(object sender, EventArgs e)
        {
            string selectedTable = "education";
            currentTable = selectedTable;
            string query = "SELECT * FROM education";
            select_data_from_db_and_display_datagrid(query);
        }

        private void interview_table_Click(object sender, EventArgs e)
        {
            string selectedTable = "interview";
            currentTable = selectedTable;
            string query = "SELECT * FROM interview";
            select_data_from_db_and_display_datagrid(query);
        }

        private void orgnaziation_table_Click(object sender, EventArgs e)
        {
            string selectedTable = "orgnaziation";
            currentTable = selectedTable;
            string query = "SELECT * FROM orgnaziation";
            select_data_from_db_and_display_datagrid(query);
        }
        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            Debug.WriteLine("DATA GRID VIEW VALIDATE");
        }


        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {



        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {

            
            // Получаем индекс выбранной строки в dataGridView1
            int selectedRowIndex = dataGridView1.CurrentCell.RowIndex;

            // Проверяем, что строка выбрана
            if (selectedRowIndex >= 0)
            {
                // Получаем DataTable, привязанный к dataGridView1
                DataTable sourceDataTable = (DataTable)dataGridView1.DataSource;

                // Получаем строку из исходного DataTable
                DataRow sourceRow = sourceDataTable.Rows[selectedRowIndex];

                // Создаем новую строку в целевом DataTable
                DataTable targetDataTable = (DataTable)dataGridView2.DataSource;
                DataRow targetRow = targetDataTable.NewRow();

                // Копируем значения ячеек из исходной строки в новую строку
                for (int i = 0; i < sourceRow.ItemArray.Length; i++)
                {
                    targetRow[i] = sourceRow[i];
                }

                // Добавляем новую строку в целевой DataTable
                targetDataTable.Rows.Add(targetRow);
            }
        }
    }
}
