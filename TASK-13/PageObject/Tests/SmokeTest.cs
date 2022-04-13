using System;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Pages;
using PageObject.Services;
using PageObject.Tests;

namespace PageObject.Smokey;

public class SmokeTest : BaseTest
{
    [Test]
    [Category("E2E Smoke Test")]
    public void E2E_SmokeTest()
    {
        var loginPage = new LoginPage(Driver, true);
        loginPage.UsernameInput.SendKeys(Configurator.Username);
        loginPage.PasswordInput.SendKeys(Configurator.Password);
        loginPage.LoginButton.Submit();
        
        var productsPage = new InventoryPage(Driver, false);
        productsPage.BackPack.Click();
        productsPage.AddBackpackToCart.Click();
        productsPage.BackToProducts.Click();
        productsPage.Flashlight.Click();
        productsPage.AddFlashlightToCart.Click();
        productsPage.GoToCart.Click();

        var cartPage = new CartPage(Driver, false);
        
        Assert.AreEqual("YOUR CART", cartPage.CartpageTitle.Text);
        Assert.AreEqual(2, cartPage.ItemsToBuy.Count);
        
        cartPage.CheckoutButton.Click();

        var checkoutStepOne = new CheckoutStepOnePage(Driver, false);
        
        Assert.AreEqual("CHECKOUT: YOUR INFORMATION", checkoutStepOne.Title.Text.Normalize());
        
        checkoutStepOne.FirstNameField.SendKeys(Configurator.Firstname);
        checkoutStepOne.LastNameField.SendKeys(Configurator.Lastname);
        checkoutStepOne.ZipField.SendKeys(Configurator.Zipcode);
        checkoutStepOne.ContinueButton.Click();

        var checkoutStepTwo = new CheckoutStepTwoPage(Driver, false);
        
        Assert.AreEqual("Item total: $39.98", checkoutStepTwo.TotalCost.Text);
        
        checkoutStepTwo.FinishButton.Click();

        var checkoutComplete = new CheckoutCompletePage(Driver, false);
        
        Assert.AreEqual("CHECKOUT: COMPLETE!", checkoutComplete.CheckoutTitle.Text);
    }
}
