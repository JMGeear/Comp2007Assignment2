using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System.Configuration;

//reference our entity framework models
using Comp2007Assignment2.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace Comp2007Assignment2.admin
{
    public partial class note : System.Web.UI.Page
    {
        //String VerseText;
        //Int32 Chapter, Verse;
        protected void Page_Load(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            var userID = User.Identity.GetUserId();

            using (DefaultConnection db = new DefaultConnection())
            {
                user id = (from objs in db.users
                           where objs.userID == userID
                           select objs).FirstOrDefault();

            }


            if (!IsPostBack)
            {

                // Bind Book dropdownlist
                BindddlBook();
                ddlChapter.Enabled = false;
                ddlVerse.Enabled = false;

                // Insert one item to dropdownlist top
                ddlBook.Items.Insert(0, new ListItem("Select Book", "-1"));
                ddlChapter.Items.Insert(0, new ListItem("Select Chapter", "-1"));
                ddlVerse.Items.Insert(0, new ListItem("Select Verse", "-1"));

                // Initialize Verse dropdownlist selected index
                hdfDdlVerseSelectIndex.Value = "0";
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


        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Get the selected index of Chapter dropdownlist
            int iVerseSelected = Convert.ToInt16(hdfDdlVerseSelectIndex.Value);

            // The result will be showing
            string strResult = string.Empty;
            if (ddlBook.SelectedIndex == 0)
            {
                strResult = "Please select a Book.";
            }
            else if (ddlChapter.SelectedIndex == 0 && strResult == string.Empty)
            {
                strResult = "Please select a Chapter";
            }
            else if (ddlVerse.SelectedIndex == 0 && strResult == string.Empty)
            {
                strResult = "Please select a Verse";
            }
            else
            {

                strResult = "You selected Book: " + ddlBook.SelectedValue
                    + " ; Chapter: " + ddlChapter.SelectedValue
                    + " ; Verse: " + ddlVerse.SelectedValue;

            }

            using (DefaultConnection db = new DefaultConnection())
            {
                var Versetxt = (from v in db.BibleBasicEnglishes
                                where v.Book == ddlBook.SelectedValue && v.Chapter.ToString() == ddlChapter.SelectedValue && v.Verse.ToString() == ddlVerse.SelectedValue
                                group v by v.VerseText into d
                                select new { Verse = d.Key, verses = d.ToList() });
                TextVerse.Text = Versetxt.ToString();

            }

            lblResult.Text = strResult;
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

            // Clear Verse dropdownlist
            ddlVerse.Enabled = true;
            ddlVerse.Items.Clear();
            ddlVerse.Items.Insert(0, new ListItem("Select Verse", "-1"));

            // Initialize verse dropdownlist selected index
            hdfDdlVerseSelectIndex.Value = "0";
        }

        protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Bind city dropdownlist based on region value
            //string strChapter = string.Empty;
            //strChapter = ddlChapter.SelectedValue;


            using (DefaultConnection db = new DefaultConnection())
            {
                var Verse = (from v in db.BibleBasicEnglishes
                             where v.Book == ddlBook.SelectedValue && v.Chapter.ToString() == ddlChapter.SelectedValue
                             group v by v.Verse into d
                             select new { Verse = d.Key, verses = d.ToList() });

                //ddlVerse.Items.Clear();
                ddlVerse.DataSource = Verse.ToList();
                ddlVerse.DataBind();
                ddlVerse.Items.Insert(0, new ListItem("Select Verse", "-1"));


                // Initialize Verse dropdownlist selected index
                hdfDdlVerseSelectIndex.Value = "0";

                // Enable Verse dropdownlist when it has items
                if (ddlVerse.Items.Count > 0)
                {
                    ddlVerse.Enabled = true;
                }
                else
                {
                    ddlVerse.Enabled = false;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            var userID = User.Identity.GetUserId();
            //do insert or update
            using (DefaultConnection db = new DefaultConnection())
            {
                //blog objP = new blog();
                Int32 blogID = 0;

                if (!String.IsNullOrEmpty(Request.QueryString["blogID"]))
                {
                    blogID = Convert.ToInt32(Request.QueryString["blogID"]);

                    var objP = (from p in db.blogs
                                join br in db.blog_references on p.blogID equals br.blogID
                                join bt in db.blog_title on p.blogID equals bt.blogID
                                join bp in db.blog_post on p.blogID equals bp.blogID
                                where p.userID == userID
                                select p).FirstOrDefault();


                    //populate the course from the input form
                    //objP.title.ToString() = titleTxt.Text;
                    //objP.post = txtBlog.Text;
                }

                if (String.IsNullOrEmpty(Request.QueryString["postID"]))
                {
                    //add
                    //db.blog_post.Add(objP);
                }

                //save and redirect
                db.SaveChanges();
                Response.Redirect("bibleMenu.aspx");
            }
        }       

    }
}