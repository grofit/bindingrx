﻿using System;
using BindingsRx.Convertors;
using BindingsRx.Filters;
using BindingsRx.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace BindingsRx.UI
{
    public static class InputFieldExtensions
    {
        public static IDisposable BindTextTo(this InputField input, IReactiveProperty<string> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<string>[] filters)
        { return GenericBindings.Bind(() => input.text, x => input.text = x, property, bindingType, filters).AddTo(input); }

        public static IDisposable BindTextTo(this InputField input, IReactiveProperty<int> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<string>[] filters)
        { return GenericBindings.Bind(() => input.text, x => input.text = x, property, new TextToIntConvertor(), bindingType, filters).AddTo(input); }

        public static IDisposable BindTextTo(this InputField input, IReactiveProperty<float> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<string>[] filters)
        { return GenericBindings.Bind(() => input.text, x => input.text = x, property, new TextToFloatConvertor(), bindingType, filters).AddTo(input); }

        public static IDisposable BindTextTo(this InputField input, IReactiveProperty<double> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<string>[] filters)
        { return GenericBindings.Bind(() => input.text, x => input.text = x, property, new TextToDoubleConvertor(), bindingType, filters).AddTo(input); }

        public static IDisposable BindTextTo(this InputField input, Func<string> getter, Action<string> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<string>[] filters)
        { return GenericBindings.Bind(() => input.text, x => input.text = x, getter, setter, bindingType, filters).AddTo(input); }

        public static IDisposable BindCaretColorTo(this InputField input, IReactiveProperty<Color> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<Color>[] filters)
        { return GenericBindings.Bind(() => input.caretColor, x => input.caretColor = x, property, bindingType, filters).AddTo(input); }

        public static IDisposable BindCaretColorTo(this InputField input, Func<Color> getter, Action<Color> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<Color>[] filters)
        { return GenericBindings.Bind(() => input.caretColor, x => input.caretColor = x, getter, setter, bindingType, filters).AddTo(input); }

        public static IDisposable BindColorTo(this InputField input, IReactiveProperty<Color> property, BindingTypes bindingType = BindingTypes.Default, params IFilter<Color>[] filters)
        { return input.textComponent.BindColorTo(property, bindingType, filters).AddTo(input); }

        public static IDisposable BindColorTo(this InputField input, Func<Color> getter, Action<Color> setter, BindingTypes bindingType = BindingTypes.Default, params IFilter<Color>[] filters)
        { return input.textComponent.BindColorTo(getter, setter, bindingType, filters).AddTo(input); }
    }
}
