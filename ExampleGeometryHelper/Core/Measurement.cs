namespace ExampleGeometryHelper.Core {

    internal static class Measurement {

        public static double MeasureAreaCircle( IEnumerable<double> values ) {
            var radius = values.ElementAt ( 0 );
            return Math.PI * radius * radius;
        }

        public static double MeasureAreaTriangle( IEnumerable<double> values ) {
            var sideA = values.ElementAt ( 0 );
            var sideB = values.ElementAt ( 1 );
            var sideC = values.ElementAt ( 2 );
            var p = ( values.Sum () ) / 2;
            return Math.Sqrt ( p * ( p - sideA ) * ( p - sideB ) * ( p - sideC ) );
        }

        public static double MeasureAreaRectangle( IEnumerable<double> values ) {
            var sideA = values.ElementAt ( 0 );
            var sideB = values.ElementAt ( 1 );
            return sideA * sideB;
        }

        public static double MeasureAreaCube( IEnumerable<double> values ) {
            var sideA = values.ElementAt ( 0 );
            return sideA * sideA;
        }

    }
}