using ExampleGeometryHelper.Core;
using ExampleGeometryHelper.Core.Enums;

namespace ExampleGeometryHelperTests {

    public class TestSuite_AreaMeasure {

        [SetUp]
        public void Setup() {
        }

        [Test]
        public void Test_MeasureAreaCircle_Positive() {
            List<double> values = new () { 12.3 };
            var expected = Math.Round ( 475.2915, 2 );
            var result = GeometryHelper.MeasureArea ( ShapeType.Circle, values );
            Assert.Multiple ( () => {
                Assert.That ( result, Is.Not.Null );
                Assert.That ( Math.Round ( result ?? 0d, 2 ), Is.EqualTo ( expected ) );
            } );
        }

        [Test]
        public void Test_MeasureAreaCircle_Negative() {
            List<double> values = new () { 25.3 };
            var expected = Math.Round ( 475.2915, 2 );
            var result = GeometryHelper.MeasureArea ( ShapeType.Circle, values );
            Assert.Multiple ( () => {
                Assert.That ( result, Is.Not.Null );
                Assert.That ( Math.Round ( result ?? 0d, 2 ), Is.Not.EqualTo ( expected ) );
            } );
        }

        [Test]
        public void Test_MeasureAreaCircle_Throw() {
            List<double> values = new () { -12.3 };
            Assert.Throws<ArgumentException> ( () => GeometryHelper.MeasureArea ( ShapeType.Circle, values ) );
        }

        [Test]
        public void Test_MeasureAreaTriangle_Positive() {
            List<double> values = new () { 3, 4, 6 };
            var expected = Math.Round ( 5.33, 2 );
            var result = GeometryHelper.MeasureArea ( ShapeType.Triangle, values );
            Assert.Multiple ( () => {
                Assert.That ( result, Is.Not.Null );
                Assert.That ( Math.Round ( result ?? 0d, 2 ), Is.EqualTo ( expected ) );
            } );
        }

        [Test]
        public void MeasureAreaTriangle_Negative() {
            List<double> values = new () { 3, 4, 6 };
            var expected = Math.Round ( 25.33, 2 );
            var result = GeometryHelper.MeasureArea ( ShapeType.Triangle, values );
            Assert.Multiple ( () => {
                Assert.That ( result, Is.Not.Null );
                Assert.That ( Math.Round ( result ?? 0d, 2 ), Is.Not.EqualTo ( expected ) );
            } );
        }

        [Test]
        public void Test_MeasureAreaTriangle_NonExistent() {
            List<double> values = new () { 3, 2, 6 };
            var result = GeometryHelper.MeasureArea ( ShapeType.Triangle, values );
            Assert.That ( result, Is.NaN );
        }

        [Test]
        public void Test_MeasureAreaTriangle_Throw() {
            List<double> values = new () { 3, 0, 6 };
            Assert.Throws<ArgumentException> ( () => GeometryHelper.MeasureArea ( ShapeType.Triangle, values ) );
        }

        [Test]
        public void Test_MeasureAreaTriangle_JsonPositive() {
            var json = @"{
                ""Type"": 3,
                ""Values"": [3,4,6]}";

            var result = GeometryHelper.MeasureArea ( json );
            var expected = Math.Round ( 5.33, 2 );
            Assert.Multiple ( () => {
                Assert.That ( result, Is.Not.Null );
                Assert.That ( Math.Round ( result ?? 0d, 2 ), Is.EqualTo ( expected ) );
            } );
        }
    }
}