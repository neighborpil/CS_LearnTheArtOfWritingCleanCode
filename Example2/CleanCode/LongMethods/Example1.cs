using System;
using System.Web;

namespace FooFoo
{
    public partial class Download : System.Web.UI.Page
    {
        private readonly MemoryFileCreator _memoryFileCreator = new MemoryFileCreator();
        private readonly TableReader _tableReader = new TableReader();

        protected void Page_Load(object sender, EventArgs e)
        {
            ClearResponse();

            SetCacheAbility();

            WriteContentToResponse(GetCsv());
        }

        private void ClearResponse()
        {
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.Cookies.Clear();
        }

        private void SetCacheAbility()
        {
            Response.Cache.SetCacheability(HttpCacheability.Private);
            Response.CacheControl = "private";
            Response.AppendHeader("Pragma", "cache");
            Response.AppendHeader("Expires", "60");
        }


        private void WriteContentToResponse(byte[] byteArray)
        {
            Response.Charset = System.Text.UTF8Encoding.UTF8.WebName;
            Response.ContentEncoding = System.Text.UTF8Encoding.UTF8;
            Response.ContentType = "text/comma-separated-values";
            Response.AddHeader("Content-Disposition", "attachment; filename=FooFoo.csv");
            Response.AddHeader("Content-Length", byteArray.Length.ToString());
            Response.BinaryWrite(byteArray);
        }

        private byte[] GetCsv()
        {
            System.IO.MemoryStream ms = _memoryFileCreator.CreateMemoryFile(_tableReader.GetDataTable());
            byte[] byteArray = ms.ToArray();
            ms.Flush();
            ms.Close();

            return byteArray;
        }
    }
}