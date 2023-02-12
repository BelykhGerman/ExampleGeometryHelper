using ExampleGeometryHelper.Core.Enums;

namespace ExampleGeometryHelper.Core.Models {

    internal class ShapeDTO {
        public ShapeType Type { get; set; }
        public IEnumerable<double> Values { get; set; }
    }
}