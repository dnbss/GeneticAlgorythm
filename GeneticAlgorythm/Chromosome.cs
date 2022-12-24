using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;

namespace GeneticAlgorythm
{
    public class Chromosome
    {
        public double[] Gens;

        public readonly int Size;

        public Chromosome(int size)
        {
            Size = size;

            Gens = new double[size];

            Random r = new();

            for (int i = 0; i < Size; i++)
            {
                Gens[i] = r.NextDouble() - 0.5;
            }
        }

        public Chromosome(BitArray bits)
        {
            var binary = ToBinary(bits);

            Size = binary.Length / (8 * 8);

            Gens = new double[Size];

            for (int i = 0; i < Size; i++)
            {
                List<byte> bytes = new();

                for (int byteIndex = i * 8; byteIndex < i * 8 + 8; byteIndex++)
                {
                    bool[] oneByte = new bool[8];

                    for (int bitIndex = 0; bitIndex < 8; bitIndex++)
                    {
                        int bitArrayIndex = byteIndex * 8 + bitIndex;

                        oneByte[bitIndex] = binary[bitArrayIndex];
                    }

                    oneByte.Reverse();

                    bytes.Add(ConvertBoolArrayToByte(oneByte));
                }

                var gen = BitConverter.ToDouble(bytes.ToArray(), 0);

                Gens[i] = gen;
            }
        }

        public BitArray ToBits()
        {
            var chromosomeBytes = Gens.Select(gen => BitConverter.GetBytes(gen)).ToList();

            var chromosomeJoinedBytes = new List<byte>();

            foreach (var item in chromosomeBytes)
            {
                chromosomeJoinedBytes.AddRange(item);
            }

            var chromosomeBits = new BitArray(chromosomeJoinedBytes.ToArray());

            return ToGray(chromosomeBits);

        }

        private BitArray ToGray(BitArray binary)
        {
            var gray = new BitArray(binary.Length);

            gray[binary.Length - 1] = binary[binary.Length - 1];

            for (int i = binary.Length - 2; i >= 0; --i)
            {
                gray[i] = binary[i] ^ binary[i + 1];
            }

            return gray;
        }

        private BitArray ToBinary(BitArray gray)
        {
            var binary = new BitArray(gray.Length);

            binary[gray.Length - 1] = gray[gray.Length - 1]; 

            for (var i = gray.Length - 2; i >= 0; --i)
            {
                binary[i] = !gray[i] ^ !binary[i + 1];
            }

            return binary;
        }

        private byte ConvertBoolArrayToByte(bool[] source)
        {
            byte result = 0;
            int index = 0;

            foreach (bool b in source)
            {
                if (b)
                {
                    result |= (byte)(1 << index);
                }

                index++;
            }

            return result;
        }
    }
}