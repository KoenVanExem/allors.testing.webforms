// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RedirectTest.cs" company="allors bvba">
//   Copyright 2008-2014 Allors bvba.
//   
//   This program is free software: you can redistribute it and/or modify
//   it under the terms of the GNU Lesser General Public License as published by
//   the Free Software Foundation, either version 3 of the License, or
//   (at your option) any later version.
//   
//   This program is distributed in the hope that it will be useful,
//   but WITHOUT ANY WARRANTY; without even the implied warranty of
//   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//   GNU Lesser General Public License for more details.
//   
//   You should have received a copy of the GNU Lesser General Public License
//   along with this program.  If not, see http://www.gnu.org/licenses.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Allors.Testing.Webforms.Tests
{
    using System.Web.UI.WebControls;

    using NUnit.Framework;

    [WebformsTest("RedirectFromPage.aspx")]
    public class RedirectTest : WebformsTest
    {
        [PreRender(1)]
        public void ClickOnRedirect()
        {
            this.Browser.Click(this.Page.Select<LinkButton>("lnkRedirectTo"));
        }

        [PreRender(2)]
        public void ProcessRedirect()
        {
            Assert.Fail("Redirect didn't happen");
        }

        [PreRender(3)]
        public void FillInTextBoxAndPressClick()
        {
            this.Page.Select<TextBox>("TextBox").Text = "Hello";

            this.Browser.Click(this.Page.Select<Button>("Button"));
        }

        [PreRender(4)]
        public void ProcessClick()
        {
            Assert.AreEqual("Hello", this.Page.Select<Label>("Label").Text);
        }
    }
}