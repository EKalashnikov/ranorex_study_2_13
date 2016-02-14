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
    public class FLL_SVO : ITestModule
    {
        /// <summary>
        /// Constructs a new instance.
        /// </summary>
        public FLL_SVO()
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
            
            
        }
    }
}
