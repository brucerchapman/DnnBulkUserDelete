using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dnn.BulkUserDelete.Console
{
    public partial class Main : Form
    {
        private static string horizontalLine = "---------------------------------------";
        private string logFileName = null;
        public Main()
        {
            InitializeComponent();
            LogLine ( "Dnn Bulk User Delete " + this.ProductVersion + " started at " + System.DateTime.Now.ToString("dd/MMM/yyyy  hh:mm:ss") + Environment.NewLine);
            LogLine ( "<-- Enter a site alias to start.  Don't include the http://" + Environment.NewLine);
            txtPortalAlias.Text = Properties.Settings.Default.PortalAlias;
            txtUserName.Text = Properties.Settings.Default.UserName;
            lblBatchLength.Text = tckSpeed.Value.ToString() + " Seconds Between Batches";
            
        }
        #region events
        private void btnPingAnon_Click(object sender, EventArgs e)
        {
            string portalAlias = txtPortalAlias.Text;
            DateTime start = DateTime.Now;
            LogLine ( "Starting Anonymous Server Ping to " + portalAlias + " at : " + start.ToShortTimeString() + Environment.NewLine);
            string result = JsonHelper.FormatJson(PingServerAnon(portalAlias));
            DateTime stop = DateTime.Now;
            LogLine ( "Finished Anonymous Server Ping at " + stop.ToShortTimeString() + "; Elapsed time : " + (stop - start).TotalSeconds.ToString() + " seconds");
            LogLine ( "Result:" + Environment.NewLine + result + Environment.NewLine + Environment.NewLine);
        }
        private void txtPortalAlias_TextChanged(object sender, EventArgs e)
        {
            if (txtPortalAlias.Text.Length > 0)
                EnableButtons();
            else
                DisableButtons();
        }

        private void btnPingHost_Click(object sender, EventArgs e)
        {
            string portalAlias = txtPortalAlias.Text;
            DateTime start = DateTime.Now;
            LogLine("Starting Authenticated Server Ping to " + portalAlias + " at : " + start.ToShortTimeString() + Environment.NewLine);
            string result = JsonHelper.FormatJson(PingServerAuthenticated(portalAlias, txtUserName.Text, txtPassword.Text));
            DateTime stop = DateTime.Now;
            LogLine("Finished Authenticated Server Ping at " + stop.ToShortTimeString() + "; Elapsed time : " + (stop - start).TotalSeconds.ToString() + " seconds");
            LogLine("Result:" + Environment.NewLine + result + Environment.NewLine + Environment.NewLine);

        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Properties.Settings.Default.PortalAlias = txtPortalAlias.Text;
                Properties.Settings.Default.UserName = txtUserName.Text;
                Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
            }
        }


        private void btnCheckSoftDeletedUsers_Click_1(object sender, EventArgs e)
        {
            string portalAlias = txtPortalAlias.Text;
            DateTime start = DateTime.Now;
            LogLine("Starting Soft Deleted Users Check to " + portalAlias + " at : " + start.ToShortTimeString() + Environment.NewLine);
            string result = JsonHelper.FormatJson(GetSoftDeletedUsers(portalAlias, txtUserName.Text, txtPassword.Text));
            DateTime stop = DateTime.Now;
            LogLine("Finished Soft Deleted Users Check at " + stop.ToShortTimeString() + "; Elapsed time : " + (stop - start).TotalSeconds.ToString() + " seconds");
            LogLine("Result:" + Environment.NewLine + result + Environment.NewLine + Environment.NewLine);
        }
        private void btnHardDeleteNextUser_Click_1(object sender, EventArgs e)
        {

            int batchSize = (int)updBatchSize.Value;
            bool testMode = chkTestMode.Checked;
            if (testMode || MessageBox.Show("This will delete the first " + batchSize.ToString() + " soft-deleted user(s) in the Portal as identified by the Portal Alias.  There is no 'undo'.  Continue?", "Confirm Delete Next User", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                string portalAlias = txtPortalAlias.Text;
                DateTime start = DateTime.Now;
                LogLine(horizontalLine);
                if (testMode) LogLine("== Test mode only - no actual deletes committed ==");
                LogLine("Starting Hard Delete " + batchSize.ToString() + " User(s) from " + portalAlias + " at : " + start.ToShortTimeString() + Environment.NewLine);
                string result = null;
                bool retVal = HardDeleteNextUserBatch(portalAlias, txtUserName.Text, txtPassword.Text, batchSize, testMode, chkFastDelete.Checked, out result);
                DateTime stop = DateTime.Now;
                if (retVal)
                {
                    result = JsonHelper.FormatJson(result);
                }
                
                LogLine("Finished Hard Delete " + batchSize.ToString() + " User(s) at " + stop.ToShortTimeString() + "; Elapsed time : " + (stop - start).TotalSeconds.ToString() + " seconds");
                if (retVal)
                {
                    Newtonsoft.Json.Linq.JObject jsonResult = Newtonsoft.Json.Linq.JObject.Parse(result);
                    int usersAffected = -1;
                    int.TryParse(jsonResult["UsersAffected"].ToString(), out usersAffected);
                }
                LogLine("Result:" + Environment.NewLine + result + Environment.NewLine + Environment.NewLine);
                if (retVal)
                    LogLine("Operation was succesful");
                else
                    LogLine("Operation failed");
                LogLine(horizontalLine);
            }
        }

        #endregion
        #region service calls

        private string PingServerAnon(string alias)
        {
            string result = null;
            string pingUrl = DnnRequest.GetUrl(alias, "Dnn_BulkUserDelete", "BulkUserDelete", "AnonymousPing", false);
            System.Net.HttpStatusCode statusCode;
            string errorMsg;
            result = DnnRequest.GetRequest(pingUrl,"", "", ContentType.JSON, out statusCode, out errorMsg);
            result = ReturnResult(pingUrl, statusCode, errorMsg, result);

            return result;
        }
        private string PingServerAuthenticated(string alias, string username, string password)
        {
            string result = null;
            string pingUrl = DnnRequest.GetUrl(alias, "Dnn_BulkUserDelete", "BulkUserDelete", "AdministratorPing", false);
            System.Net.HttpStatusCode statusCode;
            string errorMsg;
            result = DnnRequest.GetRequest(pingUrl, username, password, ContentType.JSON, out statusCode, out errorMsg);
            result = ReturnResult(pingUrl, statusCode, errorMsg, result);

            return result;
        }
        private string GetSoftDeletedUsers(string alias, string username, string password)
        {
            string result = null;
            string url = DnnRequest.GetUrl(alias, "Dnn_BulkUserDelete", "BulkUserDelete", "GetSoftDeletedUsers", false);
            System.Net.HttpStatusCode statusCode; string errorMsg;
            result = DnnRequest.GetRequest(url, username, password,  ContentType.JSON, out statusCode, out errorMsg);
            result = ReturnResult(url, statusCode, errorMsg, result);
            return result;
        }
        private bool HardDeleteNextUserBatch(string alias, string username, string password, int batchSize, bool testMode, bool useFastDelete, out string result)
        {
            result = null;
            bool retVal = false;
            string url = DnnRequest.GetUrl(alias, "Dnn_BulkUserDelete", "BulkUserDelete", "HardDeleteNextUsers", false);
            System.Net.HttpStatusCode statusCode; string errorMsg;
            System.Net.CookieContainer cookies = new System.Net.CookieContainer();
            //really should use a string format here to build the JSON but quick and dirty does the job
            string requestBody = "{ 'actionName' : 'hardDelete', 'actionNumber' : " + batchSize.ToString() + ", 'testRun': '" + testMode.ToString() + "', 'useFastDelete': '" +  useFastDelete.ToString() + "'}";
            //post the request to delete the batch of users
            result = DnnRequest.PostRequest(url, username, password, requestBody, ContentType.JSON, out statusCode, out errorMsg, ref cookies);
            result = ReturnResult(url, statusCode, errorMsg, result);
            if (statusCode == System.Net.HttpStatusCode.OK)
            {
                //get the call return value form the return JSON
                if (string.IsNullOrEmpty(result) == false)
                {
                    var jsonResult = Newtonsoft.Json.Linq.JObject.Parse(result);
                    retVal = bool.Parse(jsonResult["Success"].ToString());
                }
            }
            return retVal;
        }
        private void DeleteUserBatch(out int usersAffected, out int usersRemaining, out int lastElapsedSeconds)
        {
            //called by the timer to delete the batch of users
            usersAffected = -1; usersRemaining = -1; lastElapsedSeconds = 0;
            int interval = (int)(timBatchTimer.Interval / 1000);
            int batchSize = (int)updBatchSize.Value;
            bool testMode = chkTestMode.Checked;
            LogLine("");
            if (testMode) LogLine("== Test mode only - no actual deletes committed ==");
            DateTime start = DateTime.Now; DateTime end = DateTime.Now;
            LogLine("Submitting Request for deletion of " + batchSize.ToString() + " users at " + DateTime.Now.ToString("hh:mm:ss"));
            string result = "";
            bool retVal = HardDeleteNextUserBatch(txtPortalAlias.Text, txtUserName.Text, txtPassword.Text,  batchSize, testMode, chkFastDelete.Checked, out result);
            end = DateTime.Now;
            LogLine(result);
            LogLine("Completed at " + end.ToString("hh:mm:ss") + "; call length: " + (end - start).TotalSeconds.ToString() + " seconds");
            lastElapsedSeconds = (int)(end - start).TotalSeconds;
            //peek insdie the return JSON for information about the call successs
            bool callSuccess = false; Newtonsoft.Json.Linq.JObject jsonResult=null;
            if (string.IsNullOrEmpty(result) == false || retVal == false)
            {
                try
                {
                    jsonResult = Newtonsoft.Json.Linq.JObject.Parse(result);
                    callSuccess = bool.Parse(jsonResult["Success"].ToString());
                }
                catch (Exception jsonEx)
                {
                    result += Environment.NewLine + "JSON result parsing failed :" + jsonEx.Message;
                }
            }
            if (retVal == false || callSuccess == false)
            {
                LogLine("Error Found.  Processing will continue.");
            }
            else
            {
                //check to see if the number of rows affects is less than the batch size.  IF so, we're finished
                if (int.TryParse(jsonResult["UsersAffected"].ToString(), out usersAffected))
                {
                    if (usersAffected < batchSize)
                    {
                        //completd the batch
                        LogLine("Batch Complete at " + DateTime.Now.ToString("hh:mm:ss"));
                        LogLine(horizontalLine);
                        timBatchTimer.Enabled = false;
                        btnDeleteBatches.Text = "Start Deleting Batches";
                    }
                }
                
            }
            if (jsonResult != null)
                //get the users remaining
                int.TryParse(jsonResult["UsersRemaining"].ToString(), out usersRemaining);
            
                
        }
        #endregion
        #region UI Calls
        private void EnableButtons()
        {
            btnPingAnon.Enabled = true;
            btnPingHost.Enabled = true;
            btnCheckSoftDeletedUsers.Enabled = true;
            btnHardDeleteNextUser.Enabled = true;
            btnDeleteBatches.Enabled = true;
        }
        private void DisableButtons()
        {
            btnPingAnon.Enabled = false;
            btnPingHost.Enabled = false;
            btnCheckSoftDeletedUsers.Enabled = false;
            btnHardDeleteNextUser.Enabled = false;
            btnDeleteBatches.Enabled = false;
        }
        private string ReturnResult(string url, System.Net.HttpStatusCode statusCode, string errorMsg, string originalResult)
        {
            string result = originalResult;
            switch (statusCode)
            {
                case System.Net.HttpStatusCode.InternalServerError:
                    result = "Call to " + url + " resulted in 500 Server Error.  Check Error field.";
                    break;
                case System.Net.HttpStatusCode.NotFound:
                    result = "Call to " + url + " resulted in 404 Not Found.  Check Portal Alias used.";
                    break;
                case System.Net.HttpStatusCode.NoContent:
                    result = "Call to " + url + " failed with No Content returned.  Possible timeout or other issue.";
                    break;
                case System.Net.HttpStatusCode.OK:
                    //everything OK
                    break;
            }
            return result;
        }
        private void LogLine(string line)
        {
            line = line.Replace("\\r\\n", Environment.NewLine);//put in any newlines
            txtLogOutput.AppendText(line + Environment.NewLine);

            try
            {
                if (logFileName == null)
                    logFileName = Application.StartupPath + "\\BulkUserDelete_" + DateTime.Now.ToString("yyyy-MM-dd-hh-ss") + ".log";
                //now log to file
                if (!File.Exists(logFileName)) //No File? Create
                {
                    var fs = File.Create(logFileName);
                    fs.Close();
                }
                File.AppendAllText(logFileName, line + Environment.NewLine);
            }
            finally
            {
                //do nothing?
            }
        }
        private void UpdateDeletedUsersUI(int usersAffected, int usersRemaining, int interval, int lastElapsedSeconds)
        {
            int alreadyDeleted = 0;
            int.TryParse(txtUsersDeleted.Text, out alreadyDeleted);
            int newDeletedTotal = alreadyDeleted + usersAffected;
            txtUsersDeleted.Text = newDeletedTotal.ToString("#,##0");
            txtRemainingUsers.Text = usersRemaining.ToString("#,##0");
            int secondsToDelete = (usersRemaining / (int)updBatchSize.Value) * (interval + lastElapsedSeconds);
            TimeSpan minutesToDelete = new TimeSpan(0, 0, secondsToDelete);
            txtTimeToComplete.Text = minutesToDelete.ToString();
        }
        #endregion

        private void btnDeleteBatches_Click(object sender, EventArgs e)
        {
            if (btnDeleteBatches.Text == "Start Deleting Batches")
            {
                if (chkTestMode.Checked || MessageBox.Show("This will delete Batches of " + updBatchSize.Value.ToString() + " soft-deleted user(s) in the Portal as identified by the Portal Alias until there are no more soft-dleeted users, or the process is stopped.  There is no 'undo'.  Continue?", "Confirm Start Batch Delete", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
                {
                    btnDeleteBatches.Text = "Stop Deleting Batches";
                    int batchSpeed = tckSpeed.Value;
                    LogLine(horizontalLine);
                    LogLine("Batch Processing started by User at " + DateTime.Now.ToString("hh:mm:ss") + "  Deleting " + updBatchSize.Value.ToString() + " users every " + batchSpeed.ToString() + " seconds");

                    timBatchTimer.Interval = batchSpeed * 1000;
                    timBatchTimer.Enabled = true;
                }
            }
            else
            {
                timBatchTimer.Enabled = false;
                LogLine("");
                LogLine("Batch Processing stopped by User at " + DateTime.Now.ToString("hh:mm:ss"));
                LogLine(horizontalLine);

                btnDeleteBatches.Text = "Start Deleting Batches";
            }

        }

        private void timBatchTimer_Tick(object sender, EventArgs e)
        {
            //on tick, delete a batch of users
            int usersAffected = 0; int usersRemaining = 0;
            timBatchTimer.Enabled = false;//disable timer while we run task
            try
            {
                int lastElapsedSeconds = 0;
                DeleteUserBatch(out usersAffected, out usersRemaining, out lastElapsedSeconds);
                UpdateDeletedUsersUI(usersAffected, usersRemaining, tckSpeed.Value, lastElapsedSeconds);
            }
            catch (Exception ex)
            {
                LogLine("Failure in Batch Deletion: " + ex.Message + Environment.NewLine + ex.StackTrace);
            }
            finally
            {
                timBatchTimer.Enabled = true;//re-enable timer to start again.
            }
        }

        private void tckSpeed_Scroll(object sender, EventArgs e)
        {
            timBatchTimer.Interval = tckSpeed.Value * 1000;
            lblBatchLength.Text = tckSpeed.Value.ToString() + " Seconds Between Batches";
        }

        private void chkFastDelete_CheckedChanged(object sender, EventArgs e)
        {

        }



 

        

        



    }
}
