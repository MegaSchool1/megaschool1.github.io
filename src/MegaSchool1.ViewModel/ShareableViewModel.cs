﻿using MegaSchool1.Model;
using Microsoft.AspNetCore.Components;
using OneOf;
using OneOf.Types;
using System;

namespace MegaSchool1.ViewModel;

public class ShareableViewModel
{
    public Content Id { get; set; }

    public OneOf<VideoViewModel, None> Video { get; set; } = new None();

    public OneOf<string, None> Url { get; set; } = new None();

    public string AppDescription { get; set; } = default!;

    public string Title { get; set; } = default!;

    public Image ShareableImage { get; set; } = Image.MoneyChallengeLogo;

    public Image CapturePageImage { get; set; } = Image.MoneyChallengeLogo;

    public OneOf<(string Text, Uri Url), None> Download { get; set; } = new None();

    public OneOf<(string Description, DateTimeOffset Expiration), None> Promo { get; set; } = new None();

    public OneOf<EventViewModel, None> Event { get; set; } = new None();

    public bool ShowBusinessSignUp { get; set; }

    public bool HideShortCodePrompt { get; set; }

    public OneOf<ImageInfo[], None> Images { get; set; } = new None();

    public OneOf<string, None> AuxiliaryText { get; set; } = new None();
 
    public OneOf<string, None> Metadata { get; set; } = new None();
    
    public static string VideoShareable(ShareableViewModel shareable)
    {
        var durationEstimate = shareable.Video.Match(
            video => Util.MinuteEstimate(video.Duration),
            none => TimeSpan.Zero);

        var videoUrl = shareable.Video.Match(
            video => video.Video.MinimalistUrl(),
            none => null);

        return $"{shareable.Title}{Environment.NewLine}{Constants.PointingDownEmoji}{Environment.NewLine}({(durationEstimate.Hours == 0 ? string.Empty : $"{durationEstimate.Hours}hr ")}{durationEstimate.Minutes}min){Environment.NewLine}{videoUrl}";
    }

    public static string CapturePageShareable(ShareableViewModel shareable, NavigationManager navigationManager, Language language, string memberId, string referralCode)
    {
        var durationEstimate = shareable.Video.Match(
            video => Util.MinuteEstimate(video.Duration),
            none => TimeSpan.Zero);

        var videoUrl = Constants.GetCapturePage(shareable.Id, language, navigationManager, memberId, referralCode);

        return $"{shareable.Title}{Environment.NewLine}{Constants.PointingDownEmoji}{Environment.NewLine}({(durationEstimate.Hours == 0 ? string.Empty : $"{durationEstimate.Hours}hr ")}{durationEstimate.Minutes}min){Environment.NewLine}{videoUrl}";
    }
}
