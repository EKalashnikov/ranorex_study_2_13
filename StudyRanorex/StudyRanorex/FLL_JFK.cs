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
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            
            Mouse.ScrollWheel(800);
            
            repo.AA.HomePage.Reservation.FieldFrom.PressKeys("{END}{SHIFT DOWN}{HOME}{SHIFT UP}{DELETE}FLL");
            repo.AA.HomePage.Reservation.FieldTo.PressKeys("{END}{SHIFT DOWN}{HOME}{SHIFT UP}{DELETE}JFK");
            repo.AA.HomePage.Reservation.FieldDepart.PressKeys("{END}{SHIFT DOWN}{HOME}{SHIFT UP}{DELETE}03/01/2016");
            repo.AA.HomePage.Reservation.FieldReturn.PressKeys("{END}{SHIFT DOWN}{HOME}{SHIFT UP}{DELETE}03/07/2016");
            repo.AA.HomePage.Reservation.bntSearch.Click();
            
            //repo.AA.SearchResults.SearchTimeout.Milliseconds(10000);
            Delay.Milliseconds(45000);
            repo.AA.SearchResults.lnkRefundable.Click();
            Delay.Milliseconds(15000);
            repo.AA.SearchResults.lnkHome.Click();
            
        }
    }
}
