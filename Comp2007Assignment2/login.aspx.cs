﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//references
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Comp2007Assignment2
{
	public partial class login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
         
		}

        /**
          Login - authenticate entered user credientials.
         **/
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                var userStore = new UserStore<IdentityUser>();
                var userManager = new UserManager<IdentityUser>(userStore);
                var user = userManager.Find(txtUsername.Text, txtPassword.Text);

                if (user != null)
                {
                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);

                    authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = false }, userIdentity);
                    Response.Redirect("admin/bibleMenu.aspx");
                }
                else
                {
                    lblStatus.Text = "Invalid username or password.";
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }
        }


    }

}