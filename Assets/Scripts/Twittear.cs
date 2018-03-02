using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Twittear : MonoBehaviour
{

    private const string TWITTER_ADDRESS = "http://twitter.com/intent/tweet";
    private const string TWEET_LANGUAGE = "es";

    private Story source;
    public StoryTeller storyTeller; 

    public void ShareToTwitter()
    {
        source = storyTeller.CurrentStory;
        Application.OpenURL(TWITTER_ADDRESS +
                    "?text=" + WWW.EscapeURL(source.transcription) +
                    "&amp;lang=" + WWW.EscapeURL(TWEET_LANGUAGE));
    }

    public void openLink()
    {
        source = storyTeller.CurrentStory;
        Application.OpenURL(source.url);
    }

}
