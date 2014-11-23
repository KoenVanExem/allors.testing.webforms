// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TransferTest.cs" company="allors bvba">
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
    using Allors.Testing.Webforms.Extensions;
    using NUnit.Framework;

    [WebformsTest("TransferFromPage.aspx")]
    public class TransferTest : WebformsTest
    {
        [PreRender(1)]
        public void ClickOnTransfer()
        {
            this.Browser.Click(this.Page.Select<LinkButton>("lnkTransferTo"));
        }

        [PreRender(2)]
        public void Transferred()
        {
            Assert.Fail("Transfer didn't happen");
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

        protected override void OnTest()
        {
            this.Get("TransferFromPage.aspx");
            this.Post("TransferFromPage.aspx"); // Transferred
            this.Post("TransferToPage.aspx");
            this.Post("TransferToPage.aspx");
        }
    }
}