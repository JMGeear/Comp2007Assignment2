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
                btnPreviousBook.Visible = false;


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
            try
            {
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
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
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

                try
                {
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
                catch (Exception ex)
                {
                    Response.Redirect("/errors.aspx");
                }


            }

            ddlChapter.Items.Insert(0, new ListItem("Select Chapter", "-1"));
        }

        protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            int BookNum;
            try
            {
                using (DefaultConnection db = new DefaultConnection())
                {
                    var bN = (from b in db.BibleBasicEnglishes
                              where b.Book == ddlBook.SelectedValue
                              select b).FirstOrDefault();

                    BookNum = Convert.ToInt32(bN.bookNum);
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }


            Session["bookNum"] = BookNum=0;
            try
            {
                using (DefaultConnection db = new DefaultConnection())
                {
                    var book = (from b in db.BibleBasicEnglishes
                                where b.bookNum == BookNum
                                select b).FirstOrDefault();

                    lblCurrentBook.Text = book.Book;
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }

            if (BookNum == 1)
            {
                btnPreviousBook.Visible = false;
            }
            else if (BookNum == 66)
            {
                btnPreviousBook.Visible = true;
                btnNextBook.Visible = false;
            }
            else
            {
                btnNextBook.Visible = true;
                btnPreviousBook.Visible = true;
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
          
            Session["bookNum"] = Convert.ToInt32(Session["bookNum"]) + 1;
            int bookNum = Convert.ToInt32(Session["bookNum"]);
            if (Convert.ToInt32(Session["bookNum"]) >= 66)
            {
                btnNextBook.Visible = false;
                btnPreviousBook.Visible = true;

                try
                {
                    using (DefaultConnection db = new DefaultConnection())
                    {
                        var book = (from b in db.BibleBasicEnglishes
                                    where b.bookNum == bookNum
                                    select b).FirstOrDefault();

                        lblCurrentBook.Text = book.Book;
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("/errors.aspx");
                }
            }
            else
            {
                btnPreviousBook.Visible = true;
                try
                {
                    using (DefaultConnection db = new DefaultConnection())
                    {
                        var book = (from b in db.BibleBasicEnglishes
                                    where b.bookNum == bookNum
                                    select b).FirstOrDefault();

                        lblCurrentBook.Text = book.Book;

                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("/errors.aspx");
                }
            }
        }

        protected void btnPrevious_Click(object sender, EventArgs e)
        {
            Session["bookNum"] = Convert.ToInt32(Session["bookNum"]) - 1;
            int bookNum = Convert.ToInt32(Session["bookNum"]);
            
            if (Convert.ToInt32(Session["bookNum"]) == 1)
            {
                btnPreviousBook.Visible = false;
                btnNextBook.Visible = true;

                try
                {
                    using (DefaultConnection db = new DefaultConnection())
                    {
                        var book = (from b in db.BibleBasicEnglishes
                                    where b.bookNum == bookNum
                                    select b).FirstOrDefault();

                        lblCurrentBook.Text = book.Book;
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("/errors.aspx");
                }
            }
            else
            {
                btnPreviousBook.Visible = true;

                try
                {
                    using (DefaultConnection db = new DefaultConnection())
                    {
                        var book = (from b in db.BibleBasicEnglishes
                                    where b.bookNum == bookNum
                                    select b).FirstOrDefault();

                        lblCurrentBook.Text = book.Book;
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("/errors.aspx");
                }
            }
        }

        protected void btnPreviousChapter_Click(object sender, EventArgs e)
        {

        }

        protected void btnNextChapter_Click(object sender, EventArgs e)
        {

        }

      



    }
}