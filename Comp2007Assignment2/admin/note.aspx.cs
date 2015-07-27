﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

//reference our entity framework models
using Comp2007Assignment2.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace Comp2007Assignment2.admin
{
    public partial class note : System.Web.UI.Page
    {
        String Book, VerseText;
        Int32 Chapter, Verse;
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
                ddlChapter.Enabled = true;
                ddlVerse.Enabled = true;

                // Insert one item to dropdownlist top
                ddlChapter.Items.Insert(0, new ListItem("Select Chapter", "-1"));
                ddlVerse.Items.Insert(0, new ListItem("Select Verse", "-1"));

                // Initialize Verse dropdownlist selected index
                hdfDdlVerseSelectIndex.Value = "0";
            }
        }

        public void BindddlBook()
        {
            using (DefaultConnection db = new DefaultConnection())
            {
               
                var objB = (from b in db.BibleBasicEnglishes
                            orderby b.ID
                            group b by b.Book into d                         
                            select new {Book = d.Key, books = d.ToList()});

                ddlBook.DataSource = objB.ToList();
                ddlBook.DataBind();
                ddlBook.SelectedValue = objB.ToString();
                ddlBook.SelectedValue = Book;
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
            else if (hdfDdlVerseSelectIndex.Value == "0" && strResult == string.Empty)
            {
                strResult = "Please select a Verse.";
            }
            else
            {
                strResult = "You selected Book: " + ddlBook.SelectedValue
                    + " ; Chapter: " + ddlChapter.SelectedValue
                    + " ; Verse: " + ddlVerse.Items[iVerseSelected].Value;
            }

            lblResult.Text = strResult;
        }

        protected void ddlBook_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Remove Chapter dropdownlist items
            ddlChapter.Items.Clear();
            string strBook = string.Empty;
            strBook = ddlBook.SelectedValue;
            

            // Bind Chapter dropdownlist based on Book value
            if (ddlBook.SelectedIndex != 0)
            {
                
                using (DefaultConnection db = new DefaultConnection())
                {                 
                    var objC = (from c in db.BibleBasicEnglishes
                                where c.Chapter == Chapter
                                select c);

                    if (objC != null )
                    {
                        ddlChapter.Enabled = true;
                    }

                        ddlChapter.DataSource = objC;
                    ddlChapter.DataBind();
                    ddlChapter.SelectedValue = objC.ToString();
                }
            }
            else
            {
                ddlChapter.Enabled = false;
            }

            ddlChapter.Items.Insert(0, new ListItem("Select Chapter", "-1"));

            // Clear Verse dropdownlist
            ddlVerse.Enabled = false;
            ddlVerse.Items.Clear();
            ddlVerse.Items.Insert(0, new ListItem("Select Verse", "-1"));

            // Initialize verse dropdownlist selected index
            hdfDdlVerseSelectIndex.Value = "0";
        }

        protected void ddlChapter_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Bind city dropdownlist based on region value
            string strChapter = string.Empty;
            strChapter = ddlChapter.SelectedValue;

            
            using (DefaultConnection db = new DefaultConnection())
            {
                var Verse = (from v in db.BibleBasicEnglishes
                             orderby v.Verse
                             select v);

                ddlVerse.Items.Clear();
                ddlVerse.DataSource = Verse;
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
            //do insert or update
            using (DefaultConnection db = new DefaultConnection())
            {
                //blog objP = new blog();
                Int32 postID = 0;

                if (!String.IsNullOrEmpty(Request.QueryString["postID"]))
                {
                    postID = Convert.ToInt32(Request.QueryString["postID"]);

                    var objP = (from p in db.blog_post
                            join t in db.blog_title on p.blogID equals t.blogID
                            where p.postID == postID
                            select p).FirstOrDefault();
                

                //populate the course from the input form
               // objP.title = titleTxt.Text;
                objP.post = txtBlog.Text;
                }

                if (String.IsNullOrEmpty(Request.QueryString["postID"]))
                {
                    //add
                    //db.blog_post.Add(objP);
                }

                //save and redirect
                db.SaveChanges();
                Response.Redirect("notes.aspx");
            }
        }

    }
}