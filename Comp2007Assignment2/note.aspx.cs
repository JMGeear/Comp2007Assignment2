using System.Web.Script.Services;
using AjaxControlToolkit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



//reference our entity framework models
using Comp2007Assignment2.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace Comp2007Assignment2
{
    public partial class note : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void GetBook()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var book = (from b in db.BibleBasicEnglishes
                            orderby b.Book
                            select b).Distinct();

                ddlBook.DataSource = book.ToList();
                ddlBook.DataBind();
            }
        }

        protected void GetChapter()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var chapter = (from c in db.BibleBasicEnglishes
                            orderby c.Chapter
                            select c).Distinct();

                ddlChapter.DataSource = chapter.ToList();
                ddlChapter.DataBind();
            }
        }

        protected void GetVerse()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
                var verse = (from v in db.BibleBasicEnglishes
                               orderby v.Verse
                               select v);

                ddlVerse.DataSource = verse.ToList();
                ddlVerse.DataBind();
            }
        }
       

        protected void btnSave_Click(object sender, EventArgs e)
        {

        }

        protected void ddlBook_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlVerse_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}