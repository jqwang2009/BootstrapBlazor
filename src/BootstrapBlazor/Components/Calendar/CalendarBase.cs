﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using Microsoft.AspNetCore.Components;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace BootstrapBlazor.Components;

/// <summary>
/// Calendar 组件基类
/// </summary>
public abstract class CalendarBase : BootstrapComponentBase
{
    /// <summary>
    /// 获得/设置 日历框开始时间
    /// </summary>
    protected DateTime StartDate
    {
        get
        {
            if (ViewModel == CalendarViewModel.Month)
            {
                var d = Value.AddDays(1 - Value.Day);
                d = d.AddDays(0 - (int)d.DayOfWeek);
                return d;
            }
            else
            {
                return Value.AddDays(0 - (int)Value.DayOfWeek);
            }
        }
    }

    /// <summary>
    /// 获得 当前周数
    /// </summary>
    protected int GetWeekCount()
    {
        var gc = new GregorianCalendar();
        return gc.GetWeekOfYear(Value, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
    }

    /// <summary>
    /// 获得/设置 日历框结束时间
    /// </summary>
    protected DateTime EndDate => ViewModel == CalendarViewModel.Month ? StartDate.AddDays(42) : StartDate.AddDays(7);

    /// <summary>
    /// 获得/设置 组件值
    /// </summary>
    [Parameter]
    public DateTime Value { get; set; }

    /// <summary>
    /// 获得/设置 值改变时回调委托
    /// </summary>
    [Parameter]
    public EventCallback<DateTime> ValueChanged { get; set; }

    /// <summary>
    /// 获得/设置 是否显示周视图 默认为 CalendarVieModel.Month 月视图
    /// </summary>
    [Parameter]
    public CalendarViewModel ViewModel { get; set; }

    /// <summary>
    /// 获得/设置 周内容
    /// </summary>
    [Parameter]
    public RenderFragment? ChildContent { get; set; }

    /// <summary>
    /// OnInitialized
    /// </summary>
    protected override void OnInitialized()
    {
        base.OnInitialized();

        if (Value == DateTime.MinValue) Value = DateTime.Today;
    }

    /// <summary>
    /// 选中日期时回调此方法
    /// </summary>
    /// <param name="value"></param>
    protected async Task OnCellClickCallback(DateTime value)
    {
        Value = value;
        if (ValueChanged.HasDelegate) await ValueChanged.InvokeAsync(Value);
        StateHasChanged();
    }

    /// <summary>
    /// 右侧快捷切换年按钮回调此方法
    /// </summary>
    /// <param name="offset"></param>
    protected void OnChangeYear(int offset)
    {
        if (offset == 0) Value = DateTime.Today;
        else Value = Value.AddYears(offset);
    }

    /// <summary>
    /// 右侧快捷切换月按钮回调此方法
    /// </summary>
    /// <param name="offset"></param>
    protected void OnChangeMonth(int offset)
    {
        if (offset == 0) Value = DateTime.Today;
        else Value = Value.AddMonths(offset);
    }

    /// <summary>
    /// 右侧快捷切换周按钮回调此方法
    /// </summary>
    /// <param name="offset"></param>
    protected void OnChangeWeek(int offset)
    {
        if (offset == 0) Value = DateTime.Today;
        else Value = Value.AddDays(offset);
    }
}
