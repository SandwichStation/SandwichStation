// SPDX-FileCopyrightText: 2025 ShibbyBot <shibby@inucast.com>
// SPDX-FileCopyrightText: 2025 deltanedas <39013340+deltanedas@users.noreply.github.com>
// SPDX-FileCopyrightText: 2025 deltanedas <@deltanedas:kde.org>
//
// SPDX-License-Identifier: AGPL-3.0-or-later

using Content.Goobstation.Shared.Factory.Filters;
using Robust.Client.UserInterface;

namespace Content.Goobstation.Client.Factory.UI;

public sealed class PressureFilterBUI : BoundUserInterface
{
    private PressureFilterWindow? _window;

    public PressureFilterBUI(EntityUid owner, Enum uiKey) : base(owner, uiKey)
    {
    }

    protected override void Open()
    {
        base.Open();

        _window = this.CreateWindow<PressureFilterWindow>();
        _window.SetEntity(Owner);
        _window.OnSetMin += min => SendPredictedMessage(new PressureFilterSetMinMessage(min));
        _window.OnSetMax += max => SendPredictedMessage(new PressureFilterSetMaxMessage(max));
    }
}
