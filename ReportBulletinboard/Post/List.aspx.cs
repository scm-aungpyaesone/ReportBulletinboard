using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.DataAccess.Client;
using AdvanceSoftware.ExcelCreator;

namespace ReportBulletinboard
{
    public partial class PostList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string queryString = "SELECT * FROM POST";
            using (OracleConnection connection = DBTranManager.GetDBConnection())
            {
                OracleCommand command = new OracleCommand(queryString);
                command.Connection = connection;
                try
                {
                    connection.Open();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        // Always call Read before accessing data.
                        while (reader.Read())
                        {
                            TableRow row = new TableRow();
                            TableCell idCell = new TableCell();
                            idCell.Controls.Add(new LiteralControl(reader.GetInt32(0).ToString()));
                            row.Cells.Add(idCell);
                            TableCell titleCell = new TableCell();
                            titleCell.Controls.Add(new LiteralControl(reader.GetString(1)));
                            row.Cells.Add(titleCell);
                            TableCell descriptionCell = new TableCell();
                            descriptionCell.Controls.Add(new LiteralControl(reader.GetString(2)));
                            row.Cells.Add(descriptionCell);
                            TableCell statusCell = new TableCell();
                            if (reader.GetInt32(3) == 1)
                            {
                                statusCell.Controls.Add(new LiteralControl("Active"));
                            }
                            else
                            {
                                statusCell.Controls.Add(new LiteralControl("Inactive"));
                            }
                            row.Cells.Add(statusCell);

                            HyperLink editLink = new HyperLink();
                            editLink.NavigateUrl = "#";
                            editLink.Text = "Edit";
                            editLink.Style["padding"] = "5px";

                            HyperLink deleteLink = new HyperLink();
                            deleteLink.NavigateUrl = "#";
                            deleteLink.Text = "Delete";
                            deleteLink.Style["padding"] = "5px";
                            TableCell operationCell = new TableCell();
                            operationCell.Controls.Add(editLink);
                            operationCell.Controls.Add(deleteLink);
                            row.Cells.Add(operationCell);

                            this.POST_TABLE.Rows.Add(row);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        protected void BtnDownload_Click(object sender, System.EventArgs e)
        {
            var filePath = Server.MapPath("/Excel/");
            string fileNameExcel = "Postlist(" + DateTime.Now.ToString("yyyy年MM月dd日_作成") + ").xlsx";

            System.ComponentModel.IContainer components = new System.ComponentModel.Container();
            Creator creator1 = new Creator(components);
            try
            {
                creator1.CreateBook(filePath + fileNameExcel, 3, xlsxVersion.ver2016);
                creator1.Cell("A1").Value = "Post Title";
                creator1.Cell("B1").Value = "Post Description";
                creator1.Cell("C1").Value = "Posted User";
                creator1.Cell("D1").Value = "Posted At";
                creator1.CloseBook(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition",
               string.Format("attachment; filename={0}", fileNameExcel));
            Response.TransmitFile(filePath + fileNameExcel);
            Response.End();
        }
    }
}