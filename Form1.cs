using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace member
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btn_Prv_Click(object sender, EventArgs e)
        {

        }

        private void btn_Prv_MouseClick(object sender, MouseEventArgs e)
        {
            string sOpt = "";

            if (tbx_FullName.Text != "")
            { sOpt += "姓名： " + tbx_FullName.Text+"\n";}

            if (rdbtn_GdF.Checked == true)
            { sOpt += "性別：" + rdbtn_GdF.Text + "\n"; }
            else
            { sOpt += "性別：" + rdbtn_GdM.Text + "\n"; }


            if (rdbtn_BTA.Checked == true)
            { sOpt += "血型：" + rdbtn_BTA.Text + "\n"; }
            else if (rdbtn_BTB.Checked == true)
            { sOpt += "血型：" + rdbtn_BTB.Text + "\n"; }
            else if (rdbtn_BTO.Checked == true)
            { sOpt += "血型：" + rdbtn_BTO.Text + "\n"; }
            else
            { sOpt += "血型：" + rdbtn_BTAB.Text + "\n"; }


            if(cbx_BDY.Text != "" && cbx_BDM.Text != "" && cbx_BDD.Text != "")
            { sOpt += "生日： " + cbx_BDY.Text + " 年 " + cbx_BDM.Text + " 月 " + cbx_BDD.Text + " 日 "; }

            lab_Opt.Text = sOpt;

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //下方產生月份的下拉選單 清單項目內容
            for (int i = 1 ; i <= 12 ; i++) 
            { cbx_BDM.Items.Add(i); }
           
            //下方指定 月份下拉選單自動取得系統月份值，做為選單的預設值
            cbx_BDM.Text = DateTime.Today.Month.ToString();

            //下方產生年份的下拉選單 清單項目(今天的年-> 130年前的年)內容
            int iYoT = DateTime.Today.Year;
            //自動取得系統 年的值，做為選單的預設值
            cbx_BDY.Text = DateTime.Today.Year.ToString();
            for (int i = iYoT; i >= iYoT - 130; i--) 
            { cbx_BDY.Items.Add(i); }

            //下方產生日的下拉選單 清單項目
            vSetDay();
        }

        private void cbx_BDY_SelectedIndexChanged(object sender, EventArgs e)
        { vSetDay(); }

        private void cbx_BDM_SelectedIndexChanged(object sender, EventArgs e)
        { vSetDay(); }

        private void vSetDay() 
        {
            //下方產生日的下拉選單 清單項目
            cbx_BDD.Items.Clear();
            int iMth = int.Parse(cbx_BDM.Text); //取得使用者目前取得的月份值

            int iDays = 0; //取得使用者選擇月份值的天數
            if (iMth == 2)
            {
                int iYr = int.Parse(cbx_BDY.Text);
                if (iYr % 400 == 0)  //判斷是否為閏年
                { iDays = 29; }
                else
                {
                    if (iYr % 4 == 0 && iYr % 100 != 0) //判斷是否為閏年
                    { iDays = 29; }
                    else
                    { iDays = 28; }
                }

            }
            else if (iMth == 4 || iMth == 6 || iMth == 9 || iMth == 11)
            { iDays = 30; }
            else
            { iDays = 31; }


            for (int i = 1; i <= iDays; i++)
            { cbx_BDD.Items.Add(i); }
        }
    }
}
