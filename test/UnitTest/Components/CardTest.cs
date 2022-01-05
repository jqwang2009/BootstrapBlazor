﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Components;
using Microsoft.AspNetCore.Components;
using UnitTest.Core;
using Xunit;

namespace UnitTest.Components;

public class CardTest : TestBase
{
    private const string Content = "TestComponent-Card";

    [Fact]
    public void Header_Ok()
    {
        var cut = Context.RenderComponent<Card>(builder => builder.Add(a => a.CardHeader, CreateComponent()));
        Assert.Contains(Content, cut.Markup);
    }

    [Fact]
    public void Body_Ok()
    {
        var cut = Context.RenderComponent<Card>(builder => builder.Add(a => a.CardBody, CreateComponent()));
        Assert.Contains(Content, cut.Markup);
    }

    [Fact]
    public void Footer_Ok()
    {
        var cut = Context.RenderComponent<Card>(builder => builder.Add(a => a.CardFooter, CreateComponent()));
        Assert.Contains(Content, cut.Markup);
    }

    [Fact]
    public void Color_Ok()
    {
        var cut = Context.RenderComponent<Card>(builder => builder.Add(a => a.Color, Color.Primary));
        Assert.Contains("text-primary", cut.Markup);
    }

    [Fact]
    public void IsCenter_Ok()
    {
        var cut = Context.RenderComponent<Card>(builder => builder.Add(a => a.IsCenter, true));
        Assert.Contains("text-center", cut.Markup);
    }


    private static RenderFragment CreateComponent() => builder =>
    {
        builder.OpenElement(0, "div");
        builder.AddContent(1, Content);
        builder.CloseElement();
    };
}
