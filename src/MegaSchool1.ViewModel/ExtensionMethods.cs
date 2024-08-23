﻿using MegaSchool1.Model;

namespace MegaSchool1.ViewModel;

public static class ExtensionMethods
{
    public static string? MinimalistUrl(this Video video) =>
        video.Match(
            youTube => Constants.MinimalistYouTubeLink(youTube.VideoId),
            tikTok => Constants.MinimalistTikTokLink(tikTok.UserHandle, tikTok.VideoId),
            vimeo => Constants.MinimalistVimeoLink(vimeo),
            facebook => (string?)null,
            startMeeting => $"https://stme.in/{startMeeting.VideoId}"
        );
}
