using ExampleGeometryHelper.Core;
using ExampleGeometryHelper.Core.Enums;

namespace ExampleGeometryHelperTests {

    public class TestSuite_Rectangularity {

        [SetUp]
        public void Setup() {
        }

        [Test]
        public void Test_MeasureIsRectangularTriangle_Positive() {
            List<double> values = new () { 3, 4, 5 };
            var result = GeometryHelper.IsRectangular ( ShapeType.Triangle, values );
            Assert.That ( result, Is.True );
        }

        [Test]
        public void Test_MeasureIsRectangularTriangle_Negative() {
            List<double> values = new () { 3, 4, 6 };
            var result = GeometryHelper.IsRectangular ( ShapeType.Triangle, values );
            Assert.That ( result, Is.False );
        }

        [Test]
        public void Test_MeasureIsRectangularTriangle_Throw() {
            List<double> values = new () { -3, 0, 6 };
            Assert.Throws<ArgumentException> ( () => GeometryHelper.IsRectangular ( ShapeType.Triangle, values ) );
        }
    }
}