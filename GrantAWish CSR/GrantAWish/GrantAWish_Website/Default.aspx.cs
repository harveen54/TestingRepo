using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GrantAWish;
using GrantAWish.Business_Services;
using GrantAWish.Database_Model;
using System.Web.UI.HtmlControls;
using GrantAWish.Business_Services.Wish;
using System.Linq;
using System.Xml.Linq;


    public partial class Default : System.Web.UI.Page
    {
        User userObj;
        List<Wishes> wishListObj;
        protected void Page_Load(object sender, EventArgs e)
        {
            HtmlGenericControl li = new HtmlGenericControl("li");

            //HtmlGenericControl anchor = new HtmlGenericControl("a");

            if (Session.Contents["User"] != null)
            {

                if (Session.Contents["User"].ToString() != "")
                {
                    //lblSigninMenu.Text = "Sign Out";
                    //lblSignupMenu.Text = "Hello";
                    HtmlAnchor anchor = new HtmlAnchor();
                    anchor.InnerText = "Sign Out";
                    anchor.Attributes.Add("runat", "server");
                    anchor.ServerClick += LogOut;
                    li.Controls.Add(anchor);
                    menuList.Controls.Add(li);
                }
                else
                {
                    //lblSigninMenu.Text = "Sign In";
                    //lblSignupMenu.Text = "Sign Up";
                    HtmlGenericControl anchorLocal = new HtmlGenericControl("a");
                    anchorLocal.Attributes.Add("href", "#0");
                    anchorLocal.InnerText = "Sign In";
                    li.Controls.Add(anchorLocal);
                    menuList.Controls.Add(li);

                    HtmlGenericControl li2 = new HtmlGenericControl("li");
                    HtmlGenericControl anchor2 = new HtmlGenericControl("a");
                    anchor2.Attributes.Add("href", "#0");
                    anchor2.InnerText = "Sign Up";
                    li2.Controls.Add(anchor2);
                    menuList.Controls.Add(li2);
                }
            }
            else
            {
                HtmlGenericControl anchorLocal = new HtmlGenericControl("a");
                anchorLocal.Attributes.Add("href", "#0");
                anchorLocal.Attributes.Add("class", "cd-signin");
                anchorLocal.InnerText = "Sign In";
                li.Controls.Add(anchorLocal);
                menuList.Controls.Add(li);

                HtmlGenericControl li2 = new HtmlGenericControl("li");
                HtmlGenericControl anchor2 = new HtmlGenericControl("a");
                anchor2.Attributes.Add("href", "#0");
                anchor2.Attributes.Add("class", "cd-signup");
                anchor2.InnerText = "Sign Up";
                li2.Controls.Add(anchor2);
                menuList.Controls.Add(li2);
            }

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // this.Request.Form.Get("emailSignIn");

            using (var loginService = new LoginService())
            {
                using (LoginService loginServiceObj = new LoginService())
                {
                    userObj = loginServiceObj.doLogin(emailSignIn.Text, signinpassword.Text);
                    if (userObj != null)
                    {
                        LoginSuccessful();
                    }
                    else
                    {
                        LoginFailed();
                    }
                }
            }
        }
        public void LoginSuccessful()
        {

            ////AppContainer ActiveUser = new AppContainer();
            ////ActiveUser.ActiveUser = userObj;

            //HttpContext.Current.Session["CartSessionKey"] = signin - email.Text;
            Session.Contents.Add("User", userObj);
            Response.Redirect("Default.aspx");
            //using (var usersShoppingCart = new CartService())
            //{
            //    String cartId = usersShoppingCart.GetCartId();
            //    usersShoppingCart.MigrateCart(cartId, txtUsername.Text);
            //}
            //if (Request.QueryString["Return"] != null)
            //{
            //    if (Request.QueryString["Return"].ToString() == "true" && Request.QueryString["TempID"] != null)
            //    {
            //        Response.Redirect("../Checkout/CheckoutAddress.aspx");
            //    }
            //}
            //else
            //    Response.Redirect("../Default.aspx");
        }

        public void LoginFailed()
        {
            //divExistsError.Visible = true;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //if (Page.IsValid)
            //{
            //    using (LoginService loginServiceObj = new LoginService())
            //    {
            //        userObj = loginServiceObj.doLogin(txtUsername.Text, txtPassword.Text);
            //        if (userObj != null)
            //        {
            //            LoginSuccessful();
            //        }
            //        else
            //        {
            //            LoginFailed();
            //        }
            //    }
            //}
        }

        protected void btnLogin_Click1(object sender, EventArgs e)
        {

        }
        private void LogOut(object sender, EventArgs e)
        {
            Session.Contents.Clear();
            Response.Redirect("Default.aspx");
        }
        protected void DataPagerProducts_PreRender(object sender, EventArgs e)
        {
            using (var wishService = new WishModuleService())
            {
                wishListObj = wishService.GetWishes();
                ListView1.DataSource = wishListObj;
                ListView1.DataBind();
            }

        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton b = sender as LinkButton;
            var id = (HiddenField)b.Parent.FindControl("HiddenField1");
            var lbGrant = (LinkButton)b.Parent.FindControl("LinkButton1");
            var lbCancel = (LinkButton)b.Parent.FindControl("LinkButton2");
            //var listView = (ListView)b.Parent.FindControl("ListView1");
            //var list= (List<Wishes>)listView.DataSource;
            

            //string str="you clciked " + id.Value;
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
            //  "err_msg",
            //  "alert('"+str+"');",
            //  true);

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue.Contains("Yes"))
            {
                using(var wishModule= new WishModuleService())
                {
                    int idLocal=Convert.ToInt32(id.Value);
                    wishModule.ChangeStatusOfWish(idLocal , 1,2);
                    lbCancel.Visible = true;
                    lbGrant.Visible = false;
                    lbCancel.Text = "hello";
                    lbGrant.Attributes.Add("onclick", "this.disabled=true;" + Page.ClientScript.GetPostBackEventReference(lbGrant, "").ToString());
                    //var listItem=list.First(w => w.wishId == idLocal);
                    //if(listItem!=null)
                    //{
                        
                    //}
                }
                //Your logic for OK button
            }
            else
            {
                //Your logic for cancel button
            }
        }
        protected void ListView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        protected void Button1_Click1(object sender, EventArgs e)
        {
           

        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            LinkButton b = sender as LinkButton;
            var id = (HiddenField)b.Parent.FindControl("HiddenField1");
            var lbGrant = (LinkButton)b.Parent.FindControl("LinkButton1");
            var lbCancel = (LinkButton)b.Parent.FindControl("LinkButton2");

            //string str="you clciked " + id.Value;
            //ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(),
            //  "err_msg",
            //  "alert('"+str+"');",
            //  true);

            string confirmValue = Request.Form["confirm_value"];
            if (confirmValue.Contains("Yes"))
            {
                using (var wishModule = new WishModuleService())
                {
                    wishModule.ChangeStatusOfWish(Convert.ToInt32(id.Value), 1,1);
                    lbCancel.Visible = false;
                    lbGrant.Visible = true;
                }
                //Your logic for OK button
            }
            else
            {
                //Your logic for cancel button
            }
        }
}
