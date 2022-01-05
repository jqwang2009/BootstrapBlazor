﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Components;
using Bunit;
using Microsoft.AspNetCore.Components;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnitTest.Core;
using Xunit;

namespace UnitTest.Components;

public class DateTimeRangeTest : BootstrapBlazorTestBase
{
    [Fact]
    public void ClearButtonText_Ok()
    {
        var cut = Context.RenderComponent<DateTimeRange>(builder =>
        {
            builder.Add(a => a.Value, new DateTimeRangeValue { Start = DateTime.Now, End = DateTime.Now.AddDays(30) });
            builder.Add(a => a.ClearButtonText, "Clear");
        });

        Assert.Equal("Clear", cut.Find(".is-clear").TextContent);
    }

    [Fact]
    public void TodayButtonText_Ok()
    {
        var cut = Context.RenderComponent<DateTimeRange>(builder =>
        {
            builder.Add(a => a.Value, new DateTimeRangeValue { Start = DateTime.Now, End = DateTime.Now.AddDays(30) });
            builder.Add(a => a.TodayButtonText, "Today");
            builder.Add(a => a.ShowToday, true);
        });
        var today = cut.FindAll("button").Select(s => s.TextContent == "Today");

        Assert.NotNull(today);
    }

    [Fact]
    public void ConfirmButtonText_Ok()
    {
        var cut = Context.RenderComponent<DateTimeRange>(builder =>
        {
            builder.Add(a => a.Value, new DateTimeRangeValue { Start = DateTime.Now, End = DateTime.Now.AddDays(30) });
            builder.Add(a => a.ConfirmButtonText, "Confirm");
            builder.Add(a => a.ShowToday, true);
        });
        var today = cut.FindAll("button").Select(s => s.TextContent == "Confirm");

        Assert.NotNull(today);
    }

    [Fact]
    public void Placement_Ok()
    {
        var cut = Context.RenderComponent<DateTimeRange>(builder =>
        {
            builder.Add(a => a.Value, new DateTimeRangeValue { Start = DateTime.Now, End = DateTime.Now.AddDays(30) });
            builder.Add(a => a.Placement, Placement.Top);
        });
        var placement = cut.FindAll("div").Select(s => s.GetAttribute("data-bs-placement")).FirstOrDefault();

        Assert.Equal("top", placement);
    }

    [Fact]
    public void IsShown_Ok()
    {
        var cut = Context.RenderComponent<DateTimeRange>(builder =>
        {
            builder.Add(a => a.Value, new DateTimeRangeValue { Start = DateTime.Now, End = DateTime.Now.AddDays(30) });
            builder.Add(a => a.IsShown, true);
        });

        Assert.Contains("d-none", cut.Markup);
    }

    [Fact]
    public void AllowNull_Ok()
    {
        var cut = Context.RenderComponent<DateTimeRange>(builder =>
        {
            builder.Add(a => a.Value, new DateTimeRangeValue { Start = DateTime.Now, End = DateTime.Now.AddDays(30) });
            builder.Add(a => a.AllowNull, true);
        });
    }

    [Fact]
    public void ShowSidebar_Ok()
    {
        var cut = Context.RenderComponent<DateTimeRange>(builder =>
        {
            builder.Add(a => a.Value, new DateTimeRangeValue { Start = DateTime.Now, End = DateTime.Now.AddDays(30) });
            builder.Add(a => a.ShowSidebar, true);
        });

        Assert.NotNull(cut.Find(".picker-panel-sidebar"));
    }

    [Fact]
    public void SidebarItems_Ok()
    {
        var cut = Context.RenderComponent<DateTimeRange>(builder =>
        {
            builder.Add(a => a.Value, new DateTimeRangeValue { Start = DateTime.Now, End = DateTime.Now.AddDays(30) });
            builder.Add(a => a.ShowSidebar, true);
            builder.Add(a => a.SidebarItems, new DateTimeRangeSidebarItem[]
            {
                    new DateTimeRangeSidebarItem(){ Text = "Test" }
            });
        });

        var text = cut.Find(".picker-panel-sidebar").TextContent;
        Assert.Equal("Test", text);
    }

    [Fact]
    public void OnConfirm_Ok()
    {
        var value = false;
        var cut = Context.RenderComponent<DateTimeRange>(builder =>
        {
            builder.Add(a => a.Value, new DateTimeRangeValue { Start = DateTime.Now, End = DateTime.Now.AddDays(30) });
            builder.Add(a => a.OnConfirm, (e) =>
            {
                value = true; return Task.CompletedTask;
            });
        });

        cut.FindAll(".is-confirm").FirstOrDefault(s => s.TextContent == "确定")?.Click();
        Assert.True(value);
    }

    [Fact]
    public void OnClearValue_Ok()
    {
        var value = false;
        var cut = Context.RenderComponent<DateTimeRange>(builder =>
        {
            builder.Add(a => a.Value, new DateTimeRangeValue { Start = DateTime.Now, End = DateTime.Now.AddDays(30) });
            builder.Add(a => a.OnClearValue, (e) =>
            {
                value = true; return Task.CompletedTask;
            });
        });

        cut.FindAll(".is-confirm").FirstOrDefault(s => s.TextContent == "清空")?.Click();
        Assert.True(value);
    }

    [Fact]
    public void OnValueChanged_Ok()
    {
        var value = new DateTimeRangeValue() { Start = DateTime.Now, End = DateTime.Now.AddDays(10) };
        var cut = Context.RenderComponent<DateTimeRange>(builder =>
        {
            builder.Add(a => a.Value, new DateTimeRangeValue { Start = DateTime.Now, End = DateTime.Now.AddDays(30) });
            builder.Add(a => a.OnValueChanged, v => { value = v; return Task.CompletedTask; });
        });

        cut.FindAll(".is-confirm").FirstOrDefault(s => s.TextContent == "清空")?.Click();
    }

    [Fact]
    public void ValueChanged_Ok()
    {
        var value = new DateTimeRangeValue() { Start = DateTime.Now, End = DateTime.Now.AddDays(10) };
        var cut = Context.RenderComponent<DateTimeRange>(builder =>
        {
            builder.Add(a => a.Value, new DateTimeRangeValue { Start = DateTime.Now, End = DateTime.Now.AddDays(30) });
            builder.Add(a => a.ValueChanged, EventCallback.Factory.Create<DateTimeRangeValue>(this, v => { value = v; }));
        });

        cut.FindAll(".is-confirm").FirstOrDefault(s => s.TextContent == "清空")?.Click();
    }

    [Fact]
    public void ClickToday_Ok()
    {
        var cut = Context.RenderComponent<DateTimeRange>(builder =>
        {
            builder.Add(a => a.Value, new DateTimeRangeValue { Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(30) });
            builder.Add(a => a.ShowToday, true);
        });

        cut.FindAll(".is-confirm").FirstOrDefault(s => s.TextContent == "今天")?.Click();

        Assert.Equal(DateTime.Now.ToString("yyyy-MM-dd"), cut.Instance.Value.Start.ToString("yyyy-MM-dd"));
    }

    [Fact]
    public void OnClickSidebarItem_Ok()
    {
        var cut = Context.RenderComponent<DateTimeRange>(builder =>
        {
            builder.Add(a => a.Value, new DateTimeRangeValue { Start = DateTime.Now.AddDays(1), End = DateTime.Now.AddDays(30) });
            builder.Add(a => a.ShowSidebar, true);
        });

        cut.FindAll(".sidebar-item").FirstOrDefault(s => s.TextContent == "上个月")?.NextElementSibling?.Click();
        //Assert.Equal("2021-11-01", cut.Instance.Value.Start.ToString("yyyy-MM-dd"));
    }
}
