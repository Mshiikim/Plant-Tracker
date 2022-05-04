using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Configuration;

namespace MIS218_FinalProject
{
    public partial class Form1 : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["PlantString"].ConnectionString;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Reload();
        }

        private void Reload()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            string sqlText = "select * from HousePlants";
            SqlCommand command = new SqlCommand(sqlText, connection);
            SqlDataReader reader = command.ExecuteReader();
            LstPlants.Items.Clear();
            int i = 0;
            while (reader.Read())
            {
                LstPlants.Items.Add(reader["PlantID"].ToString());
                LstPlants.Items[i].SubItems.Add(reader["Name"].ToString());
                LstPlants.Items[i].SubItems.Add(reader["LatinName"].ToString());
                LstPlants.Items[i].SubItems.Add(reader["Family"].ToString());
                LstPlants.Items[i].SubItems.Add(reader["Lighting"].ToString());
                LstPlants.Items[i].SubItems.Add(reader["Notes"].ToString());
                i++;
            }
            connection.Close();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Reload();
        }
        private void BtnAdd_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            try
            {
                string Name = TxtName.Text;
                string LatinName = TxtLatin.Text;
                string Family = TxtFamily.Text;
                string Lighting = TxtLighting.Text;
                string Notes = TxtNotes.Text;
                string sqlText = "insert into Houseplants ( Name, LatinName, Family, Lighting, Notes) values (@Name, @LatinName, @Family, @Lighting, @Notes)";
                SqlCommand cmd = new SqlCommand(sqlText, connect);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@LatinName", LatinName);
                cmd.Parameters.AddWithValue("@Family", Family);
                cmd.Parameters.AddWithValue("@Lighting", Lighting);
                cmd.Parameters.AddWithValue("@Notes", Notes);
                cmd.ExecuteNonQuery();
                Reload();
            }
            catch (Exception) { }
            connect.Close();
        }
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            try
            {
                int PlantID = Int32.Parse(TxtPlantID.Text);
                string Name = TxtName.Text;
                string LatinName = TxtLatin.Text;
                string Family = TxtFamily.Text;
                string Lighting = TxtLighting.Text;
                string Notes = TxtNotes.Text;
                string sqlText = "update Houseplants set Name = @Name, LatinName = @LatinName, Family = @Family, Lighting = @Lighting, Notes = @Notes where PlantID = @PlantID";
                SqlCommand cmd = new SqlCommand(sqlText, connect);
                cmd.Parameters.AddWithValue("@PlantID", PlantID);
                cmd.Parameters.AddWithValue("@Name", Name);
                cmd.Parameters.AddWithValue("@LatinName", LatinName);
                cmd.Parameters.AddWithValue("@Family", Family);
                cmd.Parameters.AddWithValue("@Lighting", Lighting);
                cmd.Parameters.AddWithValue("@Notes", Notes);
                cmd.ExecuteNonQuery();
                Reload();
            }
            catch (Exception) { }
            connect.Close();
        }
        private void BtnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection connect = new SqlConnection(connectionString);
            connect.Open();
            try
            {
                int PlantID = Int32.Parse(TxtPlantID.Text);
                string sqlText = "delete Houseplants where PlantID = @PlantID";
                SqlCommand cmd = new SqlCommand(sqlText, connect);
                cmd.Parameters.AddWithValue("@PlantID", PlantID);
                cmd.ExecuteNonQuery();
                Reload();
            }
            catch (Exception) { }
            connect.Close();
        }

        private void BtnConvert_Click(object sender, EventArgs e)
        {
            double converted = Double.Parse(TxtCelsius.Text);
            converted = Convert.C2f(converted);
            TxtFahrenheit.Text = converted.ToString();
        }
    }
}

