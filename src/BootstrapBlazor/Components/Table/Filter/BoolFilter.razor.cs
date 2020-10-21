﻿using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BootstrapBlazor.Components
{
    /// <summary>
    /// 布尔类型过滤条件
    /// </summary>
    public partial class BoolFilter
    {
        private string Value { get; set; } = "";

        [NotNull]
        private IEnumerable<SelectedItem>? Items { get; set; }

        [Inject]
        [NotNull]
        private IStringLocalizer<TableFilter>? Localizer { get; set; }

        /// <summary>
        /// OnInitialized 方法
        /// </summary>
        protected override void OnInitialized()
        {
            base.OnInitialized();

            Items = new SelectedItem[]
            {
                new SelectedItem("", Localizer["BoolFilter.AllText"]),
                new SelectedItem("true", Localizer["BoolFilter.TrueText"]),
                new SelectedItem("false", Localizer["BoolFilter.FalseText"])
            };

            if (TableFilter != null)
            {
                TableFilter.ShowMoreButton = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Reset()
        {
            Value = "";
            StateHasChanged();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override IEnumerable<FilterKeyValueAction> GetFilterConditions()
        {
            var filters = new List<FilterKeyValueAction>();
            if (!string.IsNullOrEmpty(Value)) filters.Add(new FilterKeyValueAction()
            {
                FieldKey = FieldKey,
                FieldValue = Value == "" ? (object?)null : (Value == "true"),
                FilterAction = FilterAction.Equal
            });
            return filters;
        }
    }
}
