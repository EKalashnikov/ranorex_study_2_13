/*
 * Created by Ranorex
 * User: automation
 * Date: 2/14/2016
 * Time: 4:08 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace StudyRanorex
{
    /// <summary>
    /// Description of FLL_SVO.
    /// </summary>
    [TestModule("F5226F6D-9F9C-4F63-9B73-5881852D4A42", ModuleType.UserCode, 1)]
    public class FLL_JFK : ITestModule
    {
		public static StudyRanorexRepository repo = StudyRanorexRepository.Instance;
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public FLL_JFK()
        {
            // Do not delete - a parameterless constructor is required!
        }

        /// <summary>
        /// Performs the playback of actions in this module.
        /// </summary>
        /// <remarks>You should not call this method directly, instead pass the module
        /// instance to the <see cref="TestModuleRunner.Run(ITestModule)"/> method
        /// that will in turn invoke this method.</remarks>
        void ITestModule.Run()
        {
            Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 10;
            Delay.SpeedFactor = 1.0;
            
            Mouse.ScrollWheel(1000);
            
            String strClr = "{END}{SHIFT DOWN}{HOME}{SHIFT UP}{DELETE}";
            String strFrom = "FLL";
            String strTo = "JFK";
            String strDepart = System.DateTime.Now.AddDays(7).ToString("MM/dd/yyyy");
            String strReturn = System.DateTime.Now.AddDays(14).ToString("MM/dd/yyyy");
            
            repo.AA.HomePage.Reservation.FieldFrom.PressKeys(strClr + strFrom);
            repo.AA.HomePage.Reservation.FieldTo.PressKeys(strClr + strTo);
            repo.AA.HomePage.Reservation.FieldDepart.PressKeys(strClr + strDepart);
            repo.AA.HomePage.Reservation.FieldReturn.PressKeys(strClr + strReturn);
            repo.AA.HomePage.Reservation.bntSearch.Click();
            
            //Delay.Milliseconds(45000);   
            WebDocument docWaiting = "/dom[@caption~'We are processing your request']";
            docWaiting.WaitForDocumentLoaded(60000);            
            WebDocument docResultList = "/dom[@caption~'Flight results']";
            docResultList.WaitForDocumentLoaded(60000);
                        
            repo.AA.SearchResults.lnkRefundable.Click();
            
            //Delay.Milliseconds(10000);
            Validate.Exists(repo.AAResults.Results.tabs.tabRefundableInfo, "Check Object '{0}'",false);
            
            repo.AA.SearchResults.lnkHome.Click();
            
        }
    }
}
