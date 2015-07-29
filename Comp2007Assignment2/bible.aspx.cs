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
    public partial class bible : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

            if (!IsPostBack)
            {

                Session["bookNum"] = 1;
                btnPrevious.Visible = false;


                // Bind Book dropdownlist
                BindddlBook();
                ddlChapter.Enabled = false;

                // Insert one item to dropdownlist top
                ddlBook.Items.Insert(0, new ListItem("Select Book", "-1"));
                ddlChapter.Items.Insert(0, new ListItem("Select Chapter", "-1"));
            }
        }

        public void BindddlBook()
        {
            ddlBook.Items.Clear();
            using (DefaultConnection db = new DefaultConnection())
            {

                var objB = (from b in db.BibleBasicEnglishes
                            orderby b.ID
                            group b by b.Book into d
                            select new { Book = d.Key, books = d.ToList() });

                ddlBook.DataSource = objB.ToList();
                ddlBook.DataBind();
            }


        }

        protected void ddlBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Remove Chapter dropdownlist items
            ddlChapter.Items.Clear();



            // Bind Chapter dropdownlist based on Book value
            if (ddlBook.SelectedValue == "-1")
            {


            }
            else
            {
                ddlChapter.Enabled = true;

                using (DefaultConnection db = new DefaultConnection())
                {
                    var objC = (from c in db.BibleBasicEnglishes
                                where c.Book == ddlBook.SelectedValue
                                group c by c.Chapter into d
                                select new { Chapter = d.Key, chapters = d.ToList() });

                    ddlChapter.DataSource = objC.ToList();
                    ddlChapter.DataBind();

                }


            }

            ddlChapter.Items.Insert(0, new ListItem("Select Chapter", "-1"));
        }

        protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            int BookNum;
            using (DefaultConnection db = new DefaultConnection())
            {
                var bN = (from b in db.BibleBasicEnglishes
                               where b.Book == ddlBook.SelectedValue
                               select b).FirstOrDefault();

                 BookNum = Convert.ToInt32(bN.bookNum);
            }


            Session["bookNum"] = BookNum;
            using (DefaultConnection db = new DefaultConnection())
            {
                    var book = (from b in db.BibleBasicEnglishes
                                where b.bookNum == BookNum
                                select b).FirstOrDefault();

                    lblCurrentBook.Text = book.Book;                
            }

            if (BookNum == 1)
            {
                btnPrevious.Visible = false;
            }
            else if (BookNum == 66)
            {
                btnPrevious.Visible = true;
                btnNext.Visible = false;
            }
            else
            {
                btnNext.Visible = true;
                btnPrevious.Visible = true;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
          
            Session["bookNum"] = Convert.ToInt32(Session["bookNum"]) + 1;
            int bookNum = Convert.ToInt32(Session["bookNum"]);
            if (Convert.ToInt32(Session["bookNum"]) >= 66)
            {
                btnNext.Visible = false;
                btnPrevious.Visible = true;

                using (DefaultConnection db = new DefaultConnection())
                {
                    var book = (from b in db.BibleBasicEnglishes
                                where b.bookNum == bookNum
                                select b).FirstOrDefault();

                    lblCurrentBook.Text = book.Book;
                }
            }
            else
            {
                btnPrevious.Visible = true;
                using (DefaultConnection db = new DefaultConnection())
                {
                    var book = (from b in db.BibleBasicEnglishes
                                where b.bookNum == bookNum
                                select b).FirstOrDefault();

                    lblCurrentBook.Text = book.Book;
                    
                }
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            Session["bookNum"] = Convert.ToInt32(Session["bookNum"]) - 1;
            int bookNum = Convert.ToInt32(Session["bookNum"]);
            
            if (Convert.ToInt32(Session["bookNum"]) == 1)
            {
                btnPrevious.Visible = false;
                btnNext.Visible = true;

                using (DefaultConnection db = new DefaultConnection())
                {
                    var book = (from b in db.BibleBasicEnglishes
                                where b.bookNum == bookNum
                                select b).FirstOrDefault();

                    lblCurrentBook.Text = book.Book;
                }
            }
            else
            {
                btnPrevious.Visible = true;
                
                using (DefaultConnection db = new DefaultConnection())
                {
                    var book = (from b in db.BibleBasicEnglishes
                                where b.bookNum == bookNum
                                select b).FirstOrDefault();

                    lblCurrentBook.Text = book.Book;
                }
            }
        }

      



    }
}