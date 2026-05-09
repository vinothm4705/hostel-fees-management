using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication2
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(
        ConfigurationManager.ConnectionStrings["Database1"].ConnectionString);

        double roomCharges, messCharges, electricityCharges, subTotal, serviceCharge, totalFee;

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        void CalculateFee()
        {
            double rent = Convert.ToDouble(DropDownList1.SelectedValue);
            int months = Convert.ToInt32(TextBox4.Text);

            roomCharges = rent * months;
            messCharges = 2000 * months;
            electricityCharges = 500 * months;

            subTotal = roomCharges + messCharges + electricityCharges;
            serviceCharge = subTotal * 0.05;

            totalFee = subTotal + serviceCharge;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            CalculateFee();

            LiteralFees.Text =
                "Room Charges: " + roomCharges + "<br/>" +
                "Mess Charges: " + messCharges + "<br/>" +
                "Electricity Charges: " + electricityCharges + "<br/>" +
                "Subtotal: " + subTotal + "<br/>" +
                "Service Charge (5%): " + serviceCharge + "<br/><br/>" +
                "<b>Total Fee: " + totalFee + "</b>";

            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CalculateFee();

            con.Open();

            string q = "insert into HostelFees values(@id,@name,@room,@months,@roomC,@mess,@ele,@sub,@service,@total)";
            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@id", TextBox1.Text);
            cmd.Parameters.AddWithValue("@name", TextBox2.Text);
            cmd.Parameters.AddWithValue("@room", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@months", TextBox4.Text);
            cmd.Parameters.AddWithValue("@roomC", roomCharges);
            cmd.Parameters.AddWithValue("@mess", messCharges);
            cmd.Parameters.AddWithValue("@ele", electricityCharges);
            cmd.Parameters.AddWithValue("@sub", subTotal);
            cmd.Parameters.AddWithValue("@service", serviceCharge);
            cmd.Parameters.AddWithValue("@total", totalFee);

            cmd.ExecuteNonQuery();
            con.Close();

            LabelMessage.Text = "Record Inserted Successfully";

            GridView1.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            CalculateFee();

            con.Open();

            string q = "update HostelFees set StudentName=@name,RoomType=@room,MonthsStayed=@months,RoomCharges=@roomC,MessCharges=@mess,ElectricityCharges=@ele,Subtotal=@sub,ServiceCharge=@service,TotalFee=@total where StudentID=@id";
            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@id", TextBox1.Text);
            cmd.Parameters.AddWithValue("@name", TextBox2.Text);
            cmd.Parameters.AddWithValue("@room", DropDownList1.SelectedItem.Text);
            cmd.Parameters.AddWithValue("@months", TextBox4.Text);
            cmd.Parameters.AddWithValue("@roomC", roomCharges);
            cmd.Parameters.AddWithValue("@mess", messCharges);
            cmd.Parameters.AddWithValue("@ele", electricityCharges);
            cmd.Parameters.AddWithValue("@sub", subTotal);
            cmd.Parameters.AddWithValue("@service", serviceCharge);
            cmd.Parameters.AddWithValue("@total", totalFee);

            cmd.ExecuteNonQuery();
            con.Close();

            LabelMessage.Text = "Record Updated Successfully";

            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            con.Open();

            string q = "delete from HostelFees where StudentID=@id";
            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@id", TextBox1.Text);

            cmd.ExecuteNonQuery();
            con.Close();

            LabelMessage.Text = "Record Deleted Successfully";

            GridView1.DataBind();
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            con.Open();

            string q = "select * from HostelFees where StudentID=@id"; 
            SqlCommand cmd = new SqlCommand(q, con);

            cmd.Parameters.AddWithValue("@id", TextBox1.Text);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                TextBox2.Text = dr["StudentName"].ToString();
                DropDownList1.SelectedItem.Text = dr["RoomType"].ToString();
                TextBox4.Text = dr["MonthsStayed"].ToString();

                LiteralFees.Text =
                    "Room Charges: " + dr["RoomCharges"] + "<br/>" +
                    "Mess Charges: " + dr["MessCharges"] + "<br/>" +
                    "Electricity Charges: " + dr["ElectricityCharges"] + "<br/>" +
                    "Subtotal: " + dr["Subtotal"] + "<br/>" +
                    "Service Charge (5%): " + dr["ServiceCharge"] + "<br/><br/>" +
                    "<b>Total Fee: " + dr["TotalFee"] + "</b>";
            }

            con.Close();

            LabelMessage.Text = "Record Selected Successfully";

            GridView1.DataBind();
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

    }
}