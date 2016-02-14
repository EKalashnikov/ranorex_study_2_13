/*
 * Created by Ranorex
 * User: automation
 * Date: 2/13/2016
 * Time: 5:44 PM
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
    /// Description of LoginModule.
    /// </summary>
    [TestModule("C3F82D89-8032-43E0-B269-57E0ED096D53", ModuleType.UserCode, 1)]
    public class LoginModule : ITestModule
    {
    	public static StudyRanorexRepository repo = StudyRanorexRepository.Instance;
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public LoginModule()
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
            
            Mouse.ScrollWheel(500);
            
            
            repo.AmericanAirlines.Content.LoginPanel.FieldUserName.Click();
            repo.AmericanAirlines.Content.LoginPanel.FieldUserName.PressKeys("username");
            repo.AmericanAirlines.Content.LoginPanel.FieldLastName.Click();
            repo.AmericanAirlines.Content.LoginPanel.FieldLastName.PressKeys("lastname");
            repo.AmericanAirlines.Content.LoginPanel.FieldPwd.Click();
            repo.AmericanAirlines.Content.LoginPanel.FieldPwd.PressKeys("pwd");
            repo.AmericanAirlines.Content.LoginPanel.BtnLogIn.Click();
            
            //Delay.Duration(new Duration(10));
            //Validate.Exists(repo.AmericanAirlines.Popup.txtCantLoginInfo);
            
            Delay.Milliseconds(1999);
            //repo.AmericanAirlines.Popup.txtCantLogin.MoveTo();
            //repo.AmericanAirlines.Popup.btnClosePopup.Click();
            repo.NewApp.btnNew.Click();
            
            	
            	
        }
    }
}
