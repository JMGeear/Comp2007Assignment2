﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//reference our entity framework models
using Comp2007Assignment2.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Comp2007Assignment2.admin
{
    public partial class notes : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            var userID = User.Identity.GetUserId();

            try
            {
                using (DefaultConnectionEF db = new DefaultConnectionEF())
                {
                    blogUser id = (from objs in db.blogUsers
                               where objs.userID == userID
                               select objs).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }

            if (!IsPostBack)
            {
                getNotes();
            }
        }


        /**
         * This function will get the current users ID based on their login.
         * It will populate a gridview of all the notes the user has created.
         **/
        protected void getNotes()
        {
            var userStore = new UserStore<IdentityUser>();
            var manager = new UserManager<IdentityUser>(userStore);
            var userID = User.Identity.GetUserId();

            try
            {
                using (DefaultConnectionEF db = new DefaultConnectionEF())
                {
                    var objE = (from bg in db.blogs

                                join br in db.blog_references on bg.blogID equals br.blogID
                                join bt in db.blog_title on bg.blogID equals bt.blogID
                                join bp in db.blog_post on bg.blogID equals bp.blogID
                                where bg.userID == userID
                                select new { bg.blogID, br.bookName, br.chapterID, br.verseID, bt.title, bp.post });

                    grdNotes.DataSource = objE.ToList();
                    grdNotes.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }
        }


        /**
         * This method will delete a note by getting the row index and using the blogID
         * it will remove all instances from all tables.
         **/
        protected void grdNotes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            Int32 selectedRow = e.RowIndex;

            //get the selected StudentID using the grids Data Key collection
            Int32 blogID = Convert.ToInt32(grdNotes.DataKeys[selectedRow].Values["blogID"]);
            
                using (DefaultConnectionEF db = new DefaultConnectionEF())
                {
                    //query for blog result
                    blog b = (from objs in db.blogs
                              where objs.blogID == blogID
                              select objs).FirstOrDefault();

                    //query for blog post result
                    blog_post bp = (from objs in db.blog_post
                                    where objs.blogID == blogID
                                    select objs).FirstOrDefault();

                    //query for blog title result
                    blog_title bt = (from objs in db.blog_title
                                     where objs.blogID == blogID
                                     select objs).FirstOrDefault();

                    //query for blog references result
                    blog_references br = (from objs in db.blog_references
                                          where objs.blogID == blogID
                                          select objs).FirstOrDefault();

                    //remove blog references
                    db.blog_references.Remove(br);
                    db.SaveChanges();
                    //remove blog title
                    db.blog_title.Remove(bt);
                    db.SaveChanges();
                    //remove blog post
                    db.blog_post.Remove(bp);
                    db.SaveChanges();
                    //remove blog
                    db.blogs.Remove(b);
                    db.SaveChanges();
                }
                //refresh the grid
                getNotes();
        }



        protected void grdNotes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdNotes.PageSize = e.NewPageIndex;
            getNotes();
        }



        /**
         * This function will set the page size. 
         **/
        protected void ddlPageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //set new page size
            grdNotes.PageSize = Convert.ToInt32(ddlPageSize.SelectedValue);
            getNotes();
        }
    }
}
