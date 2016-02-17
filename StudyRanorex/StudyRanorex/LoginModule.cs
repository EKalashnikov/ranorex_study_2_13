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
            Mouse.DefaultMoveTime = 30;
            Keyboard.DefaultKeyPressTime = 10;
            Delay.SpeedFactor = 1.0;
            
            Mouse.ScrollWheel(1000);
            
            //entering credentials
            repo.AA.HomePage.LoginPanel.fldUserName.Click();
            repo.AA.HomePage.LoginPanel.fldUserName.PressKeys("username");
            repo.AA.HomePage.LoginPanel.fldLastName.Click();
            repo.AA.HomePage.LoginPanel.fldLastName.PressKeys("lastname");
            repo.AA.HomePage.LoginPanel.fldPwd.Click();
            repo.AA.HomePage.LoginPanel.fldPwd.PressKeys("pwd");
            repo.AA.HomePage.LoginPanel.btnLogIn.Click();
            
            //Delay.Duration(new Duration(10));
            //Delay.Milliseconds(1999);
            
            //checking poput text and closing popup
            Validate.Exists(repo.AA.WrongCredsPage.Popup.txtCantLoginInfo);
            repo.AA.WrongCredsPage.Popup.txtCantLogin.MoveTo();
            repo.AA.WrongCredsPage.Popup.btnClosePopup.Click();
                       
            //returing to home page
            repo.AA.MainMenu.lnkHome.Click();
            
            
            	
            	
        }
    }
}
