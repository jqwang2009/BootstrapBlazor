﻿// Copyright (c) Argo Zhang (argo@163.com). All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
// Website: https://www.blazor.zone or https://argozhang.github.io/

using BootstrapBlazor.Shared.Common;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BootstrapBlazor.Shared.Samples;

/// <summary>
/// 
/// </summary>
public partial class Empties
{

    /// <summary>
    /// 
    /// </summary>
    [Parameter]
    public string? Title { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Parameter]
    public string? SubTitle { get; set; }

    /// <summary>
    /// 
    /// </summary>
    [Inject]
    [NotNull]
    private IStringLocalizer<Empties>? Localizer { get; set; }

    /// <summary>
    /// 
    /// </summary>

    protected override void OnInitialized()
    {
        base.OnInitialized();
        Title = Localizer[nameof(Title)];
        SubTitle = Localizer[nameof(SubTitle)];
    }

    /// <summary>
    /// 获得属性方法
    /// </summary>
    /// <returns></returns>
    private IEnumerable<AttributeItem> GetAttributes() => new[]
    {
            // TODO: 移动到数据库中
            new AttributeItem() {
                Name = "Image",
                Description = Localizer["Image"],
                Type = "string",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new AttributeItem() {
                Name = "Text",
                Description =  Localizer["Text"],
                Type = "string",
                ValueList = " — ",
                DefaultValue = Localizer["TextDefaultValue"]
            },
            new AttributeItem() {
                Name = "Width",
                Description =  Localizer["Width"],
                Type = "string",
                ValueList = " — ",
                DefaultValue = " 100 "
            },
            new AttributeItem() {
                Name = "Height",
                Description =  Localizer["Height"],
                Type = "string",
                ValueList = " — ",
                DefaultValue = " 100 "
            },
            new AttributeItem() {
                Name = "Template",
                Description =  Localizer["Template"],
                Type = "RenderFragment",
                ValueList = " — ",
                DefaultValue = " — "
            },
            new AttributeItem() {
                Name = "ChildContent",
                Description =  Localizer["ChildContent"],
                Type = "RenderFragment",
                ValueList = " — ",
                DefaultValue = " — "
            }
        };
}
