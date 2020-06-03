using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BlackJWebApp
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnPlay_Click(object sender, EventArgs e)
        {
            BtnPlay.Text = "LOADING";
            Timer1.Enabled = true;
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            BtnPlay.Text = "LOADING...";
            Timer2.Enabled = true;
        }
        protected void Timer2_Tick(object sender, EventArgs e)
        {
            Response.Redirect("~/PlayGame");
        }

    }
}