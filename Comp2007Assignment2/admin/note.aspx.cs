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
using System.Data;

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

            try
            {
                using (DefaultConnection db = new DefaultConnection())
                {
                    user id = (from objs in db.users
                               where objs.userID == userID
                               select objs).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }

            getBlog();

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
            }
        }

        public void getBlog()
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            var userID = User.Identity.GetUserId();

            //try
            //{
            using (DefaultConnection db = new DefaultConnection())
            {
                int chapterid, verseid;

                if ((Request.QueryString["blogID"]) != null)
                {
                    var blogID = Convert.ToInt32((Request.QueryString["blogID"]));

                    var objE = (from bg in db.blogs
                                join br in db.blog_references on bg.blogID equals br.blogID
                                join bt in db.blog_title on bg.blogID equals bt.blogID
                                join bp in db.blog_post on bg.blogID equals bp.blogID
                                where bg.userID == Convert.ToString(userID) && bg.blogID == blogID
                                select new { bg.blogID, br.bookName, br.chapterID, br.verseID, br.verseText, bt.title, bp.post }).FirstOrDefault();
                   // objE.ToList();
                    
                    if (objE != null)
                    {
                        
                        blogID = objE.blogID;
                        ddlBook.SelectedValue = objE.bookName;
                        chapterid = objE.chapterID;
                        verseid = objE.verseID;
                        TextVerse.Text = objE.verseText;
                        titleTxt.Text = objE.title;
                        txtBlog.Text = objE.post;




                    }
                }
            }
            //}
            //catch (Exception ex)
            //{
            //Response.Redirect("/errors.aspx");
            //}
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

            try
            {
                using (DefaultConnection db = new DefaultConnection())
                {
                    var Versetxt = (from v in db.BibleBasicEnglishes
                                    where v.Book == ddlBook.SelectedValue && v.Chapter.ToString() == ddlChapter.SelectedValue && v.Verse.ToString() == ddlVerse.SelectedValue
                                    select v.VerseText);

                    TextVerse.Text = Versetxt.FirstOrDefault().ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
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

            // Clear Verse dropdownlist
            ddlVerse.Enabled = true;
            ddlVerse.Items.Clear();
            ddlVerse.Items.Insert(0, new ListItem("Select Verse", "-1"));

        }

        protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Bind city dropdownlist based on region value
            //string strChapter = string.Empty;
            //strChapter = ddlChapter.SelectedValue;

            try
            {
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
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var userStore = new UserStore<IdentityUser>();
                var manager = new UserManager<IdentityUser>(userStore);
                var userID = User.Identity.GetUserId();
                //do insert or update

                using (DefaultConnection db = new DefaultConnection())
                {
                    blog b = new blog();
                    blog_references bref = new blog_references();
                    blog_title btitle = new blog_title();
                    blog_post bpost = new blog_post();

                    int chapterid = Convert.ToInt32(ddlChapter.SelectedValue);
                    int verseid = Convert.ToInt32(ddlVerse.SelectedValue);

                    Int32 blogID = 0;

                    if ((Request.QueryString["blogID"]) != null)
                    {
                        blogID = Convert.ToInt32(Request.QueryString["blogID"]);
                        bref.blogID = blogID;
                        bpost.blogID = blogID;
                        btitle.blogID = blogID;
                    }

                    //set blog variable
                    b.userID = userID;
                    //set references variables
                    bref.bookName = ddlBook.SelectedValue;
                    bref.chapterID = Convert.ToInt32(ddlChapter.SelectedValue);
                    bref.verseID = Convert.ToInt32(ddlVerse.SelectedValue);
                    //set post variables
                    bpost.post = txtBlog.Text;
                    //set title variables
                    btitle.title = titleTxt.Text;

                    if (blogID == 0)
                    {
                        db.blogs.Add(b);
                        db.SaveChanges();

                        blogID = (from n in db.blogs
                                  where n.userID == userID
                                  orderby n.blogID descending
                                  select n.blogID).First();

                        bref.blogID = blogID;
                        bpost.blogID = blogID;
                        btitle.blogID = blogID;

                        db.blog_references.Add(bref);
                        db.blog_post.Add(bpost);
                        db.blog_title.Add(btitle);
                    }
                    db.SaveChanges();
                }
 }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }

                Response.Redirect("/admin/notes.aspx");
           
        }
    }
}
