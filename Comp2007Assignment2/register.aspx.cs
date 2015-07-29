using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

using Comp2007Assignment2.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace Comp2007Assignment2
{
	public partial class register : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                // Default UserStore constructor uses the default connection string named: DefaultConnection
                var userStore = new UserStore<IdentityUser>();
                var manager = new UserManager<IdentityUser>(userStore);

                var user = new IdentityUser() { UserName = txtUsername.Text };
                IdentityResult result = manager.Create(user, txtPassword.Text);

                if (result.Succeeded)
                {
                    //lblStatus.Text = string.Format("User {0} was created successfully!", user.UserName);
                    //lblStatus.CssClass = "label label-success";

                    var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
                    var userIdentity = manager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                    authenticationManager.SignIn(new AuthenticationProperties() { }, userIdentity);

                    //add user to users db
                    using (DefaultConnection db = new DefaultConnection())
                    {

                        user u = new user();
                        u.userID = user.Id;
                        u.fName = txtFName.Text;
                        u.lName = txtLName.Text;

                        db.users.Add(u);
                        db.SaveChanges();

                    }
                    //redirect to main menu
                    Response.Redirect("/admin/bibleMenu.aspx");
                }
                else
                {
                    //lblStatus.Text = result.Errors.FirstOrDefault();
                    //lblStatus.CssClass = "label label-danger";
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("/errors.aspx");
            }
        }
	}
}