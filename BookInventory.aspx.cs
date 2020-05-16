using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BookListmain
{
    public partial class BookInventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            if (txtISBN.Text != "" || txtAuthor.Text != "")
            {
                if (checkifBookExits())
                {
                    Response.Write("<script>alert('Author with this ID already exists!');</script>");
                }
                else
                {
                    addNewBook();
                }
            }
            else
            {
                Response.Write("<script>alert('You have missed to fill ID or Author Name!!');</script>");

            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtISBN.Text != "")
            {
                if (checkifBookExits())
                {
                    updateBooks();

                }
                else
                {
                    Response.Write("<script>alert('Author with this ID does not exist!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('You have missed to fill ID or Author Name!!');</script>");

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtISBN.Text != "")
            {

                if (checkifBookExits())
                {
                    deleteBook();

                }
                else
                {
                    Response.Write("<script>alert('Author with this ID does not exist!');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('You have missed to fill ID or Author Name!!');</script>");

            }
        }

        void addNewBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("INSERT INTO BookInventory (Title,Author,ISBN,Publisher,Year,Description) values (@Title,@Author,@ISBN,@Publisher,@Year,@Description)", con);
                cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@Author", txtAuthor.Text.Trim());
                cmd.Parameters.AddWithValue("@ISBN", txtISBN.Text.Trim());
                cmd.Parameters.AddWithValue("@Publisher", txtPublisher.Text.Trim());
                cmd.Parameters.AddWithValue("@Year", txtYear.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Added Successfully');</script>");
                clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }


        void updateBooks()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("UPDATE BookInventory SET Title=@Title,Author=@Author,Publisher=@Publisher,Year=@Year,Description=@Description WHERE ISBN='" + txtISBN.Text.Trim() + "'", con); ;

                cmd.Parameters.AddWithValue("@Title", txtTitle.Text.Trim());
                cmd.Parameters.AddWithValue("@Author", txtAuthor.Text.Trim());
                cmd.Parameters.AddWithValue("@Publisher", txtPublisher.Text.Trim());
                cmd.Parameters.AddWithValue("@Year", txtYear.Text.Trim());
                cmd.Parameters.AddWithValue("@Description", txtDescription.Text.Trim());
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Updated Successfully');</script>");
                clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }

        }


        void deleteBook()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("DELETE FROM BookInventory WHERE ISBN='" + txtISBN.Text.Trim() + "'", con); ;


                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Author Deleted Successfully');</script>");
                clearform();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }


        }


        void getBookByISBN()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from BookInventory where ISBN='" + txtISBN.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    txtTitle.Text = dt.Rows[0][0].ToString();
                    txtAuthor.Text = dt.Rows[0][1].ToString();
                    txtPublisher.Text = dt.Rows[0][3].ToString();
                    txtYear.Text = dt.Rows[0][4].ToString();
                    txtDescription.Text = dt.Rows[0][5].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Author ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        bool checkifBookExits()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from BookInventory where ISBN='" + txtISBN.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void clearform()
        {
            txtAuthor.Text = "";
            txtDescription.Text = "";
            txtISBN.Text = "";
            txtPublisher.Text = "";
            txtTitle.Text = "";
            txtYear.Text = "";
        }

        

        protected void Button1_Click1(object sender, EventArgs e)
        {
            getBookByISBN();
        }
    }
}