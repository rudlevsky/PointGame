using System.Drawing;
using NUnit.Framework;
using Moq;

using FPointGame.GenericTypes;
using FPointGame.Interfaces;

namespace FPointGame.Tests
{
	[TestFixture]
	public class GenericTypesTests
	{
		[Test]
		public void ChannelTest_CallPublish_NotifyAllIsCalled()
		{
			var channleMock = new Mock<IChannel<Point>>();
			Hunter<Point> hunter = new Hunter<Point>(channleMock.Object);

			hunter.Content = new Point(100, 100);

			channleMock.Verify((channel) => channel.NotifyAll(It.IsAny<Message<Point>>()),
				Times.Once);
		}

		[Test]
		public void SubscriptionTest_CallNotifyAll_UpdateCalled()
		{
			Channel<Point> channel = new Channel<Point>();
			Hunter<Point> hunter = new Hunter<Point>(channel);
			var SubMock = new Mock<ISubscriber<Point>>();

			channel.AddSubscriber(SubMock.Object);

			hunter.Content = new Point(100, 150);

			SubMock.Verify((Sub) => Sub.Update(It.IsAny<Message<Point>>()),
				Times.Once);
		}

		[TestCaseSource("HunterLocation")]
		public void SubscriptionTest_CallNotifyAll_EqualPubAndSubContent(Point hunterLocation)
		{
			Channel<Point> channel = new Channel<Point>();
			Hunter<Point> hunter = new Hunter<Point>(channel);
			Prey prey = new Prey(100, 500, 10);

			channel.AddSubscriber(prey);

			hunter.Content = hunterLocation;

			Assert.AreEqual(hunter.Content, prey.PubContent);
		}

		[TestCaseSource("HunterLocation")]
		public void SubscriptionTest_CallNotifyAll_SubLocationNotChanged(Point hunterLocation)
		{
			Channel<Point> channel = new Channel<Point>();
			Hunter<Point> hunter = new Hunter<Point>(channel);
			Point oldLocation = new Point(100, 50);
			Prey prey = new Prey(oldLocation, 10);

			channel.AddSubscriber(prey);

			hunter.Content = new Point(100, 150);

			Assert.AreEqual(oldLocation, prey.SubContent);
		}

		[TestCaseSource("HunterCloseLocation")]
		public void SubscriptionTest_CallNotifyAll_SubLocationChanged(Point preyOldLocation, Point hunterCloseLocation)
		{
			Channel<Point> channel = new Channel<Point>();
			Hunter<Point> hunter = new Hunter<Point>(channel);
			Prey prey = new Prey(preyOldLocation, 10);

			channel.AddSubscriber(prey);

			hunter.Content = hunterCloseLocation;

			Assert.AreNotEqual(preyOldLocation, prey.SubContent);
		}

		private static object[] HunterLocation = new object[]
		{
			new Point(100, 100),
			new Point (200, 200),
			new Point (150, 2)
		};

		private static object[] HunterCloseLocation = new object[]
		{
			new object[] { new Point(100, 50), new Point(75, 50) },
			new object[] { new Point(100, 50), new Point(100, 25) },
			new object[] { new Point(100, 50), new Point(125, 55) } ,
			new object[] { new Point(100, 50), new Point(105,65) },
		};
	}

	
}
