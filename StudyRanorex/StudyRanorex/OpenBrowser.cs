/*
 * Created by Ranorex
 * User: automation
 * Date: 2/13/2016
 * Time: 5:19 PM
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
    /// Description of OpenFirefox.
    /// </summary>
    [TestModule("F75B2692-1135-426F-B578-6047ED5E335E", ModuleType.UserCode, 1)]
    public class OpenBrowser : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public OpenBrowser()
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
            
            Host.Local.OpenBrowser("www.aa.com","chrome",true,true);
        }
    }
}
