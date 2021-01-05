using System;
using Oracle.DataAccess.Client;

namespace ReportBulletinboard
{
    public partial class PostCreate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void BtnCreate_Click(object sender, System.EventArgs e)
        {
            string title = this.TxtTitle.Text;
            string description = this.TxtDescription.Text;
            string queryString =
                "INSERT INTO post (title, description, status) values ('" + title + "', '" + description + "' , 1)";
            using (OracleConnection connection = DBTranManager.GetDBConnection())
            {
                OracleCommand command = new OracleCommand(queryString);
                command.Connection = connection;
                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                    Response.Redirect("/Post/List.aspx");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        protected void BtnCancel_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("/Post/List.aspx");
        }
    }
}