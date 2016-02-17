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
    /// Description of FLL_JFK.
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
            Mouse.DefaultMoveTime = 30;
            Keyboard.DefaultKeyPressTime = 10;
            Delay.SpeedFactor = 1.0;
            
            Mouse.ScrollWheel(1000);
            
            //setting sequence to clear field
            String strClr = "{END}{SHIFT DOWN}{HOME}{SHIFT UP}{DELETE}";
            
            //setting search parametrs
            String strFrom = "FLL";
            String strTo = "JFK";
            String strDepart = System.DateTime.Now.AddDays(7).ToString("MM/dd/yyyy");
            String strReturn = System.DateTime.Now.AddDays(14).ToString("MM/dd/yyyy");
            
            //entering the search parametrs and searching
            repo.AA.HomePage.Reservation.fldFrom.PressKeys(strClr + strFrom);
            repo.AA.HomePage.Reservation.fldTo.PressKeys(strClr + strTo);
            repo.AA.HomePage.Reservation.fldDepart.PressKeys(strClr + strDepart);
            repo.AA.HomePage.Reservation.fldReturn.PressKeys(strClr + strReturn);
            repo.AA.HomePage.Reservation.bntSearch.Click();
            
            //Waiting for Fligth result to loaded within next 60 secs
            repo.AADocuments.Results.WaitForDocumentLoaded(6000);
                        
            //not ready - working with select, setting option
            //repo.AA.SearchResults.tabs.slctSort.SelectBox.FindSingle.SetAttributeValue(
            
            //browsing tabs with waiting them to be fully loaded
            repo.AA.SearchResults.lnkRefundable.Click();
            Validate.Exists(repo.AA.SearchResults.tabs.tabRefundableInfo);
            
            repo.AA.SearchResults.lnkBusiness.Click();
            Validate.Exists(repo.AA.SearchResults.tabs.tabBusinessInfo);
            
            repo.AA.SearchResults.lnkLowestFare.Click();
            Validate.Exists(repo.AA.SearchResults.lnkLowestFareInfo);
            
            //going to home page
            repo.AA.MainMenu.lnkHome.Click();
            
        }
    }
}
