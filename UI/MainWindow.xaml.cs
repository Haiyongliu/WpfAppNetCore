using System;
using System.Collections.Generic;
using System.Windows;
using System.Collections.Specialized;
using WpfAppNetCore.SqlData.util;
using WpfAppNetCore.SqlData.frame;
using MySql.Data.MySqlClient;



namespace DataGridBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            btn_chart_analysis.Click += Btn_chart_click;
            btn_add.Click += BtnAddClick;
            btn_add_sql_segment.Click += BtnAddSqlSegment;
            //this.TestInsert();
            /*string connectionString = "server=111.229.112.54;Database=hy;Uid=root;Pwd=Liu123778010..;";
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            System.Diagnostics.Debug.WriteLine("Mysql数据库连接状态:" + conn.State);*/


        }

        public void TestDB()
        {
            string fileName = System.Environment.CurrentDirectory + "\\test.db";
            System.Diagnostics.Debug.WriteLine("数据库路径:" + fileName);


            SqliteHelper.CreateDBFile(fileName);
            SqliteHelper.CreateTable(SqliteHelper.GetConnection(fileName, 3), SqlParams.MainTable.SQL_CREATE_TABLE);
        }

        public void TestInsert()
        {
            SqliteImpl sqliteImpl = new SqliteImpl();
            string tt = "'s2020-2'";
            string sql = "insert into finalance (name,insto,data,description) values('lhy-7',21," + tt + ",'description test')";
            sqliteImpl.Insert(sql);

        }

        public LinkedList<NameValueCollection> TestGet()
        {
            SqliteImpl sqliteImpl = new SqliteImpl();
            string sql = @"select * from finalance";
            return sqliteImpl.Get(sql);

        }

        private void Btn_chart_click(object sender, RoutedEventArgs e) {
            ChartWindow chartWindow = new ChartWindow();
            chartWindow.Show();

        }

        private void BtnAddSqlSegment(object sender, RoutedEventArgs e)
        {
            App app = (App)Application.Current;
            lastMember.BindInsto = 99;
        }

        private void BtnAddClick(object sender, RoutedEventArgs e)
        {
            DownloadData();
        }

        private Member lastMember;
        private void DownloadData()
        {
            List<Member> datas = GetData();
            App app = (App)Application.Current;
            foreach (Member member in datas)
            {
                app.MembersViewModel.Members.Add(member);
                lastMember = member;
            }

        }

        private List<Member> GetData()
        {
            List<Member> datas = new List<Member>();
            LinkedList<NameValueCollection> nameValueData = GetFromSql();
            foreach (NameValueCollection item in nameValueData)
            {
                Member member = new Member();
                member.BindName = item.Get(SqlParams.MainTable.NAME);
                member.BindInsto = Convert.ToSingle(item.Get(SqlParams.MainTable.INSTO));
                member.BindDescription = item.Get(SqlParams.MainTable.DESCRIPTION);
                datas.Add(member);
            }

            return datas;
        }
        private LinkedList<NameValueCollection> GetFromSql()
        {
            SqliteImpl sqliteImpl = new SqliteImpl();
            string sql = @"select * from finalance";
            return sqliteImpl.Get(sql);

        }
    }
}
