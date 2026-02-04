using Moq;
namespace TestProject2
{
    public class Tests
    {
        

        [Test]
        public void Test2()
        {
            var ob = new Mock<IMath>();
            var o= ob.Object;
            ob.Setup(c=>c.Add(10,10)).Returns(10);

            Client c=new Client(ob.Object);
            var res = c.AddClient(10, 10);
            Assert.That(5, Is.EqualTo(res));
        }
    }
}