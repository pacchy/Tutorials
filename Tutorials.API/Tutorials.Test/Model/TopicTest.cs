using System;
using Tutorials.API.Model;
using Xunit;

namespace Tutorials.API.Test
{
    public class TopicTest
    {
        Topic topic;
        public TopicTest() 
        {
            topic = new Topic();
            topic.Tutorials.Add(new Tutorial() { Duration = new TimeSpan(0, 1, 0, 10, 0), Name="IntroVideo", TutorialType = TutorialType.Video });
            topic.Tutorials.Add(new Tutorial() { Duration = new TimeSpan(0, 0, 0, 30, 0), Name = "IntroAudio", TutorialType = TutorialType.Audio });
        }

        [Fact]
        public void TopicDurationShouldAddUp()
        {
             Assert.Equal(topic.Duration, new TimeSpan(0, 1, 0, 40, 0));
        }

        [Fact]
        public void TopicDurationShouldNotBeNegative()
        {
            //Arrange
            topic = new Topic();
            topic.Tutorials.Add(new Tutorials.API.Model.Tutorial() { Duration = new TimeSpan(0, -1, 0, -10, 0), Name = "Invalid", TutorialType = TutorialType.Video });

            //Assert
            Assert.Equal(topic.Duration, TimeSpan.Zero);
        }
    }
}
