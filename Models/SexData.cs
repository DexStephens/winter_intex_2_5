using Microsoft.ML.OnnxRuntime.Tensors;
using System;
using System.Linq;

namespace winter_intex_2_5.Models
{
    public class SexData
    {
        //not the actual values, just to stop errors right now
        public float MedianIncome { get; set; }
        public float MedianHouseAge { get; set; }
        public float AverageNumberOfRooms { get; set; }
        public float AverageNumberOfBedrooms { get; set; }
        public int Population { get; set; }
        public float AverageOccupancy { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Tensor<T> AsTensor<T>() where T : struct
        {
            object[] data = new object[]
            {
            MedianIncome, MedianHouseAge, AverageNumberOfRooms, AverageNumberOfBedrooms,
            Population, AverageOccupancy, City, State
            };
            int[] dimensions = new int[] { 1, 8 };
            var convertedData = data.Select(d => Convert.ChangeType(d, typeof(T))).ToArray();
            return new DenseTensor<T>(convertedData as T[], dimensions);
        }
    }
}
