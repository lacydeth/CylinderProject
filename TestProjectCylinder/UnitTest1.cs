using CylinderProject.Models;

namespace TestProjectCylinder
{
    public class UnitTest1
    {

        [Fact]
        public void IsHeightAndRadiusRight()
        {
            double expectedRadius = 5;
            double expectedHeight = 10;

            var cylinder = new Cylinder(expectedRadius, expectedHeight);

            Assert.Equal(expectedRadius, cylinder.Radius);
            Assert.Equal(expectedHeight, cylinder.Height);
        }
        [Theory]
        [InlineData(-5, 10)]  
        [InlineData(5, -10)] 
        [InlineData(0, 10)]
        [InlineData(5, 0)]
        public void IsConstructorThrowsException(double radius, double height)
        {
            Assert.Throws<ArgumentException>(() => new Cylinder(radius, height));
        }
        [Fact]
        public void IsGetVolumeRight()
        {
            double radius = 5;
            double height = 10;
            var cylinder = new Cylinder(radius, height);
            double expectedVolume = Math.PI * Math.Pow(radius, 2) * height;

            double actualVolume = cylinder.GetVolume();

            Assert.Equal(expectedVolume, actualVolume, precision: 5);
        }

        [Fact]
        public void IsGetSurfaceRight()
        {
            double radius = 5;
            double height = 10;
            var cylinder = new Cylinder(radius, height);
            double expectedSurfaceArea = 2 * Math.PI * Math.Pow(radius, 2) + 2 * Math.PI * radius * height;

            double actualSurfaceArea = cylinder.GetSurfaceArea();

            Assert.Equal(expectedSurfaceArea, actualSurfaceArea, precision: 5);
        }
        [Fact]
        public void IsResizeUpdates()
        {
            var cylinder = new Cylinder(5, 10);
            double newRadius = 7;
            double newHeight = 12;

            cylinder.Resize(newRadius, newHeight);

            Assert.Equal(newRadius, cylinder.Radius);
            Assert.Equal(newHeight, cylinder.Height);
        }

        [Theory]
        [InlineData(-1, 10)]  
        [InlineData(5, -1)] 
        [InlineData(0, 10)]
        [InlineData(5, 0)] 
        public void IsResizeThrowsExpection(double newRadius, double newHeight)
        {
            var cylinder = new Cylinder(5, 10);

            Assert.Throws<ArgumentException>(() => cylinder.Resize(newRadius, newHeight));
        }
        [Fact]
        public void IsObjectNotNull()
        {
            var cylinder = new Cylinder(5, 10);
            Assert.NotNull(cylinder);
        }
        [Theory]
        [InlineData(1, 10)]
        [InlineData(50, 10)]
        [InlineData(100, 10)]
        public void IsRadiusInRange(double radius, double height)
        {
            var cylinder = new Cylinder(radius, height);

            Assert.InRange(cylinder.Radius, 1, 100);
        }

    }

}