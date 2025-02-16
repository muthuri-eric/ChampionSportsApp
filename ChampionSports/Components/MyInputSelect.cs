﻿namespace ChampionSports.Components;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Diagnostics.CodeAnalysis;

public class MyInputSelect<TValue> : InputSelect<TValue>
{
    protected override bool TryParseValueFromString(string? value, [MaybeNullWhen(false)] out TValue result, [NotNullWhen(false)] out string? validationErrorMessage)
    {
        base.OnParametersSet();
        if (typeof(TValue) == typeof(int))
        {
            if (int.TryParse(value, out int resultInt))
            {
                result = (TValue)(object)resultInt;
                validationErrorMessage = null;
                return true;
            }
            else
            {
                result = default;
                validationErrorMessage =
                    $"The selected value {value} is not a valid number.";
                return false;
            }
        }
        else
        {
            return base.TryParseValueFromString(value, out result,
                out validationErrorMessage);
        }
        
    }
    
}
