using ExampleGeometryHelper.Core.Enums;
using ExampleGeometryHelper.Core.Models;
using System.Text;
using System.Text.Json;

namespace ExampleGeometryHelper.Core {

    /// <summary>
    /// The class performs calculations when working with 2d shapes.
    /// </summary>
    public static class GeometryHelper {

        private static readonly Dictionary<ShapeType, Delegate> _measurements = new (){
            { ShapeType.Circle , Measurement.MeasureAreaCircle },
            { ShapeType.Triangle , Measurement.MeasureAreaTriangle },
            { ShapeType.Rectangle , Measurement.MeasureAreaRectangle },
            { ShapeType.Cube , Measurement.MeasureAreaCube },
        };

        private static readonly Dictionary<ShapeType, Delegate> _rectangularity = new (){
            { ShapeType.Triangle , Rectangularity.IsRectangularTriangle },
        };

        /// <summary>
        /// Calculates the area of a figure with given parameters.
        /// </summary>
        /// <param name="JsonValues">Inline JSON ({
        /// "figure type": integer
        /// ( Circle = 1
        /// Oval= 2,
        /// Triangle= 3,
        /// Rectangle = 4
        /// Cube = 5,
        /// Rhombus = 6 ),
        /// "values":[number]
        /// }</param>
        /// <returns>The value of the area</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="JsonException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public static double? MeasureArea( string JsonValues ) {
            if(JsonValues is null) {
                throw new ArgumentNullException ( "Null value passed" );
            }
            try {
                var shape = JsonSerializer.Deserialize<ShapeDTO> ( JsonValues );
                return MeasureArea ( shape.Type, shape.Values );
            }
            catch(Exception ex) {
                //TODO: log ex
                throw;
            }
        }

        /// <summary>
        /// Calculates the area of a figure with given parameters.
        /// </summary>
        /// <returns>The value of the area</returns>
        public static double? MeasureArea( ShapeType type, IEnumerable<double> values ) {
            try {
                CheckValues ( values );
                var result = Convert.ToDouble ( _measurements[type].DynamicInvoke ( values ) );
                return result;
            }
            catch(Exception ex) {
                //TODO: log ex
                throw;
            }
        }

        /// <summary>
        /// Determines if a triangle is a right triangle.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="values">Have to include 3 values (sides).</param>
        /// <returns></returns>
        public static bool? IsRectangular( ShapeType type, IEnumerable<double> values ) {
            try {
                CheckValues ( values, 3 );
                var result = Convert.ToBoolean ( _rectangularity[type].DynamicInvoke ( values ) );
                return result;
            }
            catch(Exception ex) {
                //TODO: log ex
                throw;
            }
        }


        private static void CheckValues( IEnumerable<double> values, int requiredQuantity = 0 ) {
            if(requiredQuantity > 0 && values.Count () != requiredQuantity) {
                throw new Exception ( $"Invalid number of arguments passed. Requires {requiredQuantity}." );
            }
            var invalidValue = values.Where ( v => v <= 0 );
            if(invalidValue.Any ()) {
                StringBuilder strb = new ();
                invalidValue.AsParallel ().ForAll ( a => strb.Append ( $"{a}, " ) );
                throw new ArgumentException ( $"The value(s) can't be less or equal 0. (actual - {strb.ToString ().TrimEnd ( ',' )}." );
            }
        }
    }
}