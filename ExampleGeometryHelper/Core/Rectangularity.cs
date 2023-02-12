namespace ExampleGeometryHelper.Core {

    internal static class Rectangularity {

        public static bool IsRectangularTriangle( IEnumerable<double> values ) {
            var sortedList = values.ToList ();
            sortedList.Sort ();
            var legA = sortedList[0];
            var legB = sortedList[1];
            var hypotenuse = sortedList[2];

            return hypotenuse * hypotenuse == ( legA * legA ) + ( legB * legB );
        }
    }
}