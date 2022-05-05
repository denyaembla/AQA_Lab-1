using Allure.Commons;
using Allure_Reporting.Extensions;
using NUnit.Allure.Core;
using Allure_Reporting.Pages;
using Allure_Reporting.Services;
using Allure_Reporting.Steps;
using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Allure_Reporting.Tests;

[AllureNUnit]
public class StepsTest : BaseTest
{
    [Test]
    public void Steps_Test()
    {
        AllureLifecycle.Instance.WrapInStep(() => { Driver.Navigate().GoToUrl(Configurator.Url); },
            "Go to url");

        AllureLifecycle.Instance.WrapInStep(
            () => { _loginStep.SuccessLogin(Configurator.Username, Configurator.Password); },
            "Login with given credentials");

        AllureLifecycle.Instance.WrapInStep(() =>
            {
                InventoryPage.ItemsCollection.Count.Should().Be(6);
                _shoppingStep.AddItemToCartAndReturn(0);
                _shoppingStep.AddItemToCartAndReturn(1);
                _shoppingStep.GoToFirstCheckout();
                _checkoutStep.GoToFillingCheckout();
            },
            "Shopping");

        _checkoutStep.FillInfoAndCheckout(
            Configurator.Firstname,
            Configurator.Lastname,
            Configurator.Zipcode);

        var totalPrice =
            BaseStep.GetDataOfElementByClassNameUsingJsExecutor(Driver,
                "summary_subtotal_label", 1, "data");

        totalPrice.Should().Be("39.98");

        _checkoutStep.FinishShopping();
        CheckoutCompletePage.CheckoutTitle.Text.Should().Be("CHECKOUT: COMPLETE!");
    }
}
