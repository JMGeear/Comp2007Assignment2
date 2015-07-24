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

namespace Comp2007Assignment2.admin
{
    public partial class note : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind Book dropdownlist
                BindddlBook();
                ddlChapter.Enabled = false;
                ddlVerse.Enabled = false;

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
                //List<string> list = RetrieveDataFromXml.GetAllCountry();
                Int32 ID = Convert.ToInt32(Request.QueryString["ID"]);

                BibleBasicEnglish objB = (from b in db.BibleBasicEnglishes
                               where b.ID == ID
                               select b).FirstOrDefault();

                ddlBook.DataSource = objB.Book;
                ddlBook.DataBind();
                ddlBook.Items.Insert(0, new ListItem("Select Book", "-1"));
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
            // Remove region dropdownlist items
            ddlChapter.Items.Clear();
            string strCountry = string.Empty;
            strCountry = ddlBook.SelectedValue;
            List<string> list = null;

            // Bind Chapter dropdownlist based on Book value
            if (ddlBook.SelectedIndex != 0)
            {
                //list = RetrieveDataFromXml.GetRegionByCountry(strCountry);
                using (DefaultConnection db = new DefaultConnection())
                {
                    Int32 ID = Convert.ToInt32(Request.QueryString["ID"]);

                    BibleBasicEnglish objB = (from b in db.BibleBasicEnglishes
                                              where b.ID == ID
                                              select b).FirstOrDefault();

                    if (objB.Chapter != null && objB.Chapter != 0)
                    {
                        ddlChapter.Enabled = true;
                    }

                    ddlChapter.DataSource = objB.Chapter;
                    ddlChapter.DataBind();
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

            //List<string> list = null;
            //list = RetrieveDataFromXml.GetCityByRegion(strRegion);
            using (DefaultConnection db = new DefaultConnection())
            {
                Int32 ID = Convert.ToInt32(Request.QueryString["ID"]);

                BibleBasicEnglish objB = (from b in db.BibleBasicEnglishes
                                          where b.ID == ID
                                          select b).FirstOrDefault();

                ddlVerse.Items.Clear();
                ddlVerse.DataSource = objB.Verse;
                ddlVerse.DataBind();
                ddlVerse.Items.Insert(0, new ListItem("Select Verse", "-1"));

                // Initialize city dropdownlist selected index
                hdfDdlVerseSelectIndex.Value = "0";

                // Enable city dropdownlist when it has items
                if (objB.Verse > 0)
                {
                    ddlVerse.Enabled = true;
                }
                else
                {
                    ddlVerse.Enabled = false;
                }
            }
        }
    }
}